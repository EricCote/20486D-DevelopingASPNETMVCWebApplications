﻿using Microsoft.AspNetCore.Mvc;
using CakeStoreApi.Models;

namespace CakeStoreApi.Controllers
{
    public class CakeStoreApiController : ControllerBase
    {
        private IData _data;

        public CakeStoreApiController(IData data)
        {
            _data = data;
        }

        [HttpGet("/api/CakeStore")]
        public ActionResult<List<CakeStore>> GetAll()
        {
            return _data.CakesInitializeData();
        }

        [HttpGet("/api/CakeStore/{id}", Name = "GetCake")]
        public ActionResult<CakeStore> GetById(int? id)
        {
            var item = _data.GetCakeById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
