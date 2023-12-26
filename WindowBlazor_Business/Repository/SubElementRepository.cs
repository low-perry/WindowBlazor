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
    public class SubElementRepository : ISubElementRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public SubElementRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<SubElementDTO> Create(SubElementDTO modelDTO)
        {
            var obj = _mapper.Map<SubElementDTO, SubElement>(modelDTO);
            

            var addedObject = _db.SubElements.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<SubElement, SubElementDTO>(addedObject.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.SubElements.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                _db.SubElements.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<SubElementDTO> Get(int id)
        {
            var obj = await _db.SubElements.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<SubElement, SubElementDTO>(obj);
            }
            return new SubElementDTO();
        }

        public async Task<IEnumerable<SubElementDTO>> GetAll(int? id = null)
        {
            if (id != null && id > 0)
            {
                return _mapper.Map<IEnumerable<SubElement>, IEnumerable<SubElementDTO>>
                    (_db.SubElements.Where(x => x.WindowId == id));
            }
            else
            {
                return _mapper.Map<IEnumerable<SubElement>, IEnumerable<SubElementDTO>>(_db.SubElements);
            }
           
        }

        public async Task<SubElementDTO> Update(SubElementDTO modelDTO)
        {
            var objFromDb = await _db.SubElements.FirstOrDefaultAsync(x => x.Id == modelDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Element = modelDTO.Element;
                objFromDb.Type = modelDTO.Type;
                objFromDb.Width = modelDTO.Width;
                objFromDb.Height = modelDTO.Height;
                objFromDb.WindowId = modelDTO.WindowId;
                _db.SubElements.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<SubElement, SubElementDTO>(objFromDb);
            }
            return modelDTO;
        }
    }
}
