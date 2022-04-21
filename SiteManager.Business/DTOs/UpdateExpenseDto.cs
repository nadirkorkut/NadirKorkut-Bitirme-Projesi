using System;
using System.Collections.Generic;

namespace SiteManager.Business.DTOs
{
    public class UpdateExpenseDto
    {
        public int Id { get; set; }
        public bool IsPayment { get; set; }
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
