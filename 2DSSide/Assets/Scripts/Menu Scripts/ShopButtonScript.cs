using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButtonScript : MonoBehaviour
{
    public SelectedItemController itemController;
    //This particular item
    [SerializeField]
    private ShopItem thisShopItem;
    //Buy Button
    public GameObject buyButton;
    //Bird Image
    public TMP_Text buyText;

    //Start
    private void Start()
    {
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
    }
}
