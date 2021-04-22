using System;

namespace Neptuno2021.BL.DTOs.Proveedor
{
    public class ProveedorListDto:ICloneable

    {
    public int ProveedorId { get; set; }
    public string NombreCompania { get; set; }
    public string Pais { get; set; }
    public string Ciudad { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
    }
}
