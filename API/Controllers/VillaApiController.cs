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
using Core.Repositorio;
using API.Helper;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VillaApiController : ControllerBase
    {
        public readonly ILogger<VillaApiController> Logger;
        public readonly IVillaRepositorio repo ;
        public readonly IMapper Mapper ;

        protected ApiResponse apiResponse;

      

        public VillaApiController(ILogger<VillaApiController> logger,IVillaRepositorio repo,IMapper mapper)
        {
            Logger = logger;
            this.repo = repo;
            Mapper = mapper;
            apiResponse=new();
        }

        

          [HttpGet]
         public async Task<ActionResult<ApiResponse>> GetVillas(){
           
           try
           {
            Logger.LogInformation("Obtener Villas");
            var villalist = await repo.GetAll();
            apiResponse.Resultado=Mapper.Map<List<VillaDto>>(villalist);
            apiResponse.statusCode=HttpStatusCode.OK;
            return  Ok(apiResponse);
           }
           catch (Exception ex)
           {
             apiResponse.IsExitoso=false;
             apiResponse.ErrorMesagges=new List<string>(){ex.ToString()};
           }
            return apiResponse;
            
         }
         [HttpGet("id")]
         public async Task<ActionResult<ApiResponse>> GetVilla(int id){
            
            try
            {
             if (id==0)
            {   
                apiResponse.statusCode=HttpStatusCode.BadRequest;
                return BadRequest(apiResponse);
            }
            var villa =await repo.Get(v=>v.Id==id);

            if (villa==null){
                apiResponse.statusCode=HttpStatusCode.NotFound;
                return NotFound(apiResponse);
            }
            

            apiResponse.Resultado=Mapper.Map<VillaDto>(villa);
            apiResponse.statusCode=HttpStatusCode.OK;
            return Ok(apiResponse);
            }
            catch (Exception ex)
            {
            apiResponse.IsExitoso=false;
             apiResponse.ErrorMesagges=new List<string>(){ex.ToString()};
           }
            return apiResponse;
          
           
         }
          [HttpPost] 
         public async Task<ActionResult<ApiResponse>> CrearVilla(VillaCreateDto villa){
            
            try
            {
                if (ModelState.IsValid==false)
            {
                return BadRequest(ModelState);
            }
            var modelo=Mapper.Map<Villa>(villa);
            modelo.FechaCreacion=DateTime.Now;
            modelo.FechaActualizacion=DateTime.Now;
            await repo.Crear(modelo);
            apiResponse.Resultado=modelo;
            apiResponse.statusCode=HttpStatusCode.Created;

            return CreatedAtRoute("GetVilla",new{id=modelo.Id},apiResponse);
            }
            catch (System.Exception ex)
            {
              apiResponse.IsExitoso=false;
             apiResponse.ErrorMesagges=new List<string>(){ex.ToString()};
           }
            return apiResponse;
            
            
         }
         [HttpPut("id")]
         public async Task<IActionResult> UpdateVilla(VillaUpdateDto villa){


            var modelo=Mapper.Map<Villa>(villa);
            await repo.Actualizar(modelo);
            apiResponse.statusCode=HttpStatusCode.NoContent;
            return Ok(apiResponse);
         }
         [HttpDelete("id")]
         public async Task<IActionResult> RemoveVilla(VillaDto villa){

            try
            {
             var modelo =await repo.Get(v=>v.Id==villa.Id);
             if (modelo==null)
             return NotFound(ModelState);

             await repo.Remove(modelo);
             apiResponse.statusCode=HttpStatusCode.NoContent;
             return Ok(apiResponse);
            }
            catch (System.Exception ex)
            {
                apiResponse.IsExitoso=false;
             apiResponse.ErrorMesagges=new List<string>(){ex.ToString()};
           }
            return BadRequest(apiResponse);


             
         }  
    }
}