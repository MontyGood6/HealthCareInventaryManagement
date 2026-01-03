using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.InventoryManagement.Domain.Entity
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BatchNo { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
    }

}
