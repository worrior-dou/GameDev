using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public string objName;
    public int scorePoint;
    public Sprite sprite;
    public enum ItemType
    {
        COIN,
        BOOM,
        POWER
    }
    public ItemType itemType;
}
