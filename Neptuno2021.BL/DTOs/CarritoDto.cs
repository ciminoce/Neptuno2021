using System.Collections.Generic;
using System.Linq;
using Neptuno2021.BL.DTOs.DetalleVenta;

namespace Neptuno2021.BL.DTOs
{
    public class CarritoDto
    {
        public List<DetalleVentaEditDto> ItemsVenta { get; set; } = new List<DetalleVentaEditDto>();

        public CarritoDto()
        {
            
        }

        public void AgregarAlCarrito(DetalleVentaEditDto item)
        {
            /*Se fija si hay un item del mismo producto
             en el carrito utilizando el método SingleOrDefault de linq*/
            var itemEnCarrito = ItemsVenta
                .SingleOrDefault(iv => iv.Producto.ProductoId == item.Producto.ProductoId);
            if (itemEnCarrito==null)
            {
                /*Si no hay un producto igual
                 entonces agrego el item al carrito*/
                ItemsVenta.Add(item);
            }
            else
            {
                /*Si el mismo existe, entonces
                 le agrego la cantidad que compro a la
                existente*/
                itemEnCarrito.Cantidad += item.Cantidad;
            }
        }

        public void BorrarDelCarrito(DetalleVentaEditDto item)
        {
            /*Borra todos los elementos de la lista
             que coinciden con el id del producto que me pasan en el item*/
            ItemsVenta.RemoveAll(i => i.Producto.ProductoId == item.Producto.ProductoId);
        }

        public List<DetalleVentaEditDto> GetItems()
        {
            /*Devuelve la lista de items */
            return ItemsVenta;
        }

        public void VaciarCarrito()
        {
            ItemsVenta.Clear();
        }

        public decimal InformarTotal()
        {
            return ItemsVenta.Sum(i =>(decimal) i.Cantidad * i.Precio);
        }
    }
}
