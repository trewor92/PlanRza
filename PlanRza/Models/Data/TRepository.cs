using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using PlanRza.Models.Enums;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography.X509Certificates;

namespace PlanRza.Models.Data
{
    public abstract class TRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected DbSet<T> _dbset;
        protected ApplicationDbContext _context;

        protected TRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<T> AddAsync(T t)
        {
            _dbset.Add(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public async Task<T> DeleteAsync(int Id)
        {
            T current = await FindAsync(Id);
            if (current != null)
            {
                _dbset.Remove(current);
                await _context.SaveChangesAsync();
            }
            return current;
        }

        public Task EditTAsync(T newT, int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> FindAsync(int Id)
        {
            return await _dbset
               .FirstOrDefaultAsync(b => b.Id == Id);
        }

        
        public virtual async Task<List<T>> GetListAsync()
        {
            return await _dbset.ToListAsync();
        }
        
        public virtual List<dynamic> FindFieldVariants(string fieldName)
        {
            var variants = _dbset
                .GroupBy(fieldName).Select("Key").ToDynamicList();

            return variants;
        }
    
        public abstract Task<T> DeepFindAsync(int Id);

        public abstract Task<List<dynamic>> DeepFindVariantsAsync(int Id, string variantsFieldName);
    }
}
