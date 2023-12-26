using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowBlazor_Models;

namespace WindowBlazor_Business.Repository.IRepository
{
    public interface IWindowRepository
    {
        public Task<WindowDTO> Create(WindowDTO modelDTO);
        public Task<WindowDTO> Update(WindowDTO modelDTO);
        public Task<int> Delete(int id);
        public Task<WindowDTO> Get(int id);
        public Task<IEnumerable<WindowDTO>> GetAll();

    }
}
