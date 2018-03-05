using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadSource:MonoBehaviour
{
    private string path = "Assets/Art/UI/";
    private List<SpriteInfo> spriteInfoList = new List<SpriteInfo>();

    public List<SpriteInfo> LoadSpiteName(string dictionary)
    {       
        string currentPath = path + dictionary;
        if (Directory.Exists(currentPath))
        {
            DirectoryInfo directory = new DirectoryInfo(currentPath);
            FileInfo[] temp_FileInfo = directory.GetFiles();
            ArrayList fileInfos = new ArrayList();
            foreach (var file in temp_FileInfo)
            {
                if (!file.Name.Contains(".meta"))
                {
                    SpriteInfo temp = new SpriteInfo();
                    temp.fileinfo = file;
                    string[] nameList = file.Name.Split('.');
                    temp.name = nameList[0];
                    temp.name_extra = nameList[1];
                    spriteInfoList.Add(temp);
                    Debug.Log(file);
                }
            }
        }
        return spriteInfoList;
    }

}