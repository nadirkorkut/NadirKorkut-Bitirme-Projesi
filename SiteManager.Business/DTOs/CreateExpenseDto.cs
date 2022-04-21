using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManager.Business.DTOs
{
    public class CreateExpenseDto
    {
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int ExpenseTypeId { get; set; }
        public int FlatId { get; set; }

        public string TypeName { get; set; }

        public byte FlatNumber { get; set; }
        public ICollection<ExpenseTypeDto> ExpenseTypes { get; set; }
        public ICollection<FlatDto> Flats { get; set; }
    }
}
