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
    [Tooltip("The activate button")]
    public Button activeButton;
    [Tooltip("The activate text")]
    public TMP_Text activeText;

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
            //Don't allow activation
            activeButton.interactable = false;
            activeText.SetText("Activate");
            //Set up buy button
            buyButton.interactable = true;
            buyText.SetText(selectedItem.itemPrice.ToString() + " Coins");
        }
        //else if the item is owned
        else if (selectedItem.isOwned)
        {
            //Don't allow buying
            buyButton.interactable = false;
            buyText.SetText("Owned");
            //If the item is already active
            if (selectedItem.isActive)
            {
                //Don't allow activation
                activeButton.interactable = false;
                activeText.SetText("Activated!");
            }
            //Else if the item is not active
            else if (!selectedItem.isActive)
            {
                //Set up active button
                activeButton.interactable = true;
                activeText.SetText("Activate");
            }
        }
    }

    /// <summary>
    /// When the buy button is pressed
    /// </summary>
    public void OnBuyButton()
    {
        //Update this item's status
        currentItem.isOwned = true;
        //Refresh UI
        TakeSelectedItem(currentItem);
    }

    /// <summary>
    /// When the Active button is pressed
    /// </summary>
    public void OnActiveButton()
    {
        //Update the active item
        accManager.UpdateActive(currentItem);
        //Refresh UI
        TakeSelectedItem(currentItem);
    }
}
