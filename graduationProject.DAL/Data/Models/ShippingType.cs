namespace graduationProject.DAL.Data.Models
{
    public class ShippingType
    {
        public byte Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Cost { get; set; }
    }
}