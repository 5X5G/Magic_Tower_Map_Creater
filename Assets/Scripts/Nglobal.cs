using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nglobal : MonoBehaviour {

    public enum DictionaryName
    {
        Item,
        Character,
        Monster,
        Wall,
    }
    public static Nglobal instance;
    public static ReadSource readSource;

    private void Awake()
    {
        if(instance!=null)
            instance = this;

        Init();
    }

    #region 贴图资源
    public static List<SpriteInfo> itemList = new List<SpriteInfo>();
    public static List<SpriteInfo> monsterList = new List<SpriteInfo>();
    public static List<SpriteInfo> wallList = new List<SpriteInfo>();
    public static List<SpriteInfo> characterList = new List<SpriteInfo>();
    #endregion

    private void Init()
    {
        readSource = new ReadSource();
        InitSpriteList();
    }

    private void InitSpriteList()
    {
        itemList = readSource.LoadSpiteName(DictionaryName.Item.ToString());
        monsterList = readSource.LoadSpiteName(DictionaryName.Monster.ToString());
        wallList = readSource.LoadSpiteName(DictionaryName.Wall.ToString());
        characterList = readSource.LoadSpiteName(DictionaryName.Character.ToString());
    }
}
