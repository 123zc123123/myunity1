using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FindDataHandle 
{
    private string dataSaveDir;
    private string dataSaveFile;

    //����
    private bool isEncrypt;
    private string encryptData;

    public FindDataHandle(string _dir,string _file,bool _isEncrypt) 
    {
        dataSaveDir = _dir;
        dataSaveFile = _file;
        isEncrypt = _isEncrypt;
        encryptData = "zqy";
    }

    //����
    public void Save(SaveStruct _saveData) 
    {
        //���·��
        string fullPath = Path.Combine(dataSaveDir, dataSaveFile);
        //tryΪ�������У������ȥcatch�Ҷ�Ӧ�Ĵ��󣨻�ִ�в�ͬ���ݣ���Ȼ�����finally�д��������Ƿ񱨴���ִ��
        try 
        {
            //����Ϊ�ҵ���Ӧ���ļ�·��������Ϊ�����ļ�����������ڣ�
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //�����ݱ��json����
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
        //Exception�����쳣�Ļ��࣬e�Ǳ�����
        catch (Exception e) { Debug.LogError("�洢���ݵ�ʱ��������" + fullPath + "\n" + e); }
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
                //�����л�
                dataLoad = JsonUtility.FromJson<SaveStruct>(loadData);
            }
            catch (Exception e) { Debug.LogError("��ȡ���ݵ�ʱ��������" + fullPath + "\n" + e); }
        }
        return dataLoad;
    }


    public void DeleteData() 
    {
        string fullPath = Path.Combine(dataSaveDir, dataSaveFile);
        if (File.Exists(fullPath))
            File.Delete(fullPath);
    }

    //����
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
    //����
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
