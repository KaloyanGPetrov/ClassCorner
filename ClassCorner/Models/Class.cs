namespace ClassCorner.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Student { get; internal set; }
        public object Teacher { get; internal set; }
    }
}