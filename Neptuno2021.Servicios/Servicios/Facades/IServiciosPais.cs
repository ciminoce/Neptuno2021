using System.Collections.Generic;
using Neptuno2021.BL.Entidades;

namespace Neptuno2021.Servicios.Servicios.Facades
{
    public interface IServiciosPais
    {
        List<Pais> GetPaises();
        Pais GetPaisPorId(int id);
        void Guardar(Pais pais);
        void Borrar(int id);
        bool Existe(Pais pais);

    }
}
