using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public TMP_Text coinUI;
    private AccountManager accountMan;

    private void Start()
    {
        accountMan = GameObject.FindGameObjectWithTag("AccountManager").GetComponent<AccountManager>();
        UpdateCoinUI(accountMan.acc.coins);
    }

    public void UpdateCoinUI(int number)
    {
        Debug.Log("Update Coin UI");
        coinUI.SetText(": " + number.ToString());
    }
}
