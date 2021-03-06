using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public TMP_Text coinUI;

    // Update is called once per frame
    public void UpdateCoinUI(int number)
    {
        coinUI.SetText(": " + number.ToString());
    }
}
