using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseWindowView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private ItemView prefabItem;
    [SerializeField] private Transform itemContent;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI oldPriceText;
    [SerializeField] private TextMeshProUGUI discountText;
    [SerializeField] private TextMeshProUGUI iconText;
    [SerializeField] private Button purchaseButton;

    public event Action OnPurchaseButtonClicked;

    public void SetTitle(string title) => titleText.text = title;
    public void SetDescription(string description) => descriptionText.text = description;

    public void SetItems(List<Item> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            var itemView = Instantiate(prefabItem, itemContent);
            itemView.SetImage(items[i].Icon);
            itemView.SetCountText(items[i].Quantity.ToString());
        }
    }

    public void SetPrice(float price, float discount)
    {
        if (discount > 0)
        {
            discountText.text = $"{(-discount).ToString()}%";
            priceText.text = $"${price * (1 - discount / 100):F2}";
            oldPriceText.text = $"${price}";
        }
        else
        {
            discountText.gameObject.GetComponentInParent<Image>().gameObject.SetActive(false);
            oldPriceText.gameObject.SetActive(false);
            priceText.text = $"${price}";
        }
    }

    public void SetNameMainIcon(string value)
    {
        iconText.text = value;
    }

    public void OnPurchaseButtonClick()
    {
        OnPurchaseButtonClicked?.Invoke();
    }
}