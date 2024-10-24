using UnityEngine;

public class Item
{
    public Sprite Icon { get; private set; }
    public int Quantity { get; set; }

    public Item(Sprite icon, int quantity)
    {
        Icon = icon;
        Quantity = quantity;
    }
}