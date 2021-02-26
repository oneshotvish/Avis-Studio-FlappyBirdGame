using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSkinSelection : MonoBehaviour
{
    private AccountManager accountMan;
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        //Get account manager
        accountMan = FindObjectOfType<AccountManager>();

        //Find the active bird and Spawn it
        if (accountMan != null)
        {
            for (int i = 0; i < accountMan.itemList.shopItems.Length; i++)
            {
                if (accountMan.itemList.shopItems[i].isActive && accountMan.itemList.shopItems[i].itemType.ToString() == "Bird")
                {
                    Instantiate(accountMan.itemList.shopItems[i].objPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                }
            }
        }
    }
}
