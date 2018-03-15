using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nglobal : Singleton<Nglobal> {

    public enum DictionaryName
    {
        Item,
        Character,
        Monster,
        Wall,
    }

    public static Nglobal nglobal;
    public static ReadSource readSource;
    public static PoolManager poolManager;    
    public static Creater creater;

    private void Start()
    {
        Init();
        SceneManager.LoadScene("Create");
    }
    private void Init()
    {
        nglobal = Instance;
        DontDestroyOnLoad(this.gameObject);
        readSource = ReadSource.Instance;
        poolManager = PoolManager.Instance;
    }

    public static Dictionary<string, List<SpriteInfo>> InitSpriteList()
    {
        Dictionary<string, List<SpriteInfo>> spriteInfos = new Dictionary<string, List<SpriteInfo>>();
        foreach (DictionaryName name in Enum.GetValues(typeof(DictionaryName)))
        {
            List<SpriteInfo> tempList = readSource.LoadSpiteName(name.ToString());
            spriteInfos.Add(name.ToString(), tempList);
        }
        return spriteInfos;
    }
}
