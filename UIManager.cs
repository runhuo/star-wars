using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Transform m_StartPanel; // 开始界面
    public Transform m_AboutPanel; // 关于我们界面
    public Transform m_SelectPanel; // 选择关卡界面
    public Transform m_ChoosePanel; // 选择飞机界面

    public int airplaneId = 1; //  飞机编号
    private Stack<Transform> panelStack = new Stack<Transform>(); // 栈结构用于管理Panel先后层级


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        InitPanel();
        InitButtonListener();

    }
    
    void InitPanel()
    {
        m_StartPanel = transform.Find("GameUI/StartPanel");
        m_AboutPanel = transform.Find("GameUI/AboutPanel");
        m_SelectPanel = transform.Find("GameUI/SelectPanel");
        m_ChoosePanel = transform.Find("GameUI/ChoosePanel");
    }



    void InitButtonListener()
    {
        StratPanelButton();
        AboutPanelButton();
        SelectPanelButton();
        ChoosePanelButton();


    }

    // StratPanel Button 设置
    void StratPanelButton()
    {
        // 开始游戏 Button
        m_StartPanel.Find("btnStart").GetComponent<Button>().onClick.AddListener(delegate () {
            m_StartPanel.gameObject.SetActive(false);
            panelStack.Push(m_StartPanel);
            m_ChoosePanel.gameObject.SetActive(true);
            // SceneManager.LoadScene("");
        });

        // 选择关卡 Button
        m_StartPanel.Find("btnSelect").GetComponent<Button>().onClick.AddListener(delegate () {
            m_StartPanel.gameObject.SetActive(false);
            panelStack.Push(m_StartPanel);
            m_SelectPanel.gameObject.SetActive(true);
        });

        // 关于我们 Button
        m_StartPanel.Find("btnAbout").GetComponent<Button>().onClick.AddListener(delegate() {
            m_StartPanel.gameObject.SetActive(false);
            panelStack.Push(m_StartPanel);
            m_AboutPanel.gameObject.SetActive(true);
        });
    }

    // SelectPanel Button 设置
    void SelectPanelButton()
    {
        // Level1  Button
        m_SelectPanel.Find("btnLevel1").GetComponent<Button>().onClick.AddListener(delegate() {
            m_SelectPanel.gameObject.SetActive(false);
            panelStack.Push(m_SelectPanel);
            m_ChoosePanel.gameObject.SetActive(true);
        });

        // Level2 Button 跳转到3D场景
        m_SelectPanel.Find("btnLevel2").GetComponent<Button>().onClick.AddListener(delegate () {
            SceneManager.LoadScene("Mars");
            m_ChoosePanel.gameObject.SetActive(false);

        });

        // 返回上一个界面 Button
        m_SelectPanel.Find("btnBack").GetComponent<Button>().onClick.AddListener(delegate() {
            m_SelectPanel.gameObject.SetActive(false);
            Transform topPanel = panelStack.Pop();
            topPanel.gameObject.SetActive(true);
        });
    }

    // AboutPanel Button 设置
    void AboutPanelButton()
    {
        // 返回上一个界面 Button
        m_AboutPanel.Find("btnBack").GetComponent<Button>().onClick.AddListener(delegate () {
            m_AboutPanel.gameObject.SetActive(false);
            Transform topPanel = panelStack.Pop();
            topPanel.gameObject.SetActive(true);
        });
    }

    // ChoosePanel Buuton 设置
    void ChoosePanelButton()
    {

        // 选择1号飞机
        m_ChoosePanel.Find("AirPlane1").GetComponent<Button>().onClick.AddListener(delegate() 
        {
            SceneManager.LoadScene("SpaceShooter");
            airplaneId = 1;  // 更换模型
            m_ChoosePanel.gameObject.SetActive(false);
        });

        // 选择2号飞机
        m_ChoosePanel.Find("AirPlane2").GetComponent<Button>().onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("SpaceShooter");
            airplaneId = 2; // 更换模型
            m_ChoosePanel.gameObject.SetActive(false);
        });

        // 选择3号飞机
        m_ChoosePanel.Find("AirPlane3").GetComponent<Button>().onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("SpaceShooter");
            airplaneId = 3; // 更换模型
            m_ChoosePanel.gameObject.SetActive(false);
        });

        // 选择4号飞机
        m_ChoosePanel.Find("AirPlane4").GetComponent<Button>().onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("SpaceShooter");
            airplaneId = 4; // 更换模型
            m_ChoosePanel.gameObject.SetActive(false);
        });

        // 返回上一个界面 Button
        m_ChoosePanel.Find("btnBack").GetComponent<Button>().onClick.AddListener(delegate () {
            m_ChoosePanel.gameObject.SetActive(false);
            Transform topPanel = panelStack.Pop();
            topPanel.gameObject.SetActive(true);
        });
    }

}

