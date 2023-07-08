using IDGS901_ApiH.Context;
using IDGS901_ApiH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGS901_ApiH.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
    public class GruposController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GruposController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [HttpGet]//api/<Grupos>
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.Alumnos.ToList());

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id}", Name ="Alumnos")]//api/<Grupos>
        public ActionResult Get(int id)
        {
            try
            {
                var alum = _context.Alumnos.FirstOrDefault(x => x.Id == id);

                return Ok(alum);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        public ActionResult<Alumnos> Post([FromBody]Alumnos alum)
        {
            try
            {
                _context.Alumnos.Add(alum);
                
                _context.SaveChanges();
                return CreatedAtRoute("Alumnos", new {id=alum.Id}, alum);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public ActionResult<Alumnos> Put(int id, [FromBody] Alumnos alum)
        {
            try
            {
                if(alum.Id == id)
                {
                    _context.Entry(alum).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("Alumnos", new { id = alum.Id }, alum);
                }
                else
                {
                    return BadRequest();
                }
                

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Alumnos> Delete(int id)
        {
            try
            {
                var alum = _context.Alumnos.FirstOrDefault(x => x.Id == id);
                if (alum! == null)
                {
                    _context.Remove(alum);
                    _context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


    }
}
