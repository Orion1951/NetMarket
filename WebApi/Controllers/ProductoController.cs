using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
      private readonly IGenericRepository<Producto> _productoRepository;

      public ProductoController(IGenericRepository<Producto> productoRepository)
        {
         _productoRepository = productoRepository;
      }
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var spec = new ProductoWithCategoriasAndMarcaSpecification();
            var productos = await _productoRepository.GetAllWithSpec(spec);
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var spec = new ProductoWithCategoriasAndMarcaSpecification(id);
            var producto = await _productoRepository.GetByIdWithSpec(spec);
         if (producto == null)
	{  
            return NotFound(new CodeResponse(404));
	}
        }
    }
}
