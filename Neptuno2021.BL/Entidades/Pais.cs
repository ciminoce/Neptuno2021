using System;

namespace Neptuno2021.BL.Entidades
{
    public class Pais:ICloneable
    {
        public int PaisId { get; set; }
        public string NombrePais { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
