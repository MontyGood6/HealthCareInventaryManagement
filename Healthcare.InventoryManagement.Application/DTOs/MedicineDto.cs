using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.InventoryManagement.Domain.Entity;

namespace Healthcare.InventoryManagement.Application.DTOs
{
   public class MedicineDto
    {

        public string Name { get; set; }
        public string BatchNo { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
    }
}
