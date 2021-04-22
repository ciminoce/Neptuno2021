using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Ciudad;
using Neptuno2021.BL.Entidades;

namespace Neptuno2021.Servicios.Servicios.Facades
{
    public interface IServicioCiudades
    {
        List<CiudadListDto> GetLista(BL.DTOs.Pais.PaisListDto paisDto);
        void Guardar(CiudadEditDto ciudadEditDto);
        bool Existe(CiudadEditDto ciudad);

        void Borrar(int ciudadDtoCiudadId);
        CiudadEditDto GetCiudadPorId(int id);
    }
}
