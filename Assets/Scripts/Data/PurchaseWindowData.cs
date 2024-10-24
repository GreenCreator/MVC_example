using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PurchaseWindowData", menuName = "ScriptableObjects/PurchaseWindowData")]
public class PurchaseWindowData : ScriptableObject
{
    public string Title;
    public string Description;
    public List<ItemData> Items;
    public float Price;
    [Range(0, 100)] public float Discount;
    public string NameMainIcon;


    [Serializable]
    public class ItemData
    {
        public string itemName;
        public int itemCount;
        public IconData selectedIcon;
    }
}