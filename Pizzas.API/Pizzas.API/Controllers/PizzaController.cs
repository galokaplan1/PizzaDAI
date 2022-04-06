using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;


namespace Pizzas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll(){
            List<Pizza> ListaPizzas=PizzaServices.SelectAll();
            return Ok(ListaPizzas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            Pizza unaPizza=PizzaServices.Select(id);
            if(unaPizza==null){
                return NotFound();
            }
            return Ok(unaPizza);
        }

        [HttpPost]
        public IActionResult Create (Pizza unaPizza){
            int Insertado;
            Insertado=PizzaServices.Insert(unaPizza);
            if(Insertado==0){
                return BadRequest();
            }
            else{
                return Ok(unaPizza);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza unaPizza){
            int cambiado;
            if(id!=unaPizza.Id){
                return BadRequest();
            }
            Pizza PizzaExistente=PizzaServices.Select(id);
            if(PizzaExistente==null){
                return NotFound();
            }


            cambiado=PizzaServices.Update(unaPizza);
            if(cambiado==0){
                return BadRequest();
            }
            else{
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id){
            Pizza PizzaExistente=PizzaServices.Select(id);
            if(PizzaExistente==null){
                return NotFound();
            }
            PizzaServices.Delete(id);
            return Ok();
        }
    }
}
