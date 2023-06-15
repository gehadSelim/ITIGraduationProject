namespace graduationProject.Bl.DTOs.OrderItem
{
    public class OrderItemWriteDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double ProductPrice { get; set; }
        public double ProductWeight { get; set; }
        public int ProductQuntity { get; set; }
    }
}
