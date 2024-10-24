using UnityEngine;

public class PurchaseWindowController
{
    private PurchaseWindowModel model;
    private PurchaseWindowView view;

    public PurchaseWindowController(PurchaseWindowModel model, PurchaseWindowView view)
    {
        this.model = model;
        this.view = view;

        view.OnPurchaseButtonClicked += HandlePurchase;
        UpdateView();
    }

    private void HandlePurchase()
    {
        Debug.Log("Purchase made!");
    }

    private void UpdateView()
    {
        view.SetTitle(model.Title);
        view.SetDescription(model.Description);
        view.SetItems(model.Items);
        view.SetPrice(model.Price, model.Discount);
        view.SetNameMainIcon(model.NameMainIcon);
    }
}