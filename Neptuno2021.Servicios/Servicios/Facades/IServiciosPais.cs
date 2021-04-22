using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Pais;

namespace Neptuno2021.Servicios.Servicios.Facades
{
    public interface IServiciosPais
    {
        List<PaisListDto> GetPaises();
        PaisEditDto GetPaisPorId(int id);
        void Guardar(PaisEditDto pais);
        void Borrar(int id);
        bool Existe(PaisEditDto pais);

    }
}
