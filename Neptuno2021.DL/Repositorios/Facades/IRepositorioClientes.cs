using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Cliente;
using Neptuno2021.BL.Entidades;

namespace Neptuno2021.DL.Repositorios.Facades
{
    public interface IRepositorioClientes
    {
        List<ClienteListDto> GetLista();
        void Guardar(Cliente cliente);
        bool Existe(Cliente cliente);
        void Borrar(int clienteId);
        ClienteEditDto GetClientePorId(int id);
    }
}
