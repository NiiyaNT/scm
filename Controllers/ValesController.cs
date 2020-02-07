using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scm.Domain;
using Scm.Data;
using Scm.Controllers.Dtos;
using Scm.Data.Repositories;
using AutoMapper;
using System.Security.Claims;
using Scm.Infrastructure.ManagedResponses;

namespace Scm.Controllers
{
    [ApiController]    
    [Route("api/[controller]")]
    public class ValesController : ControllerBase
    {
        private ValeRepository ValeRepository;
        private IMapper _mapper;
        private ScmContext _context;
        public ValesController(ValeRepository repository, ScmContext context, IMapper mapper)
        {
            ValeRepository = repository;
            _context = context;
            _mapper = mapper;
            Console.WriteLine($"asdasdsad {repository.ToString()}");
        }
        
        [HttpPost]
        public IActionResult Agregar([FromBody] ValeDto model){ //Dto

            try{
                Vale emp = _mapper.Map<Vale>(model);

                //var emp = new Empleado{Nombre = model.Nombre, Tipo = model.Tipo, NumeroContacto = model.NumeroContacto};
                
                ValeRepository.Insert(emp);
                _context.SaveChanges();

                var bugToResponse = _mapper.Map<ValeDto>(emp);
                return Ok(bugToResponse);
            }
            catch(Exception ex){
                var errorResponse = 
                new ManagedErrorResponse(ManagedErrorCode.Exception,"hay errores",ex);
                return BadRequest(errorResponse);
            }
        }
         [HttpPost("Modificar")]
        public IActionResult Modificar([FromBody] ValeDto model){ //Dto

            try{
                Vale emp = _mapper.Map<Vale>(model);

                //var emp = new Empleado{Nombre = model.Nombre, Tipo = model.Tipo, NumeroContacto = model.NumeroContacto};
                
                ValeRepository.Update(emp);
                _context.SaveChanges();

                var bugToResponse = _mapper.Map<ValeDto>(emp);
                return Ok(bugToResponse);
            }
            catch(Exception ex){
                var errorResponse = 
                new ManagedErrorResponse(ManagedErrorCode.Exception,"hay errores",ex);
                return BadRequest(errorResponse);
            }
        }
        


//GETTERS
        [HttpGet("all")]
      //  [Authorize]
        [ProducesResponseType(400, Type = typeof(IEnumerable<Empleado>))]
        public IActionResult Get(){
            var emms = ValeRepository.GetAll();
            var emmsdto = _mapper.Map<List<ValeDto>>(emms);
            return Ok(emmsdto);
        }

        [HttpGet("id")]
        [Authorize]
        [ProducesResponseType(400, Type = typeof(IEnumerable<Vale>))]
        public IActionResult GetEmpleadoID(int id)
        {
            Vale emp = ValeRepository.GetById(id);
            if(emp == null)
                return NotFound();
            var emDTO = _mapper.Map<ValeDto>(emp);
            return Ok(emDTO);
        }
    }
}
