using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSkinSelection : MonoBehaviour
{
    private AccountManager accMan;
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        //Get account manager
        accMan = FindObjectOfType<AccountManager>();

        //Find the active bird and Spawn it
        if (accMan != null)
        {
            for (int i = 0; i < accMan.itemList.Length; i++)
            {
                if (accMan.itemList[i].isActive && accMan.itemList[i].itemType.ToString() == "Bird")
                {
                    Instantiate(accMan.itemList[i].objPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                }
            }
        }
    }
}
