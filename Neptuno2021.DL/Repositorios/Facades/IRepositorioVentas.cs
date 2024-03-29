﻿using System;
using System.Collections.Generic;
using Neptuno2021.BL.DTOs.Venta;
using Neptuno2021.BL.Entidades;

namespace Neptuno2021.DL.Repositorios.Facades
{
    public interface IRepositorioVentas
    {
        List<VentaListDto> GetLista(int? clienteId, DateTime fechaInicial, DateTime fechaFinal);
        void Guardar(Venta ventaDto);
        VentaEditDto GetVentaPorId(int id);

    }
}
