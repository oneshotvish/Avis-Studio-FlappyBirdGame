using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItem
{
    //Name of this particular item
    public string itemName;
    //The class of items that it belongs to
    public Type itemType;
    public enum Type
    {
        Bird,
        Wall
    }
    //The price of the items in coins
    public int itemPrice;
    //If this item is owned
    public bool isOwned;
    //If this item is active
    public bool isActive;
    //In Game Prefab
    public GameObject objPrefab;
    //Shop Sprite
    public Sprite sprite;
}
