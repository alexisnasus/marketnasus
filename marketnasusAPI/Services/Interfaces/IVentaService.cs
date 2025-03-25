using marketnasusAPI.DTOs;

namespace marketnasusAPI.Services.Interfaces
{
    public interface IVentaService
    {
        Task ProcesarVentaAsync(VentaDTO ventaDto);
        Task AnularVentaAsync(int id);

    }
}
