using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    public Account acc;
    private int shopLength;
    public ShopItemList itemList;
    public ShopManager birdShopManager, wallShopManager;
    private CoinManager coinManager;

    

    //Destroy Duplicate Versions
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("AccountManager").Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);       
    }

    //Start
    void Start()
    {           
        //Get ItemList Script
        itemList = GetComponent<ShopItemList>();
        //Get Shop Length
        shopLength = itemList.shopItems.Length;
        
        LoadAccount();
    }

    //Debug Coins
    public int coinss;
    private void Update()
    {
        coinss = acc.coins;
    }

    //Called From MainMenuLoadHelper
    public void GetShopManagers()
    {
        //Get ShopManager
        birdShopManager = GameObject.FindGameObjectWithTag("BirdShopManager").GetComponent<ShopManager>();
        wallShopManager = GameObject.FindGameObjectWithTag("WallShopManager").GetComponent<ShopManager>();
        coinManager = GameObject.FindGameObjectWithTag("CoinManager").GetComponent<CoinManager>();
        coinManager.UpdateCoinUI(acc.coins);
        birdShopManager.transform.parent.gameObject.SetActive(false);
    }

    //Updates Master List of shop items after a new purchase in the shop
    public void UpdateShop(ShopItem shopItem)
    {
        //Find this item
        for (int i = 0; i < shopLength; i++)
        {
            if (itemList.shopItems[i].itemName == shopItem.itemName)
            {
                //Set it equal to updated version
                itemList.shopItems[i] = shopItem;
            }
        }
    }

    //Updates Master List after a change in active item
    public void UpdateActive(ShopItem shopItem)
    {
        //For every other item of this type
        for (int i = 0; i < shopLength; i++)
        {
            if (itemList.shopItems[i].itemType == shopItem.itemType && itemList.shopItems[i].itemName != shopItem.itemName)
            {
                //Set it inactive
                itemList.shopItems[i].isActive = false;
            }
        }
        //Tell Shop Manager to update UI
        birdShopManager.UpdateShopItems();
        wallShopManager.UpdateShopItems();
    }

    //Adds Coins
    public void AddCoins(int amount)
    {
        acc.coins += amount;
        Debug.Log("Added Coins (" + amount + ") Total = " + acc.coins);
        if (coinManager != null)
        {
            coinManager.UpdateCoinUI(acc.coins);
        }
    }

    //Subtract Coins
    public void SubtractCoins(int amount)
    {
        acc.coins -= amount;
        if (coinManager != null)
        {
            coinManager.UpdateCoinUI(acc.coins);
        }
    }

    //Save Account Info to Player Prefs
    public void SaveAccount()
    {
        //Coins
        PlayerPrefs.SetInt("Coins", acc.coins);
        //Shop
        for (int i = 0; i < shopLength; i++)
        {
            //Ownership
            if (acc.items[i].isOwned)
            {
                PlayerPrefs.SetInt(acc.items[i].itemName + " Is Owned", 1);
            }
            else if (!acc.items[i].isOwned)
            {
                PlayerPrefs.SetInt(acc.items[i].itemName + " Is Owned", 0);
            }

            //Active
            if (acc.items[i].isActive)
            {
                PlayerPrefs.SetInt(acc.items[i].itemName + " Is Active", 1);
            }
            else if (!acc.items[i].isActive)
            {
                PlayerPrefs.SetInt(acc.items[i].itemName + " Is Active", 0);
            }
        }
    }

    //Get account info from Player Prefs
    public void LoadAccount()
    {
        //Create new Account and fill data
        acc = new Account(0, itemList.shopItems);
        //Coins (Default 0)
        acc.coins = PlayerPrefs.GetInt("Coins", 0);
        //Shop (Default unowned)
        for (int i = 0; i < shopLength; i++)
        {
            //Load Ownership
            int j = PlayerPrefs.GetInt(acc.items[i].itemName + " Is Owned", 0);
            if (j == 0)
            {
                acc.items[i].isOwned = false;
            }
            else if (j == 1)
            {
                acc.items[i].isOwned = true;
            }

            //Load Active
            int k = PlayerPrefs.GetInt(acc.items[i].itemName + " Is Active", 0);
            if (k == 0)
            {
                acc.items[i].isActive = false;
            }
            else if (k == 1)
            {
                acc.items[i].isActive = true;
            }
        }
    }

    private void OnApplicationQuit()
    {
        SaveAccount();
    }
}
