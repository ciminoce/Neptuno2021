namespace Neptuno2021.BL.Entidades
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string NombreCompania { get; set; }
        public string Direccion { get; set; }
        public string CodPostal { get; set; }
        public Pais Pais { get; set; }
        public Ciudad Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

    }
}
