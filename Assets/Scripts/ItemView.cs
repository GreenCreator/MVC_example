using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI countText;

    public void SetImage(Sprite sprite) => image.sprite = sprite;
    public void SetCountText(string text) => countText.text = text;
}