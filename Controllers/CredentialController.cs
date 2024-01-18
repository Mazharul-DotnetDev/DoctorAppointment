using DoctorAppointment.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace DoctorAppointment.Controllers
{
    public class CredentialController : ApiController
    {
        private readonly ITokenService _tokenService;
        private readonly IConsumerService _consumerService;


        public CredentialController()
        {
            
        }


        public CredentialController(ITokenService tokenService, IConsumerService consumerService)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _consumerService = consumerService ?? throw new ArgumentNullException(nameof(consumerService));
        }

        [Route("~/access")]
        [HttpPost]
        public IHttpActionResult JWT_Token(ConsumerInfo consumer)
        {
            try
            {
                var loginConsumer = _consumerService.GetConsumerInfo(consumer.ConsumerName, consumer.Password);

                if (loginConsumer is null)
                {
                    return Content(HttpStatusCode.BadRequest, "Invalid credentials");
                }

                var jwt = _tokenService.GenerateToken(loginConsumer);
                return Ok(jwt);
            }
            catch (Exception ex)
            {
                // Log the exception
                return InternalServerError(ex);
            }
        }
    }

    public interface ITokenService
    {
        string GenerateToken(ConsumerInfo consumerInfo);
    }

    public class TokenService : ITokenService
    {
        public string GenerateToken(ConsumerInfo consumerInfo)
        {
            var key = ConfigurationManager.AppSettings["JwtKey"];
            var issuer = ConfigurationManager.AppSettings["JwtIssuer"];
            var audience = ConfigurationManager.AppSettings["JwtAudience"];

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var consumerClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, consumerInfo.ConsumerName),
                new Claim(ClaimTypes.Role, consumerInfo.Role.ToString())
            };

            var token = new JwtSecurityToken(issuer, audience, consumerClaims, expires: DateTime.UtcNow.AddMinutes(30), signingCredentials: credential);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public interface IConsumerService
    {
        ConsumerInfo GetConsumerInfo(string consumerName, string password);
    }

    public class ConsumerService : IConsumerService
    {
        private readonly AppointmentDB _db;

        public ConsumerService(AppointmentDB db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public ConsumerInfo GetConsumerInfo(string consumerName, string password)
        {
            return _db.dbsConsumerInfo.SingleOrDefault(c => c.ConsumerName == consumerName && c.Password == password);
        }
    }
}
