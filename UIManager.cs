using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Transform m_StartPanel; // ��ʼ����
    public Transform m_AboutPanel; // �������ǽ���
    public Transform m_SelectPanel; // ѡ��ؿ�����
    public Transform m_ChoosePanel; // ѡ��ɻ�����

    public int airplaneId = 1; //  �ɻ����
    private Stack<Transform> panelStack = new Stack<Transform>(); // ջ�ṹ���ڹ���Panel�Ⱥ�㼶


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

    // StratPanel Button ����
    void StratPanelButton()
    {
        // ��ʼ��Ϸ Button
        m_StartPanel.Find("btnStart").GetComponent<Button>().onClick.AddListener(delegate () {
            m_StartPanel.gameObject.SetActive(false);
            panelStack.Push(m_StartPanel);
            m_ChoosePanel.gameObject.SetActive(true);
            // SceneManager.LoadScene("");
        });

        // ѡ��ؿ� Button
        m_StartPanel.Find("btnSelect").GetComponent<Button>().onClick.AddListener(delegate () {
            m_StartPanel.gameObject.SetActive(false);
            panelStack.Push(m_StartPanel);
            m_SelectPanel.gameObject.SetActive(true);
        });

        // �������� Button
        m_StartPanel.Find("btnAbout").GetComponent<Button>().onClick.AddListener(delegate() {
            m_StartPanel.gameObject.SetActive(false);
            panelStack.Push(m_StartPanel);
            m_AboutPanel.gameObject.SetActive(true);
        });
    }

    // SelectPanel Button ����
    void SelectPanelButton()
    {
        // Level1  Button
        m_SelectPanel.Find("btnLevel1").GetComponent<Button>().onClick.AddListener(delegate() {
            m_SelectPanel.gameObject.SetActive(false);
            panelStack.Push(m_SelectPanel);
            m_ChoosePanel.gameObject.SetActive(true);
        });

        // Level2 Button ��ת��3D����
        m_SelectPanel.Find("btnLevel2").GetComponent<Button>().onClick.AddListener(delegate () {
            SceneManager.LoadScene("Mars");
            m_ChoosePanel.gameObject.SetActive(false);

        });

        // ������һ������ Button
        m_SelectPanel.Find("btnBack").GetComponent<Button>().onClick.AddListener(delegate() {
            m_SelectPanel.gameObject.SetActive(false);
            Transform topPanel = panelStack.Pop();
            topPanel.gameObject.SetActive(true);
        });
    }

    // AboutPanel Button ����
    void AboutPanelButton()
    {
        // ������һ������ Button
        m_AboutPanel.Find("btnBack").GetComponent<Button>().onClick.AddListener(delegate () {
            m_AboutPanel.gameObject.SetActive(false);
            Transform topPanel = panelStack.Pop();
            topPanel.gameObject.SetActive(true);
        });
    }

    // ChoosePanel Buuton ����
    void ChoosePanelButton()
    {

        // ѡ��1�ŷɻ�
        m_ChoosePanel.Find("AirPlane1").GetComponent<Button>().onClick.AddListener(delegate() 
        {
            SceneManager.LoadScene("SpaceShooter");
            airplaneId = 1;  // ����ģ��
            m_ChoosePanel.gameObject.SetActive(false);
        });

        // ѡ��2�ŷɻ�
        m_ChoosePanel.Find("AirPlane2").GetComponent<Button>().onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("SpaceShooter");
            airplaneId = 2; // ����ģ��
            m_ChoosePanel.gameObject.SetActive(false);
        });

        // ѡ��3�ŷɻ�
        m_ChoosePanel.Find("AirPlane3").GetComponent<Button>().onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("SpaceShooter");
            airplaneId = 3; // ����ģ��
            m_ChoosePanel.gameObject.SetActive(false);
        });

        // ѡ��4�ŷɻ�
        m_ChoosePanel.Find("AirPlane4").GetComponent<Button>().onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("SpaceShooter");
            airplaneId = 4; // ����ģ��
            m_ChoosePanel.gameObject.SetActive(false);
        });

        // ������һ������ Button
        m_ChoosePanel.Find("btnBack").GetComponent<Button>().onClick.AddListener(delegate () {
            m_ChoosePanel.gameObject.SetActive(false);
            Transform topPanel = panelStack.Pop();
            topPanel.gameObject.SetActive(true);
        });
    }

}

