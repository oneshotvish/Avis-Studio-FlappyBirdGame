using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButtonScript : MonoBehaviour
{
    public SelectedItemController itemController;
    //Script with Master List
    private AccountManager masterItemList;
    //This particular item
    private ShopItem thisShopItem;
    //Buy Button
    public GameObject buyButton;
    //Bird Image
    public TMP_Text buyText;
    public GameObject unownedBar;

    //Start
    private void Start()
    {
        //Get Master List Script
        masterItemList = GameObject.FindGameObjectWithTag("AccountManager").GetComponent<AccountManager>();
        itemController = GameObject.FindGameObjectWithTag("ItemController").GetComponent<SelectedItemController>();
    }

    //Recieving this shop item from Shop Manager
    public void SetShopItem(ShopItem si)
    {
        thisShopItem = si;
        InitUI();
    }

    //Initializing UI for this item
    public void InitUI()
    {
        //Set Shop Sprite
        buyButton.GetComponent<Image>().sprite = thisShopItem.sprite;
    }

    //After user buys item, update UI and send information to Master List
    public void OnItemClick()
    {
        itemController.TakeSelectedItem(thisShopItem);
        //Debug.Log("aa");
        ////On first buy of item
        //if(!thisShopItem.isOwned)
        //{
        //    Debug.Log("bb");
        //    //Set owned to true
        //    thisShopItem.isOwned = true;
        //    //Set New Buy to active
        //    thisShopItem.isActive = true;
        //    //Send to Master List
        //    masterItemList.UpdateShop(thisShopItem);
        //    //Update Master List Active
        //    masterItemList.UpdateActive(thisShopItem);            
        //}
        ////On selecting already bought item
        //if (thisShopItem.isOwned && !thisShopItem.isActive)
        //{
        //    Debug.Log("cc");
        //    //Set to active
        //    thisShopItem.isActive = true;
        //    //Send to Master List
        //    masterItemList.UpdateShop(thisShopItem);
        //    //Update Master List Active
        //    masterItemList.UpdateActive(thisShopItem);
        //}
    }
}
