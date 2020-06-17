using PlanRza.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanRza.Models.Data
{
    public interface IRepository<T>
    {
        Task<List<T>> GetListAsync();
        Task<T> FindAsync(int Id);
        Task<T> AddAsync(T t);
        Task EditTAsync(T newT, int Id);
        Task<T> DeleteAsync(int Id);
        Task<T> DeepFindAsync(int Id);
        List<dynamic> FindFieldVariants(string fieldName);
        Task<List<dynamic>> DeepFindVariantsAsync(int Id, string fieldVariantsName);

    }
}