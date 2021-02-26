using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private AccountManager shopItemList;
    public GameObject shopItemParent;
    public enum ItemType
    {
        Bird,
        Wall,
    }
    public ItemType gridType;

    // Start is called before the first frame update
    void Start()
    {
        //Get Master List
        shopItemList = FindObjectOfType<AccountManager>();
        InitShopItems();
    }
    public void InitShopItems()
    {
        //Send each individual shop item down to their respective grid objects
        for (int i = 0; i < shopItemList.itemList.shopItems.Length; i++)
        {
            if(shopItemList.itemList.shopItems[i].itemType.ToString() == gridType.ToString())
            {
                GameObject child = Instantiate(shopItemParent, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
                child.GetComponent<ShopButtonScript>().SetShopItem(shopItemList.itemList.shopItems[i]); ;
            }
            
        }
    }

    //Updating the Shop items UI from the Account Manager List
    public void UpdateShopItems()
    {
        //Get each UI object and Update them
        foreach(Transform child in transform)
        {
            child.GetComponent<ShopButtonScript>().InitUI();
        }
    }
}
