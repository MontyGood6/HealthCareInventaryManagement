using Healthcare.InventoryManagement.Domain.Interfaces;
using Healthcare.InventoryManagement.Application.DTOs;
using Healthcare.InventoryManagement.Domain.Entity;
using Healthcare.InventoryManagement.Application.Interfaces;
using AutoMapper;



namespace Healthcare.InventoryManagement.Application.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _repo;
        private  readonly AutoMapper.IMapper _mapper;

        public MedicineService(IMedicineRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;


        }
        public async Task<List<MedicineDto>> GetMedicinesAsync()
        {
            var data = await _repo.GetAllAsync();

            return data.Select(x => new MedicineDto
            {
                Name = x.Name,
                Quantity = x.Quantity,
                BatchNo = x.BatchNo,
                ExpiryDate = x.ExpiryDate
            }).ToList();
        }


        async Task IMedicineService.AddMedicineAsync(MedicineDto medicineDto)
        {
            await _repo.AddAsync(new Medicine
            {
                Name = medicineDto.Name,
                Quantity = medicineDto.Quantity,
                BatchNo = medicineDto.BatchNo,
                ExpiryDate = medicineDto.ExpiryDate
            });
        }

        async Task IMedicineService.DeleteMedicineAsync(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException("Invalid medicine ID.");
            }
            var deletedMedicine = await _repo.DeleteByIdAsync(id);

            if(deletedMedicine != null)
            {
                Console.WriteLine($"Medicine with ID {id} deleted successfully.");
            }
         
        }

        Task<MedicineDto> IMedicineService.GetMedicineByIdAsync(int id)
        {
           var medicine =  _repo.GetByIdAsync(id);
              return medicine.ContinueWith(task => 
              {
                var med = task.Result;
                if (med == null)
                     return null;
    
                return new MedicineDto
                {
                     Name = med.Name,
                     Quantity = med.Quantity
                };
              });
        }
        public async Task UpdateMedicineByIdAsync(MedicineDto medicineDto, int id)
        {
            if (medicineDto == null)
                throw new ArgumentNullException(nameof(medicineDto));

            var medicine = await _repo.GetByIdAsync(id);

            if (medicine == null)
                throw new KeyNotFoundException($"Medicine with ID {id} not found.");

            // Map DTO fields to existing entity
            _mapper.Map(medicineDto, medicine);

            await _repo.UpdateByIdAsync(medicine);
        }

    }

}
