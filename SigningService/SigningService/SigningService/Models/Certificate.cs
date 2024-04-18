namespace SigningService.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] HashedPassword { get; set; }
        public byte[] HashedContent { get; set; }
    }
}
