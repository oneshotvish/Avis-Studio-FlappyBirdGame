using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    public GameObject[] objToEnable;
    public GameObject[] objToDisable;
    public Button buttonToInteractable, buttonToUninteractable;
    

    public void EnableGOs()
    {
        for (int i = 0; i < objToEnable.Length; i++)
        {
            objToEnable[i].SetActive(true);
        }
    }

    public void DisableGOs()
    {
        for (int i = 0; i < objToDisable.Length; i++)
        {
            objToDisable[i].SetActive(false);
        }
    }

    public void MakeButtonInteractable()
    {
        buttonToInteractable.interactable = true;
    }
    public void MakeButtonUnInteractable()
    {
        buttonToUninteractable.interactable = false;
    }

    public void SwapShopTabs(GameObject tabBG)
    {
        tabBG.transform.SetAsLastSibling();
    }
}
