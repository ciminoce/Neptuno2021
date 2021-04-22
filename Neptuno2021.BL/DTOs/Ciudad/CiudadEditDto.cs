using Neptuno2021.BL.DTOs.Pais;

namespace Neptuno2021.BL.DTOs.Ciudad
{
    public class CiudadEditDto
    {
        public int CiudadId { get; set; }
        public string NombreCiudad { get; set; }
        public PaisListDto Pais { get; set; }

    }
}
