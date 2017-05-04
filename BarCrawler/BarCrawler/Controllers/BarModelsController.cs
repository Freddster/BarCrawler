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
using BarCrawler.Models;
using DataAccessLogic.UnitOfWork;
using Microsoft.SqlServer.Server;

namespace BarCrawler.Controllers
{
    public class BarModelsController : ApiController
    {
        private BarCrawlerContext db = new BarCrawlerContext();
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: api/BarModels
        public IQueryable<BarModel> GetBarModels()
        {
            //return unitOfWork.BarRepository.GetAllBars();
            //return unitOfWork.BarRepository.GetAllBars();
            return db.BarModels;
        }

        // GET: api/BarModels/5
        [ResponseType(typeof(BarModel))]
        public async Task<IHttpActionResult> GetBarModel(int id)
        {
            BarModel barModel = await db.BarModels.FindAsync(id);
            if (barModel == null)
            {
                return NotFound();
            }

            return Ok(barModel);
        }

        // PUT: api/BarModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBarModel(int id, BarModel barModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != barModel.BarID)
            {
                return BadRequest();
            }

            db.Entry(barModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarModelExists(id))
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

        // POST: api/BarModels
        [ResponseType(typeof(BarModel))]
        public async Task<IHttpActionResult> PostBarModel(BarModel barModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BarModels.Add(barModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = barModel.BarID }, barModel);
        }

        // DELETE: api/BarModels/5
        [ResponseType(typeof(BarModel))]
        public async Task<IHttpActionResult> DeleteBarModel(int id)
        {
            BarModel barModel = await db.BarModels.FindAsync(id);
            if (barModel == null)
            {
                return NotFound();
            }

            db.BarModels.Remove(barModel);
            await db.SaveChangesAsync();

            return Ok(barModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BarModelExists(int id)
        {
            return db.BarModels.Count(e => e.BarID == id) > 0;
        }
    }
}