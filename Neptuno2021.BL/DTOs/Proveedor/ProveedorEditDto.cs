using Neptuno2021.BL.DTOs.Ciudad;
using Neptuno2021.BL.DTOs.Pais;

namespace Neptuno2021.BL.DTOs.Proveedor
{
    public class ProveedorEditDto
    {
        public int ProveedorId { get; set; }
        public string NombreCompania { get; set; }
        public string Direccion { get; set; }
        public string CodPostal { get; set; }
        public PaisListDto Pais { get; set; }
        public CiudadListDto Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

    }
}
