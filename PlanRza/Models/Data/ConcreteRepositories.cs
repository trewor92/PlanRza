using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using PlanRza.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using System.Runtime.CompilerServices;

namespace PlanRza.Models.Data
{
    public class BranchesRepository:TRepository<Branch>
    {
        public BranchesRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            base._dbset = _context.Branches;
        }

        public async override Task<Branch> DeepFindAsync(int Id)
        {
            return await base._dbset.Include(x => x.Substations).FirstOrDefaultAsync(b => b.Id == Id);
        }

        public async override Task<List<dynamic>> DeepFindVariantsAsync(int Id, string variantsFieldName)
        {
            return await base._dbset.Include(x => x.Substations)
                .Where(b => b.Id == Id)
                .SelectMany(x => x.Substations)
                .GroupBy(variantsFieldName)
                .OrderBy("Key")
                .Select("Key")
                .Distinct()
                .ToDynamicListAsync();
        }
    }

    public class SubstationsRepository : TRepository<Substation>
    {
        public SubstationsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            base._dbset = _context.Substations;
        }

        public async override Task<Substation> DeepFindAsync(int Id)
        {
            return await base._dbset.Include(x => x.Equipments).FirstOrDefaultAsync(b => b.Id == Id);
        }

        public async override Task<List<dynamic>> DeepFindVariantsAsync(int Id, string variantsFieldName)
        {
            return await base._dbset.Include(x => x.Equipments)
                .Where(b => b.Id == Id)
                .SelectMany(x => x.Equipments)
                .GroupBy(variantsFieldName)
                .OrderBy("Key")
                .Select("Key")
                .Distinct()
                .ToDynamicListAsync();
        }
    }
        
    public class EquipmentsRepository : TRepository<Equipment>
    {
        public EquipmentsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            base._dbset = _context.Equipments;
        }

        public async override Task<Equipment> DeepFindAsync(int Id)
        {
            return await base.FindAsync(Id);
        }
        public async override Task<List<dynamic>> DeepFindVariantsAsync(int Id, string variantsFieldName)
        {
            return await Task.FromResult<List<dynamic>>(null);
        }
    }
}
