using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Ciudad;
using Neptuno2021.BL.Entidades;

namespace Neptuno2021.DL.Repositorios.Facades
{
    public interface IRepositorioCiudades
    {
        List<CiudadListDto> GetLista(BL.DTOs.Pais.PaisListDto paisDto);
        void Guardar(Ciudad ciudad);
        bool Existe(Ciudad ciudad);

        void Borrar(int id);
        CiudadEditDto GetCiudadPorId(int id);
    }
}
