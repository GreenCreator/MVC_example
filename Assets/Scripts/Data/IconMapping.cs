using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "IconMapping", menuName = "ScriptableObjects/IconMapping", order = 1)]
public class IconMapping : ScriptableObject
{
    [SerializeField] private List<IconData> icons;

    public List<IconData> Icons => icons;


    public Sprite GetIconByName(string iconName)
    {
        return icons.FirstOrDefault(icon => icon.IconName == iconName)?.IconSprite;
    }
}