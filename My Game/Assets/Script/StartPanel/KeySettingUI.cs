using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeySettingUI : MonoBehaviour,ISave
{
    //键值对
    private Dictionary<string, KeyCode> keyControllerPair;
    //全部使用一个，保证同时只有一个能修改,意思是正在修改
    private bool isSetKey = false;

    private Button currentSetButton;
    //提示文本设置
    [SerializeField] private List<TextMeshProUGUI> promptTexts;
    private bool[] textActivate;

    [SerializeField] private List<Button> keyButtons;
    //避免重复按键
    [SerializeField] private List<KeyCode> keyCodes;

    [SerializeField] private Button exitButton;

    [SerializeField] private DataBase dataBase;

    [SerializeField] private StartUI startUI;
    private void Start()
    {
        keyControllerPair = new Dictionary<string, KeyCode>();
        keyCodes = new List<KeyCode>();

        //玩家改过按键就从数据文件中读取玩家改了的按键,否则就使用基础按键
        if (dataBase.keyControllerPair.ContainsKey("Up"))
        {
            keyControllerPair["Up"] = dataBase.keyControllerPair["Up"];
            keyControllerPair["Down"] = dataBase.keyControllerPair["Down"];
            keyControllerPair["Left"] = dataBase.keyControllerPair["Left"];
            keyControllerPair["Right"] = dataBase.keyControllerPair["Right"];
            keyControllerPair["Attack"] = dataBase.keyControllerPair["Attack"];
            keyControllerPair["Skill1"] = dataBase.keyControllerPair["Skill1"];
            keyControllerPair["Skill2"] = dataBase.keyControllerPair["Skill2"];
            keyControllerPair["Jump"] = dataBase.keyControllerPair["Jump"];
            keyControllerPair["Map"] = dataBase.keyControllerPair["Map"];
            keyControllerPair["Skill3"] = dataBase.keyControllerPair["Skill3"];
            keyControllerPair["Crush"] = dataBase.keyControllerPair["Crush"];
        }
        else
        {
            keyControllerPair["Up"] = KeyCode.W;
            keyControllerPair["Down"] = KeyCode.S;
            keyControllerPair["Left"] = KeyCode.A;
            keyControllerPair["Right"] = KeyCode.D;
            keyControllerPair["Attack"] = KeyCode.J;
            keyControllerPair["Skill1"] = KeyCode.U;
            keyControllerPair["Skill2"] = KeyCode.I;
            keyControllerPair["Jump"] = KeyCode.K;
            keyControllerPair["Map"] = KeyCode.M;
            keyControllerPair["Skill3"] = KeyCode.O;
            keyControllerPair["Crush"] = KeyCode.L;
        }
        
        SetStartKeyCodes();

        //提示文字
        textActivate = new bool[3];
        for (int i = 0; i < textActivate.Length; i++)
        {
            textActivate[i] = false;
        }

        SetButtonEvent();
        foreach (var kvp in keyControllerPair)
        {
            dataBase.keyControllerPair[kvp.Key] = kvp.Value;
        }
        this.gameObject.SetActive(false);
    }

    private void SetButtonEvent()
    {
        for (int i = 0; i < keyButtons.Count; i++)
        {
            Button currentButton = keyButtons[i];
            keyButtons[i].onClick.AddListener(() => GetDownKeyButton(currentButton));
        }
        exitButton.onClick.AddListener(() => GetDownExitButton());
    }
    //将按键添加到列表里面，用于判断是否存在，避免重复按键
    private void SetStartKeyCodes()
    {
        keyCodes.Add(keyControllerPair["Up"]);
        keyCodes.Add(keyControllerPair["Down"]);
        keyCodes.Add(keyControllerPair["Left"]);
        keyCodes.Add(keyControllerPair["Right"]);
        keyCodes.Add(keyControllerPair["Attack"]);
        keyCodes.Add(keyControllerPair["Skill1"]);
        keyCodes.Add(keyControllerPair["Skill2"]);
        keyCodes.Add(keyControllerPair["Jump"]);
        keyCodes.Add(keyControllerPair["Map"]);
        keyCodes.Add(keyControllerPair["Skill3"]);
        keyCodes.Add(keyControllerPair["Crush"]);
    }

    private void Update()
    {
        UpdateKeyButtonText();
        TextDisappear();
    }
    //一帧一调用
    private void OnGUI()
    {
        if (isSetKey)
        {
            Event keyCodeEvent = Event.current;
            if (keyCodeEvent != null && keyCodeEvent.isKey && keyCodeEvent.keyCode != KeyCode.None)
            {

                //特殊按钮不能设置
                if (keyCodeEvent.keyCode == KeyCode.Escape)
                {
                    textActivate[0] = true;
                    return;
                }
                //重复按钮不能设置
                if (IsRepeatKey(keyCodeEvent.keyCode))
                {
                    textActivate[1] = true;
                    return;
                }

                //如果可以设置，就去修改字典和列表里面的值（按钮文本会自动设置，并且改变颜色）
                UpdateKeyCodes(keyCodeEvent.keyCode, keyControllerPair[currentSetButton.gameObject.name]);
                keyControllerPair[currentSetButton.gameObject.name] = keyCodeEvent.keyCode;
                Image buttonImage = currentSetButton.image;
                buttonImage.color = new Color(1f, 1f, 1f, 1f);
                isSetKey = false;
            }
            else
            {
                MouseInput();
            }
        }
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsRepeatKey(KeyCode.Mouse0))
            {
                textActivate[1] = true;
                return;
            }
            UpdateKeyCodes(KeyCode.Mouse0, keyControllerPair[currentSetButton.gameObject.name]);
            keyControllerPair[currentSetButton.gameObject.name] = KeyCode.Mouse0;
            Image buttonImage = currentSetButton.image;
            buttonImage.color = new Color(1f, 1f, 1f, 1f);
            isSetKey = false;
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (IsRepeatKey(KeyCode.Mouse1))
            {
                textActivate[1] = true;
                return;
            }
            UpdateKeyCodes(KeyCode.Mouse1, keyControllerPair[currentSetButton.gameObject.name]);
            keyControllerPair[currentSetButton.gameObject.name] = KeyCode.Mouse1;
            Image buttonImage = currentSetButton.image;
            buttonImage.color = new Color(1f, 1f, 1f, 1f);
            isSetKey = false;

        }
        if (Input.GetMouseButtonDown(2))
        {
            if (IsRepeatKey(KeyCode.Mouse2))
            {
                textActivate[1] = true;
                return;
            }
            UpdateKeyCodes(KeyCode.Mouse2, keyControllerPair[currentSetButton.gameObject.name]);
            keyControllerPair[currentSetButton.gameObject.name] = KeyCode.Mouse2;
            Image buttonImage = currentSetButton.image;
            buttonImage.color = new Color(1f, 1f, 1f, 1f);
            isSetKey = false;
        }

    }

    //用于更新按钮上的文本
    private void UpdateKeyButtonText()
    {
        TextMeshProUGUI buttonText;
        for (int i = 0; i < keyButtons.Count; i++)
        {
            buttonText = keyButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = keyControllerPair[keyButtons[i].gameObject.name].ToString();
        }
    }

    private void GetDownKeyButton(Button _button)
    {
        if (isSetKey == true)
            return;
        isSetKey = true;
        currentSetButton = _button;
        Image buttonImage = _button.image;
        buttonImage.color = new Color(0.81f, 0.73f, 0.62f, 1f);
        textActivate[2] = true;

    }
    private void TextDisappear()
    {
        //默认三个，后续可修改,此处可并行
        if (textActivate[0])
        {
            promptTexts[0].gameObject.SetActive(true);
            Color textColor = promptTexts[0].color;
            textColor.a -= Time.deltaTime*0.8f;
            promptTexts[0].color = textColor;
            if (promptTexts[0].color.a <= 0)
            {
                textActivate[0] = false;
                promptTexts[0].gameObject.SetActive(false);
                textColor = promptTexts[0].color;
                textColor.a = 1;
                promptTexts[0].color = textColor;
            }
        }
        if (textActivate[1])
        {
            promptTexts[1].gameObject.SetActive(true);
            Color textColor = promptTexts[1].color;
            textColor.a -= Time.deltaTime*0.8f;
            promptTexts[1].color = textColor;
            if (promptTexts[1].color.a <= 0)
            {
                textActivate[1] = false;
                promptTexts[1].gameObject.SetActive(false);
                textColor = promptTexts[1].color;
                textColor.a = 1;
                promptTexts[1].color = textColor;
            }
        }
        if (textActivate[2])
        {
            promptTexts[2].gameObject.SetActive(true);
            Color textColor = promptTexts[2].color;
            textColor.a -= Time.deltaTime*0.8f;
            promptTexts[2].color = textColor;
            if (promptTexts[2].color.a <= 0)
            {
                textActivate[2] = false;
                promptTexts[2].gameObject.SetActive(false);
                textColor = promptTexts[2].color;
                textColor.a = 1;
                promptTexts[2].color = textColor;
            }
        }
    }

    private bool IsRepeatKey(KeyCode _keyCode)
    {
        if (keyControllerPair[currentSetButton.gameObject.name] == _keyCode)
            return false;
        for (int i = 0; i < keyCodes.Count; i++)
        {
            if (_keyCode == keyCodes[i])
                return true;
        }
        return false;
    }

    public void GetDownExitButton()
    {
        exitButton.GetComponent<RectTransform>().sizeDelta /= new Vector2(1.2f, 1.2f);
        dataBase.keyControllerPair = keyControllerPair;
        this.gameObject.SetActive(false);
        startUI.gameObject.SetActive(true);
    }
    private void UpdateKeyCodes(KeyCode _addKeyCode, KeyCode _removeKeyCode)
    {
        keyCodes.Add(_addKeyCode);
        keyCodes.Remove(_removeKeyCode);
    }

    public void Save(ref SaveStruct _saveDate)
    {
        foreach (var kvp in dataBase.keyControllerPair) 
        {
            _saveDate.dataBaseDict[kvp.Key] = (int)kvp.Value;
        }
    }

    public void Load(SaveStruct _loadDate)
    {

        if (_loadDate.dataBaseDict.Count>0)
        {
            foreach (var kvp in _loadDate.dataBaseDict)
            {
                keyControllerPair[kvp.Key] = (KeyCode)kvp.Value;
            }
            SetStartKeyCodes();
        }
    }
}
