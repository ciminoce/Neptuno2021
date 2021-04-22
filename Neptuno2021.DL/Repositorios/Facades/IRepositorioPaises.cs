using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Pais;
using Neptuno2021.BL.Entidades;

namespace Neptuno2021.DL.Repositorios.Facades
{
    public interface IRepositorioPaises
    {
        List<PaisListDto> GetPaises();
        PaisEditDto GetPaisPorId(int id);
        void Guardar(Pais pais);
        void Borrar(int id);
        bool Existe(Pais pais);

    }
}
