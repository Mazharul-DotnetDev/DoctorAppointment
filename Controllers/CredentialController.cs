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
        [Route("~/access")]
        [HttpPost]

        public IHttpActionResult JWT_Token (ConsumerInfo consumer)
        {

            ConsumerInfo loginConsumer;

            using (AppointmentDB db = new AppointmentDB())
            {
                loginConsumer = db.dbsConsumerInfo.SingleOrDefault(c => c.ConsumerName == consumer.ConsumerName && c.Password == consumer.Password);
            }


            if (loginConsumer is null)
            {
                return BadRequest("Invalid credentials");
            }


            var key = ConfigurationManager.AppSettings["JwtKey"];
            var issuer = ConfigurationManager.AppSettings["JwtIssuer"];
            var audience = ConfigurationManager.AppSettings["JwtAudience"];


            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var consumerClaims = new List<Claim>();

            consumerClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            consumerClaims.Add(new Claim(ClaimTypes.Name, loginConsumer.ConsumerName));

            consumerClaims.Add(new Claim(ClaimTypes.Role, loginConsumer.Role.ToString()));


            var token = new JwtSecurityToken(issuer, audience, consumerClaims, expires: DateTime.UtcNow.AddMinutes(30), signingCredentials: credential);


            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(jwt);
        }


    }
}
