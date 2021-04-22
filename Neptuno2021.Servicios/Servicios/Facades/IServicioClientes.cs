using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Cliente;

namespace Neptuno2021.Servicios.Servicios.Facades
{
    public interface IServicioClientes
    {
        List<ClienteListDto> GetLista();
        void Guardar(ClienteEditDto clienteEditDto);
        bool Existe(ClienteEditDto clienteEditDto);
        void Borrar(int clienteId);
        ClienteEditDto GetClientePorId(int clienteId);
    }
}
