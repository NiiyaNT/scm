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
    public class EmpleadoController : ControllerBase
    {
        private EmpleadoRepository empleadoRepository;
        private IMapper _mapper;
        private ScmContext _context;
        public EmpleadoController(EmpleadoRepository repository, ScmContext context, IMapper mapper)
        {
            empleadoRepository = repository;
            _context = context;
            _mapper = mapper;
            Console.WriteLine($"asdasdsad {repository.ToString()}");
        }
        
        [HttpPost]
        public IActionResult Agregar([FromBody] EmpleadoDto model){ //Dto

            try{
                Empleado emp = _mapper.Map<Empleado>(model);

                //var emp = new Empleado{Nombre = model.Nombre, Tipo = model.Tipo, NumeroContacto = model.NumeroContacto};
                
                empleadoRepository.Insert(emp);
                _context.SaveChanges();

                var bugToResponse = _mapper.Map<EmpleadoDto>(emp);
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
            var emms = empleadoRepository.GetAll();
            var emmsdto = _mapper.Map<List<EmpleadoDto>>(emms);
            return Ok(emmsdto);
        }

        [HttpGet("id")]
        [Authorize]
        [ProducesResponseType(400, Type = typeof(IEnumerable<Empleado>))]
        public IActionResult GetEmpleadoID(int id)
        {
            Empleado emp = empleadoRepository.GetById(id);
            if(emp == null)
                return NotFound();
            var emDTO = _mapper.Map<EmpleadoDto>(emp);
            return Ok(emDTO);
        }
    }
}
