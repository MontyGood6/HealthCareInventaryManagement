using Healthcare.InventoryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.InventoryManagement.Application.Interfaces
{
    public interface IMedicineService
    {
        Task<List<MedicineDto>> GetMedicinesAsync();
        Task<MedicineDto> GetMedicineByIdAsync(int id);

        Task AddMedicineAsync(MedicineDto medicineDto);
        Task UpdateMedicineByIdAsync(MedicineDto medicineDto, int id);

        Task DeleteMedicineAsync(int id);
       
    }

}
