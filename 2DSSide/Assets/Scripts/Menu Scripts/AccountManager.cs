using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    public Account acc;
    private int shopLength;
    public ShopItem[] itemList;
    public ShopManager birdShopManager, wallShopManager;
    private CoinManager coinManager;

    
    /// <summary>
    /// Awake
    /// </summary>
    private void Awake()
    {
        //Destroy Duplicate Versions
        if (GameObject.FindGameObjectsWithTag("AccountManager").Length > 1)
        {
            Destroy(gameObject);
        }
        //Dont Destroy this object
        DontDestroyOnLoad(this.gameObject);       
    }

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {           
        //Get Shop Length
        shopLength = itemList.Length;
        
        //Load Account data
        LoadAccount();

        AddCoins(1000);
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

    /// <summary>
    /// Updates Master List of shop items after a new purchase in the shop
    /// </summary>
    /// <param name="shopItem"></param>
    //
    public void UpdateShop(ShopItem shopItem)
    {
        //Find this item
        for (int i = 0; i < shopLength; i++)
        {
            if (itemList[i].itemName == shopItem.itemName)
            {
                //Set it equal to updated version
                itemList[i] = shopItem;
            }
        }
    }

    /// <summary>
    /// Updates the current active item
    /// </summary>
    /// <param name="shopItem">Item to set active</param>
    public void UpdateActive(ShopItem shopItem)
    {
        //Set this item active
        shopItem.isActive = true;
        //For every other item of this type
        for (int i = 0; i < shopLength; i++)
        {
            if (itemList[i].itemType == shopItem.itemType && itemList[i].itemName != shopItem.itemName)
            {
                //Set it inactive
                itemList[i].isActive = false;
            }
        }
    }

    /// <summary>
    /// Add coins to account
    /// </summary>
    /// <param name="amount">Amount of coins to add</param>
    public void AddCoins(int amount)
    {
        //Add coins
        acc.coins += amount;
        Debug.Log("Added Coins (" + amount + ") Total = " + acc.coins);
        if (coinManager != null)
        {
            //Update UI to display coins
            coinManager.UpdateCoinUI(acc.coins);
        }
    }

    /// <summary>
    /// Subtract coins from account
    /// </summary>
    /// <param name="amount">amount to subtract</param>
    public void SubtractCoins(int amount)
    {
        //Subtract coins
        acc.coins -= amount;
        if (coinManager != null)
        {
            //Update UI to display coins
            coinManager.UpdateCoinUI(acc.coins);
        }
    }

    /// <summary>
    /// Get current coin amount
    /// </summary>
    /// <returns></returns>
    public int GetCoins()
    {
        return acc.coins;
    }

    /// <summary>
    /// Save Account Info to player prefs
    /// </summary>
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

    /// <summary>
    /// Load account info from player prefs
    /// </summary>
    public void LoadAccount()
    {
        //Create new Account and fill data
        acc = new Account(PlayerPrefs.GetInt("Coins", 0), itemList);
        
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

    /// <summary>
    /// Save account data on quit
    /// </summary>
    private void OnApplicationQuit()
    {
        SaveAccount();
    }
}
