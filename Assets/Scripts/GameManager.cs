using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<PurchaseWindowData> popupData;
    [SerializeField] private PurchaseWindowView prefabPopup;
    [SerializeField] private Transform content;
    [SerializeField] private TMP_InputField inputField;

    private List<PurchaseWindowView> popups = new List<PurchaseWindowView>();

    private float startWidthContent;
    private RectTransform contentRectTransform;
    private void Start()
    {
        contentRectTransform = content.GetComponent<RectTransform>();
        startWidthContent = contentRectTransform.rect.width;
    }

    private void ChangeWidthContent(int count)
    {
        var newWidth = contentRectTransform.rect.width +
                         prefabPopup.GetComponent<RectTransform>().rect.width * count;
        contentRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
    }
    
    private void InitWidthContent()
    {
        contentRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, startWidthContent);
    }

    public void OnOpenWindowButtonClick()
    {
        ChangeWidthContent(popupData.Count);

        foreach (var data in popupData)
        {
            var purchaseWindowView = Instantiate(prefabPopup, content);

            var item = new List<Item>();
            foreach (var itemsData in data.Items)
            {
                item.Add(new Item(itemsData.selectedIcon.IconSprite, itemsData.itemCount));
            }

            var model = new PurchaseWindowModel
            {
                Title = data.Title,
                Description = data.Description,
                Items = item,
                Price = data.Price,
                Discount = data.Discount,
                NameMainIcon = data.NameMainIcon
            };

            popups.Add(purchaseWindowView);
            new PurchaseWindowController(model, purchaseWindowView);
        }
    }

    public void OnOpenWindowWhitInputButtonClick()
    {
        if (string.IsNullOrEmpty(inputField.text)) return;

        int itemCount = 0;
        try
        {
            itemCount = int.Parse(inputField.text);
            if (itemCount > 6)
            {
                Debug.LogError("More then 6");
                return;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return;
        }

        ChangeWidthContent(1);

        var iconMapping = Resources.Load<IconMapping>("IconMapping");
        var purchaseWindowView = Instantiate(prefabPopup, content);

        var items = new List<Item>();
        for (int i = 0; i < itemCount; i++)
        {
            items.Add(new Item(iconMapping.Icons[Random.Range(0, iconMapping.Icons.Count)].IconSprite,
                Random.Range(1, 10)));
        }

        PurchaseWindowModel model = new PurchaseWindowModel
        {
            Title = "Покупка ресурсов",
            Description = "Получите свои ресурсы прямо сейчас!",
            Items = items,
            Price = Random.Range(1, 100),
            Discount = Random.Range(0, 100),
            NameMainIcon = "ResourceIcon"
        };
        popups.Add(purchaseWindowView);
        new PurchaseWindowController(model, purchaseWindowView);
    }


    public void OnClearAllPopup()
    {
        foreach (var popup in popups)
        {
            Destroy(popup.gameObject);
        }

        InitWidthContent();
        popups.Clear();
    }
}