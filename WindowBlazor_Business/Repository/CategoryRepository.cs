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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Create(CategoryDTO modelDTO)
        {
            var obj = _mapper.Map<CategoryDTO, Category>(modelDTO);
            obj.CreatedDate = DateTime.Now;

            var addedObject = _db.Categories.Add(obj);
            await _db.SaveChangesAsync();
            
            return _mapper.Map<Category, CategoryDTO>(addedObject.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                _db.Categories.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CategoryDTO> Get(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
               return _mapper.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public async Task<CategoryDTO> Update(CategoryDTO modelDTO)
        {
            var objFromDb = await _db.Categories.FirstOrDefaultAsync(x => x.Id == modelDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = modelDTO.Name;
                _db.Categories.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(objFromDb);
            }
            return modelDTO;
        }
    }
}
