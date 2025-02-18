using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    [SerializeField] private KeySettingUI keySettingUI;

    [SerializeField] private Button startGameButton;

    [SerializeField] private Button continueButton;

    [SerializeField] private Button exitGameButton;

    [SerializeField] private Button settingKeyButton;

    private SaveManager saveManager;

    private void Start()
    {
        saveManager = SaveManager.instance;
        ButtonClickEvent();
        if (saveManager.HaveSaveData() == false)
        {
            continueButton.image.color = new Color32(0x61, 0x56, 0x56, 0xFF);
        }
        else 
        {
            continueButton.onClick.AddListener(() => LoadContinue());
            continueButton.image.color = new Color(1, 1, 1, 1);
        }
    }



    private void ButtonClickEvent()
    {
        startGameButton.onClick.AddListener(() => LoadGame());

        exitGameButton.onClick.AddListener(() => ExitGame());
        settingKeyButton.onClick.AddListener(() => LoadKeySetting());
    }

    //������ȥ���ı��С���л�����Ҫ�ı��С��
    public void LoadGame() 
    {
        startGameButton.GetComponent<RectTransform>().sizeDelta /= new Vector2(1.2f, 1.2f);
        saveManager.DeleteSaveData();
        SceneManager.LoadScene("FirstScene");

    }
   
    //����һ�����ý���
    public void LoadContinue()
    {
        continueButton.GetComponent<RectTransform>().sizeDelta /= new Vector2(1.2f, 1.2f);
        saveManager.LoadGame();
        SceneManager.LoadScene(saveManager.sceneName);
    }

    //����һ���������ý���
    public void LoadKeySetting()
    {
        settingKeyButton.GetComponent<RectTransform>().sizeDelta /= new Vector2(1.2f, 1.2f);
        keySettingUI.gameObject.SetActive(true);
        this.gameObject.SetActive(false);

    }

    public void ExitGame()
    {
        exitGameButton.GetComponent<RectTransform>().sizeDelta /= new Vector2(1.2f, 1.2f);
        Application.Quit();
    }
}
