using System;
using Microsoft.AspNetCore.Mvc;
using SpeedRun.ServiceGeneric.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

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

        [HttpGet("{id}")]
        public virtual T Get(Guid id)
        {
            PropertyInfo _idProperty = typeof(T).GetProperty("Id");
            return service.Get(x => (Guid)_idProperty.GetValue(x) == id);
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
