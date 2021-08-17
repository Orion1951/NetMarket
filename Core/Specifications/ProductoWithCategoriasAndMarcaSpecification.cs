using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
   public class ProductoWithCategoriasAndMarcaSpecification : BaseSpecification<Producto>
   {
      public ProductoWithCategoriasAndMarcaSpecification(string sort)
      {
         AddInclude(p => p.Categoria);
         AddInclude(p => p.Marca);
         if (!string.IsNullOrEmpty(sort))
         {
            switch (sort)
            {
               case "nombreAsc":
                  AddOrderBy(p => p.Nombre);
                  break;
               case "NombreDesc":
                  AddOrderByDescending(p => p.Nombre);
                  break;
               case "precioAsc":
                  AddOrderBy(p => p.Precio);
                  break;
               case "precioDesc":
                  AddOrderByDescending(p => p.Precio);
                  break;
               case "descripcionAsc":
                  AddOrderBy(p => p.Descripcion);
                  break;
               case "descripcionDesc":
                  AddOrderByDescending(p => p.Descripcion);
                  break;
               case "marcaAsc":
                  AddOrderBy(p => p.Marca);
                  break;
               case "marcaDesc":
                  AddOrderByDescending(p => p.Marca);
                  break;
               default:
                  AddOrderBy(p => p.Nombre);
                  break;
            }
         }
      }

      public ProductoWithCategoriasAndMarcaSpecification(int id) : base(x => x.Id == id)
      {
         AddInclude(p => p.Categoria);
         AddInclude(p => p.Marca);
      }
   }
}
