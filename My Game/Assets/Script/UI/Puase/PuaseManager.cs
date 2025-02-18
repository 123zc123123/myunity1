using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuaseManager : MonoBehaviour
{
    public static PuaseManager instance;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button settingButton;

    [SerializeField] private GameObject pausePanel;

    [SerializeField] private List<GameObject> otherPanels;
    [SerializeField] private string panelName;

    //是否暂停
    public bool isPause;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        panelName = "Null";
        isPause = false;
        
       continueButton.onClick.AddListener(() => SetContinueButton());
        exitButton.onClick.AddListener(() => SetExitButton());

        pausePanel.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&isPause==false) 
        {
            SetPausePanelActivate();
        }
    }
    //保存游戏然后回到初始界面。
    private void SetExitButton()
    {
        SaveManager.instance.SaveGame();
        panelName = "Null";
        isPause = false;
        Time.timeScale = 1;
        exitButton.GetComponent<RectTransform>().sizeDelta /= new Vector2(1.2f, 1.2f);
        SceneManager.LoadScene("StartScene");
    }
    //当暂停面板启动时，其他面板都设置为false,记录当前存在激活的面板，方便继续游戏时重新启用面板
    private void SetPausePanelActivate() 
    {
        foreach (GameObject panel in otherPanels) 
        {
            if (panel.activeSelf == true)
            {
                panelName = panel.name;
                panel.SetActive(false);
            }
        }
       
        Time.timeScale = 0;
        isPause = true;
        pausePanel.SetActive(true);
    }

    private void SetContinueButton()
    {
        if (panelName != "Null")
        {
            foreach (GameObject panel in otherPanels)
            {
                if (panelName == panel.name)
                {
                    panel.SetActive(true);
                }
            }
            panelName = "Null";
        }
        continueButton.GetComponent<RectTransform>().sizeDelta /= new Vector2(1.2f, 1.2f);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(WaitForContinue());
    }
    IEnumerator WaitForContinue() 
    {
        yield return new WaitForSeconds(0.5f);
        isPause = false;
    }
}
