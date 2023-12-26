using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowBlazor_Models;

namespace WindowBlazor_Business.Repository.IRepository
{
    public interface ISubElementRepository
    {
        public Task<SubElementDTO> Create(SubElementDTO modelDTO);
        public Task<SubElementDTO> Update(SubElementDTO modelDTO);
        public Task<int> Delete(int id);
        public Task<SubElementDTO> Get(int id);
        public Task<IEnumerable<SubElementDTO>> GetAll(int? id = null);

    }
}
