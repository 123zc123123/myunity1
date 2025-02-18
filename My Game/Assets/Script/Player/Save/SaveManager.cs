using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private FindDataHandle dataHandle;

    private string fileName;
    private bool isEncrypt;

    private SaveStruct saveData;
    private List<ISave> iSaves;

    public string sceneName;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        fileName = "FirstData";
        sceneName = "FirstScene";
        isEncrypt = false;
        dataHandle = new FindDataHandle(Application.persistentDataPath, fileName, isEncrypt);

        iSaves = FindAllISave();
        StartCoroutine(WaitForLoad());
    }

    public void SaveGame() 
    {
        foreach (ISave iSave in iSaves) 
        {
            iSave.Save(ref saveData);
        }
        dataHandle.Save(saveData);
    }

    IEnumerator WaitForLoad() 
    {
        yield return new WaitForSeconds(0.5f);
        LoadGame();
    }
    public void LoadGame() 
    {
        saveData = dataHandle.Load();
        if (this.saveData == null) 
        {
            NewGame();
        }
        foreach (ISave iLoad in iSaves)
        {
            iLoad.Load(saveData);
        }
        sceneName = saveData.sceneName;
    }
    public void NewGame() 
    {
        saveData = new SaveStruct();
    }

    private List<ISave> FindAllISave() 
    {
        //先找到所有带MonoBehaviour的脚本，包括未激活，然后找到带ISave的脚本
        IEnumerable<ISave> newISave = FindObjectsOfType<MonoBehaviour>(true).OfType<ISave>();
        return new List<ISave>(newISave);
    }

    public void DeleteSaveData() 
    {
        dataHandle = new FindDataHandle(Application.persistentDataPath, fileName, isEncrypt);
        dataHandle.DeleteData();
    }

    public bool HaveSaveData() 
    {
        if (dataHandle.Load() != null)
            return true;
        return false;
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
