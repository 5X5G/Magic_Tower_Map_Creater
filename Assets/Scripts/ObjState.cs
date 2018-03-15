using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjState : MonoBehaviour {

    public UISprite mUISprite;

    public CellData CellInfo     {    set;  get;   }

    public void ClickTitle()
    {
        Creater.chooseTitle = gameObject.name;
        Debug.Log(Creater.chooseTitle);
    }

    public void ClickCell()
    {
        Creater.chooseCell = CellInfo;
    }
}
