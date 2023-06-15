using System.ComponentModel.DataAnnotations.Schema;

namespace graduationProject.DAL.Data.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double ProductPrice { get; set; }
        public double ProductWeight { get; set; }
        public int ProductQuntity { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }

    }
}