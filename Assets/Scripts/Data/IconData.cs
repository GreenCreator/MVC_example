using UnityEngine;

[CreateAssetMenu(fileName = "IconData", menuName = "ScriptableObjects/IconData", order = 2)]
public class IconData : ScriptableObject
{
    [SerializeField] private string iconName;
    [SerializeField] private Sprite iconSprite;
    public string IconName => iconName;

    public Sprite IconSprite => iconSprite;
}