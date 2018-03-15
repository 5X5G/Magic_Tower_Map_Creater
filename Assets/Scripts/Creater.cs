using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creater : MonoBehaviour
{
    public static string chooseTitle;
    public static CellData chooseCell;
    public static Dictionary<string, List<SpriteInfo>> spriteInfos = new Dictionary<string, List<SpriteInfo>>();

    public static NTableTitleData nTableTitleData;

    private void Awake()
    {
        Nglobal.creater = this;
    }

    private void Start()
    {
        spriteInfos = Nglobal.InitSpriteList();
        nTableTitleData = new NTableTitleData();
    }

}
