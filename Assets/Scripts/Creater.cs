using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class Creater : MonoBehaviour
{
    public static string chooseTitle;
    public static CellData chooseCell;
    public static Dictionary<string, List<SpriteInfo>> spriteInfos = new Dictionary<string, List<SpriteInfo>>();

    public Transform[] cells;
    private CellData[,] cellInfos;
    private string MapPath = "Assets/Resources/";
    private string mapInfo = "test1.bytes";
    private string mapInfo2 = "test1.bytes";

    private void Awake()
    {
        Nglobal.creater = this;
    }

    private void Start()
    {
        spriteInfos = Nglobal.InitSpriteList();
        cellInfos = new CellData[11, 11];
    }

    public void Save()
    {
        InitializeCell1();
        Nglobal.readSource.CreateMap(MapPath, mapInfo, cellInfos);
    }

    public void Load()
    {
        Nglobal.readSource.LoadMap(mapInfo2, ref cellInfos);
        InitializeCell2();
    }

    public void Init()
    {
        Nglobal.readSource.InitMap(ref cells);
    }

    private void InitializeCell2()
    {
        for (int i = 0; i < cellInfos.GetLength(0); i++)
        {
            for (int j = 0; j < cellInfos.GetLength(1); j++)
            {
                if (cellInfos[i, j] == null)
                    continue;

                Transform tempTrans = cells[i * cellInfos.GetLength(0) + j];
                CellData tempData = tempTrans.GetComponent<ObjState>().CellInfo;
                tempData= cellInfos[i, j];
                tempTrans.name = tempData.sName;
                var atlas_go = Resources.Load<GameObject>("Art/UI/" + tempData.altas);
                UISprite mUISprite = tempTrans.GetComponent<UISprite>();
                mUISprite.atlas = atlas_go.GetComponent<UIAtlas>();
                mUISprite.GetComponent<UIButton>().normalSprite = tempData.sName;
            }
        }
    }

    private void InitializeCell1()
    {
        for (int i = 0; i < cellInfos.GetLength(0); i++)
        {
            for (int j = 0; j < cellInfos.GetLength(1); j++)
            {
                Transform tempTrans = cells[i * cellInfos.GetLength(0) + j];
                if (!tempTrans.name.Contains("cell"))
                {
                    CellData tempData = tempTrans.GetComponent<ObjState>().CellInfo;
                    cellInfos[i, j] = tempData;
                }
            }
        }
    }

    
}
