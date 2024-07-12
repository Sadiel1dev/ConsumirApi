using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS;
using AutoMapper;
using Core.Entidades;
using Infraestructura.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VillaApiController : ControllerBase
    {
        public readonly ILogger<VillaApiController> Logger;
        public readonly Contexto Contexto ;
        public readonly IMapper Mapper ;

        public VillaApiController(ILogger<VillaApiController> logger,Contexto contexto,IMapper mapper)
        {
            Logger = logger;
            Contexto = contexto;
            Mapper = mapper;
        }

        

          [HttpGet]
         public async Task<ActionResult<List<VillaDto>>> GetVillas(){
            Logger.LogInformation("Obtener Villas");

            var villalist = await Contexto.Villas.ToListAsync();

            return  Ok(Mapper.Map<List<VillaDto>>(villalist));
         }
         [HttpGet("id")]
         public async Task<ActionResult<List<VillaDto>>> GetVilla(int id){
            if (id==0)
            {
                return BadRequest();
            }
            var villa =await Contexto.Villas.FirstOrDefaultAsync(v=>v.Id==id);

            if (villa==null)
            return NotFound();

            return Ok(Mapper.Map<VillaDto>(villa));
         }
          [HttpPost] 
         public async Task<ActionResult<VillaDto>> CrearVilla(VillaCreateDto villa){
            if (ModelState.IsValid==false)
            {
                return BadRequest(ModelState);
            }
            var modelo=Mapper.Map<Villa>(villa);
            await Contexto.Villas.AddAsync(modelo);
            await Contexto.SaveChangesAsync();

            return CreatedAtRoute("GetVilla",new{id=modelo.Id},modelo);
         }
         [HttpPut("id")]
         public async Task<IActionResult> UpdateVilla(VillaUpdateDto villa){


            var modelo=Mapper.Map<Villa>(villa);
            Contexto.Update(modelo);
            await Contexto.SaveChangesAsync();

            return NoContent();
         }
         [HttpDelete("id")]
         public async Task<IActionResult> RemoveVilla(VillaDto villa){

             var modelo =await Contexto.Villas.FirstOrDefaultAsync(v=>v.Id==villa.Id);
             if (modelo==null)
             return NotFound(ModelState);

             Contexto.Villas.Remove(modelo);
             await Contexto.SaveChangesAsync();

             return NoContent();
         }  
    }
}