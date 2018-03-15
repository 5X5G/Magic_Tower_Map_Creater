using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NTable : UITable {

    public NTableData tableData;
    public Transform mRoot;
    public GameObject cell;
    public UIDragScrollView mDragScrollView;
    public Transform[] cells;
    protected CellData cellInfo;       

    protected override void Start()
    {
        tableData.Init();
        Init();
        base.Start();
    }

    protected override void Init()
    {
        base.Init();

        if (tableData.CellDatas == null)
        {
            Debug.Log("无元素");
            return;
        }

        if (tableData.CellDatas[0].type == "title")
            InitCellView1();
    }

    public void InitCellView1()
    {
        List<CellData> celldatas = new List<CellData>(celldatas = tableData.CellDatas);        
        int length = tableData.CellDatas.Count;

        if (tableData.CellDatas == null)
        {
            Debug.Log("无元素");
            return;
        }            
        for (int i = 0; i < length; i++)
        {
            var go = Instantiate(cell) as GameObject;
            go.transform.parent = mRoot;
            go.transform.localScale = Vector3.one;
            go.name = tableData.CellDatas[i].altas;

            UILabel label = go.transform.GetComponentInChildren<UILabel>();
            label.text = go.name;

            UIDragScrollView dragScrollView = go.GetComponent<UIDragScrollView>();
            dragScrollView = mDragScrollView;

        }
    }

    public void InitCellView2()
    {
        int length = Creater.spriteInfos[Creater.chooseTitle].Count;
        for (int i = 0; i < length; i++)
        {
            var go = Instantiate(cell) as GameObject;
            go.transform.parent = mRoot;
            go.transform.localScale = Vector3.one;
            go.name = Creater.spriteInfos[Creater.chooseTitle][i].name;

            ObjState objState = go.GetComponent<ObjState>();
            objState.mUISprite.atlas.name = Creater.chooseTitle;
            objState.mUISprite.spriteName = go.name;

            UIDragScrollView dragScrollView = go.GetComponent<UIDragScrollView>();
            dragScrollView = mDragScrollView;
        }
    }

    public void SetTitle()
    {
        int length = Creater.spriteInfos[Creater.chooseTitle].Count;
        for (int i = 0; i < length; i++)
        {
            var go = Instantiate(cell) as GameObject;
            go.transform.parent = mRoot;
            go.transform.localScale = Vector3.one;
            go.name = Creater.spriteInfos[Creater.chooseTitle][i].name;
            ObjState objState = go.GetComponent<ObjState>();
            objState.mUISprite.atlas.name = Creater.chooseTitle;
            objState.mUISprite.spriteName = go.name;
            UIDragScrollView dragScrollView = go.GetComponent<UIDragScrollView>();
            dragScrollView = mDragScrollView;

        }
    }

    public static void NSetCellInfo()
    {
        NSetCellInfo();
    }
}
