using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTutorial.Data;
using CoreTutorial.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreTutorial.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IArtRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IArtRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        //[HttpGet]
        //public JsonResult Get()
        //{
        //    try
        //    {
        //        return Json(_repository.GetAllProducts());
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Failed to get products: {ex}");
        //        return Json("Bad Request");
        //    }
        //}

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products");
            }
        }
    }
}