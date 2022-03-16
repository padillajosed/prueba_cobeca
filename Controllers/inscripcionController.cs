using apiInscripcion.Context;
using apiInscripcion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiInscripcion.Controllers
{
    [Route("api/inscripcion")]
    [ApiController]
    public class inscripcionController : ControllerBase
    {
        private readonly InsDBContext context;
        public inscripcionController(InsDBContext context)
        {
            this.context = context;
        }

        // GET: api/<inscripcionController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.inscripcion.ToList());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<inscripcionController>/5
        [HttpGet("{id}", Name ="GetInscripcion")]
        public ActionResult Get(int id)
        {
            try
            {
                var inscripcion = context.inscripcion.FirstOrDefault(f => f.id == id);
                return Ok(inscripcion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<inscripcionController>
        [HttpPost]
        public ActionResult Post([FromBody] Inscripcion inscripcion)
        {
            try
            {
                context.inscripcion.Add(inscripcion);
                context.SaveChanges();
                return CreatedAtRoute("GetInscripcion", new { id = inscripcion.id }, inscripcion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<inscripcionController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Inscripcion inscripcion)
        {
            try
            {
                if(inscripcion.id == id)
                {
                    context.Entry(inscripcion).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetInscripcion", new { id = inscripcion.id }, inscripcion);
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

        // DELETE api/<inscripcionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var inscripcion = context.inscripcion.FirstOrDefault(f => f.id == id);
                if(inscripcion != null)
                {
                    context.inscripcion.Remove(inscripcion);
                    context.SaveChanges();
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
