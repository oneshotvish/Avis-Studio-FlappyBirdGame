using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedItemController : MonoBehaviour
{   
    [Tooltip("The image of the selected item")]
    public Image selectedImage;
    [Tooltip("The buy button")]
    public Button buyButton;
    [Tooltip("The buy text")]
    public TMP_Text buyText;

    //Holds Shop Data
    private AccountManager accManager;
    //The currently selected Shopitem
    private ShopItem currentItem;

    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        accManager = GameObject.FindGameObjectWithTag("AccountManager").GetComponent<AccountManager>();
    }

    /// <summary>
    /// Takes the item the player has clicked on and updates the UI to display it
    /// </summary>
    /// <param name="selectedItem">The ShopItem data to display</param>
    public void TakeSelectedItem(ShopItem selectedItem)
    {
        //Set current item
        currentItem = selectedItem;
        //Set UI image
        selectedImage.sprite = selectedItem.sprite;
        //If the item is not owned
        if (!selectedItem.isOwned)
        {
            buyButton.interactable = true;
            //Set up buy button
            buyText.SetText(selectedItem.itemPrice.ToString() + " Coins");
        }
        //else if the item is owned
        else if (selectedItem.isOwned)
        {
            OnActiveButton();
            //Don't allow buying
            buyButton.interactable = false;
            buyText.SetText("Owned");
        }
    }

    /// <summary>
    /// When the buy button is pressed
    /// </summary>
    public void OnBuyButton()
    {
        Debug.Log("OBB1");
        if(accManager.GetCoins() >= currentItem.itemPrice)
        {
            Debug.Log("OBB2");
            accManager.SubtractCoins(currentItem.itemPrice);
            //Update this item's status
            currentItem.isOwned = true;
            //Refresh UI
            TakeSelectedItem(currentItem);
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// When the Active button is pressed
    /// </summary>
    public void OnActiveButton()
    {
        //Update the active item
        accManager.UpdateActive(currentItem);
    }
}
