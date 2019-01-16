using Microsoft.AspNetCore.Mvc;
using SpeedRun.ServiceGeneric.Interface;
using System.Collections.Generic;

namespace SpeedRun.ControllerGeneric
{
    public class ControllerGeneric<T> : ControllerBase where T : class
    {
        protected IServiceGeneric<T> service;

        public ControllerGeneric(IServiceGeneric<T> service)
        {
            this.service = service;
        }

        [HttpGet]
        public virtual List<T> GetAll()
        {
            return service.GetAll();
        }

        [HttpPost]
        public virtual IActionResult Add([FromBody] T obj)
        {
            if (obj == null) return BadRequest("Invalid form");
            T objTmp = service.Add(obj);
            if (objTmp != null)
            {
                return Ok(objTmp);
            }

            return BadRequest($"{typeof(T)} already exist !");
        }
    }
}
