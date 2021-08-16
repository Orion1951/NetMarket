using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Errors;

namespace WebApi.Controllers
{
    public class ProductoController : BaseApiController
    {
      private readonly IGenericRepository<Producto> _productoRepository;
      private readonly IMapper _mapper;

      public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
         _productoRepository = productoRepository;
         _mapper = mapper;
      }
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var spec = new ProductoWithCategoriasAndMarcaSpecification();
            var productos = await _productoRepository.GetAllWithSpec(spec);
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> GetProducto(int id)
        {
            var spec = new ProductoWithCategoriasAndMarcaSpecification(id);
            var producto = await _productoRepository.GetByIdWithSpec(spec);
         if (producto == null)
          {  
            return NotFound(new CodeErrorResponse(404));
          }
         return _mapper.Map<Producto, ProductoDTO>(producto);
        }
    }
}
