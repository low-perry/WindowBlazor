using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowBlazor_Business.Repository.IRepository;
using WindowBlazor_DataAccess;
using WindowBlazor_DataAccess.Data;
using WindowBlazor_Models;

namespace WindowBlazor_Business.Repository
{
    public class WindowRepository : IWindowRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public WindowRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<WindowDTO> Create(WindowDTO modelDTO)
        {
            var obj = _mapper.Map<WindowDTO, Window>(modelDTO);
            

            var addedObject = _db.Windows.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Window, WindowDTO>(addedObject.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Windows.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                _db.Windows.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<WindowDTO> Get(int id)
        {
            var obj = await _db.Windows.Include(x => x.SubElements).FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Window, WindowDTO>(obj);
            }
            return new WindowDTO();
        }

        public async Task<IEnumerable<WindowDTO>> GetAll()
        {
            return  _mapper.Map<IEnumerable<Window>, IEnumerable<WindowDTO>>(_db.Windows.Include(x => x.SubElements));
        }

        public async Task<WindowDTO> Update(WindowDTO modelDTO)
        {
            var objFromDb = await _db.Windows.FirstOrDefaultAsync(x => x.Id == modelDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = modelDTO.Name;
                objFromDb.QuantityOfWindows = modelDTO.QuantityOfWindows;
                objFromDb.TotalSubElements = modelDTO.TotalSubElements;
                _db.Windows.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Window, WindowDTO>(objFromDb);
            }
            return modelDTO;
        }
    }
}
