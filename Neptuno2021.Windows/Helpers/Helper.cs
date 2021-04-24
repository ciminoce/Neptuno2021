using System.Collections.Generic;
using System.Windows.Forms;
using Neptuno2021.BL.DTOs.Categoria;
using Neptuno2021.BL.DTOs.Ciudad;
using Neptuno2021.BL.DTOs.Cliente;
using Neptuno2021.BL.DTOs.DetalleVenta;
using Neptuno2021.BL.DTOs.Pais;
using Neptuno2021.BL.DTOs.Producto;
using Neptuno2021.BL.DTOs.Proveedor;
using Neptuno2021.Servicios.Servicios;
using Neptuno2021.Servicios.Servicios.Facades;

namespace Neptuno2021.Windows.Helpers
{
    public class Helper
    {
        public static void CargarDatosComboPaises(ref ComboBox combo)
        {
            IServiciosPais serviciosPais = new ServiciosPaises();
            var lista = serviciosPais.GetPaises();
            var defaultPais = new PaisListDto
            {
                PaisId = 0,
                NombrePais = "Seleccione País"
            };
            lista.Insert(0, defaultPais);
            combo.DataSource = lista;
            combo.ValueMember = "PaisId";
            combo.DisplayMember = "NombrePais";
            combo.SelectedIndex = 0;

        }

        internal static void CargarDatosComboCiudades(ref ComboBox combo, PaisListDto paisListDto)
        {
            IServicioCiudades serviciosCiudades = new ServicioCiudades();
            var lista = serviciosCiudades.GetLista(paisListDto);
            var defaultCiudad = new CiudadListDto
            {
                CiudadId = 0,
                NombreCiudad = "Seleccione Ciudad"
            };
            lista.Insert(0, defaultCiudad);
            combo.DataSource = lista;
            combo.ValueMember = "CiudadId";
            combo.DisplayMember = "NombreCiudad";
            combo.SelectedIndex = 0;

        }
        internal static void CargarDatosComboCategorias(ref ComboBox combo)
        {
            IServiciosCategorias servicio = new ServiciosCategorias();
            var lista = servicio.GetLista();
            var defaultCategoria = new CategoriaListDto()
            {
                CategoriaId = 0,
                NombreCategoria = "Seleccione Categoria"
            };
            lista.Insert(0, defaultCategoria);
            combo.DataSource = lista;
            combo.ValueMember = "CategoriaId";
            combo.DisplayMember = "NombreCategoria";
            combo.SelectedIndex = 0;

        }
        internal static void CargarDatosComboProveedores(ref ComboBox combo)
        {
            IServicioProveedores servicio = new ServicioProveedores();
            var lista = servicio.GetLista();
            var defaultProveedor = new ProveedorListDto()
            {
                ProveedorId = 0,
                NombreCompania = "Seleccione Proveedor"
            };
            lista.Insert(0, defaultProveedor);
            combo.DataSource = lista;
            combo.ValueMember = "ProveedorId";
            combo.DisplayMember = "NombreCompania";
            combo.SelectedIndex = 0;

        }

        public static void CargarDatosComboClientes(ref ComboBox combo)
        {
            IServicioClientes servicio = new ServicioClientes();
            var lista = servicio.GetLista(null,null);
            var defaultCliente = new ClienteListDto()
            {
                ClienteId = 0,
                NombreCompania = "Seleccione Cliente"
            };
            lista.Insert(0, defaultCliente);
            combo.DataSource = lista;
            combo.ValueMember = "ClienteId";
            combo.DisplayMember = "NombreCompania";
            combo.SelectedIndex = 0;

        }

        public static void CargarDatosComboProductos(ref ComboBox combo, int? categoriaId)
        {
            IServicioProductos servicio = new ServicioProductos();
            var lista = servicio.GetLista(categoriaId);
            var defaultProducto = new ProductoListDto()
            {
                ProductoId = 0,
                NombreProducto = "Seleccione Producto"
            };
            lista.Insert(0, defaultProducto);
            combo.DataSource = lista;
            combo.ValueMember = "ProductoId";
            combo.DisplayMember = "NombreProducto";
            combo.SelectedIndex = 0;

        }

        public static List<DetalleVentaListDto> ConstruirListaItemsListDto(List<DetalleVentaEditDto> itemsEditDto)
        {
            var listaDto = new List<DetalleVentaListDto>();
            foreach (var item in itemsEditDto)
            {
                var itemDto = new DetalleVentaListDto()
                {
                    DetalleVentaId = item.DetalleVentaId,
                    Producto = item.Producto.NombreProducto,
                    PrecioUnitario = item.Precio,
                    Cantidad = item.Cantidad
                };
                listaDto.Add(itemDto);
            }

            return listaDto;
        }
    }
}
