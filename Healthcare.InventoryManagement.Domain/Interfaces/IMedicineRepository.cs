using Healthcare.InventoryManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.InventoryManagement.Domain.Interfaces
{
    public interface IMedicineRepository
    {
       public Task<List<Medicine>> GetAllAsync();
     public  Task<Medicine> GetByIdAsync(int id);
         public Task AddAsync(Medicine medicine);
       public  Task<Medicine> DeleteByIdAsync(int id);
      public   Task<Medicine> UpdateByIdAsync(Medicine medicine);
        
    }
}
