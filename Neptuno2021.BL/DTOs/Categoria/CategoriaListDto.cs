using System;
using Neptuno2021.BL.DTOs.Ciudad;

namespace Neptuno2021.BL.DTOs.Categoria
{
    public class CategoriaListDto:ICloneable
    {
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }

        public Object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
