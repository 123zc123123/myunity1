using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DictionController : MonoBehaviour
{
    public static DictionController instance;

    [SerializeField]private GameObject dictionPanel;
    [SerializeField]private GameObject namePanel;
    [SerializeField] private List<Button> playerSelectButtonList;

    [SerializeField] private GameObject hPUI;

    public bool dictionOver;
    public bool textAppearOver;

    public int buttonIndex;

    public bool isPlayerSelect;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
            instance = this;
    }

    private void Start()
    {
        dictionPanel.SetActive(false);
        namePanel.SetActive(false);
        dictionOver = false;
        textAppearOver = true;
        isPlayerSelect = false;

        buttonIndex = -1;
        for (int i = 0; i < playerSelectButtonList.Count; i++)
        {
            Button currentButton = playerSelectButtonList[i];
            playerSelectButtonList[i].onClick.AddListener(() => GetDownButton(currentButton));
        }
        for (int i = 0; i < playerSelectButtonList.Count; i++) 
        {
            playerSelectButtonList[i].gameObject.SetActive(false);
        }

        
    }

    private void Update()
    {
        if (dictionOver) 
        {
            StopAllCoroutines();
        }
    }
    //面板设为活跃状态
    public void SetActivatePanel(bool _isDictionPanelActivate,bool _isNamePanelActivate) 
    {
        hPUI.SetActive(!_isDictionPanelActivate);
        dictionPanel.SetActive(_isDictionPanelActivate);
        namePanel.SetActive(_isNamePanelActivate);
    }
    //设置文本
    public void SetText(string _diction, int _nextTextIndex,string _name="Null") 
    {
        TextMeshProUGUI dictionText = dictionPanel.GetComponentInChildren<TextMeshProUGUI>();
        if (name != "Null")
            namePanel.GetComponentInChildren<TextMeshProUGUI>().text = _name;
        StartCoroutine(TextAppear(_diction, dictionText, _nextTextIndex));
    }
    //文本快速出现
    public void FastSetText(string _diction, int _nextTextIndex) 
    {
        StopAllCoroutines();
        dictionPanel.GetComponentInChildren<TextMeshProUGUI>().text = _diction;
       
        textAppearOver = true;
        StartCoroutine(WaitForSeconds(_nextTextIndex));
        
    }
    IEnumerator TextAppear(string _diction, TextMeshProUGUI _dictionText, int _nextTextIndex) 
    {
        string newText = "";
        textAppearOver = false;
        _dictionText.text = newText;
        
        foreach (char word in _diction) 
        {
            newText += word;
            _dictionText.text = newText;
            yield return new WaitForSeconds(0.1f);
        }
        textAppearOver = true;
        StartCoroutine(WaitForSeconds(_nextTextIndex));
    }
    IEnumerator WaitForSeconds(int _nextTextIndex) 
    {
        yield return new WaitForSeconds(0.1f);
        if (_nextTextIndex == -1 && textAppearOver == true)
            dictionOver = true;
    }

    //主要用于设置按钮的一些属性
    public void SetButton(bool isActivate, string _buttonText0 = "Null", string _buttonText1="Null", string _buttonText2 = "Null") 
    {
        if (isActivate)
        {
            isPlayerSelect = true;
            playerSelectButtonList[0].gameObject.SetActive(true);
            playerSelectButtonList[0].GetComponentInChildren<TextMeshProUGUI>().text = _buttonText0;
            if (_buttonText1 != "Null")
            {
                playerSelectButtonList[1].gameObject.SetActive(true);
                playerSelectButtonList[1].GetComponentInChildren<TextMeshProUGUI>().text = _buttonText1;
            }
            if (_buttonText2 != "Null")
            {
                playerSelectButtonList[2].gameObject.SetActive(true);
                playerSelectButtonList[2].GetComponentInChildren<TextMeshProUGUI>().text = _buttonText2;
            }
        }
        else 
        {
            for (int i = 0; i < playerSelectButtonList.Count; i++)
            {
                playerSelectButtonList[i].gameObject.SetActive(false);
            }
        }
    }

    //按下按钮后的任务
    public void GetDownButton(Button _currentButton) 
    {
        for (int i = 0; i < playerSelectButtonList.Count; i++)
        {
            if (playerSelectButtonList[i] == _currentButton)
            {
                buttonIndex = i;
                _currentButton.GetComponent<RectTransform>().sizeDelta /= new Vector2(1.2f, 1.2f);
            }
        }
        
    }
}
