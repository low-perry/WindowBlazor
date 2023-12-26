using WindowBlazor_Models;

namespace WindowBlazor_Client.Service.IService
{
    public interface IWindowService
    {
        public Task<IEnumerable<WindowDTO>> GetAll();
        public Task<WindowDTO> Get(int id);
    }
}
