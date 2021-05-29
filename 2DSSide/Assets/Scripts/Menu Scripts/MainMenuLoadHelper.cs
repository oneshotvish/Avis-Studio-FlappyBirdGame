using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLoadHelper : MonoBehaviour
{
    private AccountManager accMan;
    // Start is called before the first frame update
    void Start()
    {
        accMan = GameObject.FindGameObjectWithTag("AccountManager").GetComponent<AccountManager>();
        //accMan.GetShopManagers();
        Destroy(gameObject);
    }
}
