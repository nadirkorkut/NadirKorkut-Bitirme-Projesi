using System;

namespace SiteManager.Business.DTOs
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public bool IsPayment { get; set; }
        public decimal Price { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string UserName { get; set; }
        public int FlatId { get; set; }
        public byte FlatNumber { get; set; }
        public string TypeName { get; set; }
    }
}
