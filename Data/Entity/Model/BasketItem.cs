namespace Entity.Model;

public partial class BasketItem
{
    public int Id { get; set; }
    public int BasketId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}
