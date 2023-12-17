namespace Entity.Model;

public partial class Order
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}
