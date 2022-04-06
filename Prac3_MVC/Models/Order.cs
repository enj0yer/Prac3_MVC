
namespace Prac3_MVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}