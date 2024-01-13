using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DoctorAppointment.Models;

namespace DoctorAppointment.Controllers
{

    [Authorize]
    public class DoctorsController : ApiController
    {
        private AppointmentDB db = new AppointmentDB();

        // GET: api/Doctors
        public IQueryable<Doctor> GetdbsDoctor()
        {
            return db.dbsDoctor.Include(e => e.Appointments).Include(e => e.Department); 
        }






        // GET: api/Doctors/5
        [ResponseType(typeof(Doctor))]
        public async Task<IHttpActionResult> GetDoctor(int id)
        {
            Doctor doctor = await db.dbsDoctor.Include(e => e.Appointments).Include(e => e.Department).FirstOrDefaultAsync(e => e.DoctorId == id);



            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }






        // PUT: api/Doctors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctor.DoctorId)
            {
                return BadRequest();
            }

            db.Entry(doctor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }





        // POST: api/Doctors
        [ResponseType(typeof(Doctor))]
        public async Task<IHttpActionResult> PostDoctor(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.dbsDoctor.Add(doctor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = doctor.DoctorId }, doctor);
        }





        // DELETE: api/Doctors/5
        [ResponseType(typeof(Doctor))]
        public async Task<IHttpActionResult> DeleteDoctor(int id)
        {
            Doctor doctor = await db.dbsDoctor.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            db.dbsAppointment.RemoveRange(doctor.Appointments);

            db.dbsDoctor.Remove(doctor);
            await db.SaveChangesAsync();

            return Ok(doctor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoctorExists(int id)
        {
            return db.dbsDoctor.Count(e => e.DoctorId == id) > 0;
        }
    }
}