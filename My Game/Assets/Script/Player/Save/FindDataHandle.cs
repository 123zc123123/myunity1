using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FindDataHandle 
{
    private string dataSaveDir;
    private string dataSaveFile;

    //加密
    private bool isEncrypt;
    private string encryptData;

    public FindDataHandle(string _dir,string _file,bool _isEncrypt) 
    {
        dataSaveDir = _dir;
        dataSaveFile = _file;
        isEncrypt = _isEncrypt;
        encryptData = "zqy";
    }

    //保存
    public void Save(SaveStruct _saveData) 
    {
        //组合路径
        string fullPath = Path.Combine(dataSaveDir, dataSaveFile);
        //try为尝试运行，报错就去catch找对应的错误（会执行不同内容），然后最后finally中代码无论是否报错都会执行
        try 
        {
            //里面为找到对应的文件路径，外面为创建文件（如果不存在）
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //把内容变成json类型
            string dataToJson = JsonUtility.ToJson(_saveData,true);

            if (isEncrypt) 
            {
                dataToJson = EncryptData(dataToJson);
            }


            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create)) 
            {
                using (StreamWriter writerStream = new StreamWriter(fileStream)) 
                {
                    writerStream.Write(dataToJson);
                }
            }

        }
        //Exception所有异常的基类，e是变量名
        catch (Exception e) { Debug.LogError("存储数据的时候发生错误" + fullPath + "\n" + e); }
    }

    public SaveStruct Load() 
    {
        string fullPath = Path.Combine(dataSaveDir, dataSaveFile);
        SaveStruct dataLoad=null;
        if (File.Exists(fullPath)) 
        {
            try 
            {
                string loadData = "";
                using (FileStream fileStream = new FileStream(fullPath, FileMode.Open)) 
                {
                    using (StreamReader streamReader = new StreamReader(fileStream)) 
                    {
                        loadData = streamReader.ReadToEnd();
                    }
                }
                if (isEncrypt)
                {
                    loadData = UnencryptData(loadData);
                }
                //反序列化
                dataLoad = JsonUtility.FromJson<SaveStruct>(loadData);
            }
            catch (Exception e) { Debug.LogError("读取数据的时候发生错误" + fullPath + "\n" + e); }
        }
        return dataLoad;
    }


    public void DeleteData() 
    {
        string fullPath = Path.Combine(dataSaveDir, dataSaveFile);
        if (File.Exists(fullPath))
            File.Delete(fullPath);
    }

    //加密
    public string EncryptData(string _data) 
    {
        int index = 0;
        string finallyData="";
        for (int i=0;i<_data.Length;i++) 
        {
            finallyData+=(char) (_data[i]*encryptData[index]);
            index += 1;
            if (index >= 3) 
            {
                index = 0;
            }
        }
        return finallyData;
    }
    //解密
    public string UnencryptData(string _data)
    {
        int index = 0;
        string finallyData = "";
        for (int i = 0; i < _data.Length; i++)
        {
            finallyData += (char)(_data[i] / encryptData[index]);
            index += 1;
            if (index >= 3)
            {
                index = 0;
            }
        }
        return finallyData;
    }
}
