using System;

namespace Neptuno2021.BL.DTOs.Cliente
{
    public class ClienteListDto:ICloneable
    {
        public int ClienteId { get; set; }
        public string NombreCompania { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
