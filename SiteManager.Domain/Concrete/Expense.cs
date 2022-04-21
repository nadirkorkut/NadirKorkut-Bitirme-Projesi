using SiteManager.Domain.Abstract;
using System;

namespace SiteManager.Domain.Concrete
{
    public class Expense : IEntity
    {
        public int Id { get; set; }
        public bool IsPayment { get; set; }
        public decimal Price { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int FlatId { get; set; }
        public Flat Flat { get; set; }
        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }
    }
}
