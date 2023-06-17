namespace graduationProject.Bl.DTOs.OrderItem
{
    public class OrderItemWriteDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double ProductWeight { get; set; }
        public int ProductQuantity { get; set; }
    }
}
