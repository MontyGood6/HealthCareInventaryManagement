using Healthcare.InventoryManagement.Domain.Entity;
using Healthcare.InventoryManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.InventoryManagement.Infrastructure
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly AppDbContext _context;

        public MedicineRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Medicine>> GetAllAsync()
        {
            return await _context.Medicines.ToListAsync();
        }


        async Task IMedicineRepository.AddAsync(Medicine medicine)
        {
           await _context.Medicines.AddAsync(medicine);
           await _context.SaveChangesAsync();
        }

    
        public async Task<Medicine> DeleteByIdAsync(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);

            if (medicine == null)
                return null;

            _context.Medicines.Remove(medicine);
            await _context.SaveChangesAsync();

            return medicine;
        }

        

        
         public Task<Medicine> GetByIdAsync(int id)
        {
           var medicine =  _context.Medicines.FindAsync(id);
            return medicine.AsTask();
        }



        public async Task<Medicine> UpdateByIdAsync(Medicine updatedMedicine)
        {
            if (updatedMedicine == null)
                throw new ArgumentNullException(nameof(updatedMedicine));

            // DB se existing entity lao (Id se)
            var existingMedicine = await _context.Medicines
                .FirstOrDefaultAsync(m => m.Id == updatedMedicine.Id);

            if (existingMedicine == null)
                throw new KeyNotFoundException(
                    $"Medicine with ID {updatedMedicine.Id} not found.");

            // 🔹 Fields update karo (manual mapping)
            existingMedicine.Name = updatedMedicine.Name;
            existingMedicine.ExpiryDate = updatedMedicine.ExpiryDate;
            

            // 🔹 Save changes
            await _context.SaveChangesAsync();

            return existingMedicine;
        }

      
    }

}
