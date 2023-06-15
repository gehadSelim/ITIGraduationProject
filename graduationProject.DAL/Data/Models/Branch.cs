namespace graduationProject.DAL
{
    public class Branch
    {
        public byte Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.Now;

        public bool Status { get; set; } = true;
    }
}