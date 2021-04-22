using System;

namespace Neptuno2021.BL.DTOs.Pais
{
    public class PaisListDto:ICloneable
    {
        public int PaisId { get; set; }
        public string NombrePais { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
