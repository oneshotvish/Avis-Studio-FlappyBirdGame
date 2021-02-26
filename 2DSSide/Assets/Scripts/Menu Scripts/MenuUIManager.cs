using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    public GameObject[] objToEnable;
    public GameObject[] objToDisable;
    

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
}
