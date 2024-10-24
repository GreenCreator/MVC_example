using System.Collections.Generic;

public class PurchaseWindowModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public float Price { get; set; }
    public float Discount { get; set; }
    public string NameMainIcon { get; set; }
}