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
    private void Start()
    {
        trans = shopContentParent.GetComponent<RectTransform>();
        layoutOffset = layoutGroup.spacing;
        Debug.Log(trans.localPosition.x);
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
            trans.localPosition = new Vector3(trans.localPosition.x + (layoutOffset/* * trans.localScale.x*/), trans.localPosition.y, trans.localPosition.z);
            elementIndex--;
        }
    }

    public void RightButton()
    {
        layoutOffset = layoutGroup.spacing;
        if (elementIndex < (elementCount - 1))
        {
            trans.localPosition = new Vector3(trans.localPosition.x - (layoutOffset/* * trans.localScale.x*/), trans.localPosition.y, trans.localPosition.z);
            elementIndex++;
        }
    }
}
