using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadSource:Singleton<ReadSource>
{
    private string UIpath = "Assets/Art/UI/";
    private Vector2 vec = new Vector2(0, 600);
    private string previewName = "gray";
    private int length = 11;

    public List<SpriteInfo> LoadSpiteName(string dictionary)
    {
        List<SpriteInfo> spriteInfoList = new List<SpriteInfo>();
        string currentPath = UIpath + dictionary;
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
                    temp.parent = directory.Name;
                    spriteInfoList.Add(temp);
                    Debug.Log(file);
                }
            }
        }
        return spriteInfoList;
    }

    public void CreateMap(string path1, string path2, CellData[,] cellInfos)
    {
        StreamWriter sw;
        if (File.Exists(path1 + path2))
        {
            File.Delete(path1 + path2);
        }
        sw = File.CreateText(path1 + path2);
        sw.WriteLine("0#");
        for (int i = 0; i < cellInfos.GetLength(0); i++)
        {
            for (int j = 0; j < cellInfos.GetLength(1); j++)
            {
                if (cellInfos[i, j] == null)
                    sw.Write("null");
                else
                    sw.Write(cellInfos[i,j].altas+","+ cellInfos[i, j].sName);

                if (j == cellInfos.GetLength(1)-1)
                    sw.Write("\n");
                else
                    sw.Write("@");
            }
        }
        sw.Close();

    }

    public void LoadMap(string mapFile,ref CellData[,] cellInfos)
    {
        string[] path = mapFile.Split('.');
        TextAsset textAsset = Resources.Load(path[0]) as TextAsset;
        //去除最后的\n
        string mapArray = textAsset.text.Remove(textAsset.text.Length - 1);
        string[] mapLines = mapArray.Split('\n');

        int floor = 0;
        int line = 0;
        for (int i = 0; i < mapLines.Length; i++)
        {            
            if (mapLines[i].Contains("#"))
            {
                string[] temp = mapLines[i].Split('#');
                floor = int.Parse(temp[0]);
                line = 0;
                continue;
            }

            int realLine = floor * (length + 1) + line + 1;
            string[] mapLineInfo = mapLines[realLine].Split('@');
            for (int j = 0; j < mapLineInfo.Length; j++)
            {
                if (mapLineInfo[j] == "null")
                    continue;
                CellData tempData = new CellData();
                string[] names = mapLineInfo[j].Split(',');
                tempData.altas = names[0];
                tempData.sName = names[1];
                cellInfos[line, j] = tempData;
            }
            line++;
        }
    }

}