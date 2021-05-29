using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    //Holds Shop Data
    private AccountManager accountManager;
    //Parent for the shop items
    public GameObject shopItemParent;
    //Enum of the different shop grid types
    public enum ItemType
    {
        Bird,
        Wall,
    }
    //This manager's grid type
    public ItemType gridType;

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        //Get Account Manager
        accountManager = GameObject.FindGameObjectWithTag("AccountManager").GetComponent<AccountManager>();
        //Create the Shop Items
        InitShopItems();
        //Set up Shop Manger UI
        InitUI();
    }

    /// <summary>
    /// Creates and fills each shop item from the shop item list
    /// </summary>
    public void InitShopItems()
    {
        //Send each individual shop item down to their respective grid objects
        for (int i = 0; i < accountManager.itemList.Length; i++)
        {
            //Only for this grid type
            if (accountManager.itemList[i].itemType.ToString() == gridType.ToString())
            {
                //Create the shop item
                GameObject child = Instantiate(shopItemParent, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
                //Fill shop item data
                child.GetComponent<ShopButtonScript>().SetShopItem(accountManager.itemList[i]); ;
            }
        }
    }

    /// <summary>
    /// Updates the UI for all of the shop items
    /// </summary>
    public void UpdateShopItems()
    {
        //Get each UI object and Update them
        foreach(Transform child in transform)
        {
            child.GetComponent<ShopButtonScript>().InitUI();
        }
    }

    /// <summary>
    /// Initializes the UI for the Shop Manager
    /// </summary>
    private void InitUI()
    {
        //Only keep the initial grid active
        //if(gridType != ItemType.Bird)
       // {
        //    gameObject.SetActive(false);
        //}
    }
}
