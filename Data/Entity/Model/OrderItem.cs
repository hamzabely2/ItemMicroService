namespace Entity.Model;

public partial class OrderItem
{
    public int Id { get; set; }
    public int IdItem { get; set; }
    public int IdOrder { get; set; }
    public int Quantity { get; set; }
    public virtual Item IdItemNavigation { get; set; } = null!;
    public virtual Order IdOrderNavigation { get; set; } = null!;
}
