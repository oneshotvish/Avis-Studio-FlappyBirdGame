using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account
{
    public int coins;
    public ShopItem[] items;

    public Account(int i_coins, ShopItem[] i_items)
    {
        coins = i_coins;
        items = i_items;
    }
}
