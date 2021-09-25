using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopParser : MonoBehaviour
{
    [SerializeField]private GameObject shopContentParent;

    private RectTransform trans;
    [SerializeField]private HorizontalLayoutGroup layoutGroup;
    private float layoutOffset;

    private int elementCount = 0;
    private int elementIndex = 0;

    private AccountManager accountMan;
    //Enum of the different shop grid types
    public enum ItemType
    {
        Bird,
        Wall,
    }
    //This manager's grid type
    public ItemType gridType;

    private void Start()
    {
        trans = shopContentParent.GetComponent<RectTransform>();
        layoutOffset = layoutGroup.spacing;
        Debug.Log(trans.localPosition.x);

        accountMan = GameObject.FindGameObjectWithTag("AccountManager").GetComponent<AccountManager>();
    }

    public void AddElement()
    {
        elementCount++;
    }

    public void LeftButton()
    {
        layoutOffset = layoutGroup.spacing;
        if (elementIndex > 0)
        {
            //Move over whole list by: offset * scale.x
            trans.localPosition = new Vector3(trans.localPosition.x + (layoutOffset * trans.localScale.x), trans.localPosition.y, trans.localPosition.z);
            elementIndex--;
        }
    }

    public void RightButton()
    {
        layoutOffset = layoutGroup.spacing;
        if (elementIndex < (elementCount - 1))
        {
            trans.localPosition = new Vector3(trans.localPosition.x - (layoutOffset * trans.localScale.x), trans.localPosition.y, trans.localPosition.z);
            elementIndex++;
        }
    }

    public void SendSelectedData()
    {
        Debug.Log("Send Data");
        List<ShopItem> tempList = new List<ShopItem>();
        for (int i = 0; i < accountMan.itemList.Length; i++)
        {
            //Only for this grid type
            if (accountMan.itemList[i].itemType.ToString() == gridType.ToString())
            {
                tempList.Add(accountMan.itemList[i]);
            }
        }
        accountMan.UpdateActive(tempList[elementIndex]);
    }
}
