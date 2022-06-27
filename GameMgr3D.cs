using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMgr3D : MonoBehaviour
{
    // ��Ϸ�������
    public Transform endPanel;

    // ��Ϸ��ʼ�ͽ����ı�־
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        RestartGame();
        BackMainMenu();
        Back();
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }


    // ����Esc������Ϸ��ͣ
    void Pause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (endPanel.gameObject.activeSelf == false)
            {
                Time.timeScale = 0;
                endPanel.gameObject.SetActive(true);
                endPanel.Find("title").GetComponent<Text>().text = string.Format("Waiting");
            }
        }
    }


    void RestartGame()
    {
        endPanel.Find("btnRestart").GetComponent<Button>().onClick.AddListener(delegate() {
            Time.timeScale = 1;
            SceneManager.LoadScene("Mars");
        });

    }


    void BackMainMenu()
    {
        endPanel.Find("btnBackMainMenu").GetComponent<Button>().onClick.AddListener(delegate() {
            Time.timeScale = 1;
            SceneManager.LoadScene("StartScene");
        });
    }

    // ����Back������Ϸ��ʼ
    void Back()
    {
        endPanel.Find("btnBack").GetComponent<Button>().onClick.AddListener(delegate() {
            Time.timeScale = 1;
            endPanel.gameObject.SetActive(false);
            
        });
    }

    // ����չ
    public void GameOver()
    {
        endPanel.gameObject.SetActive(true);
        endPanel.Find("title").GetComponent<Text>().text = string.Format("Game Over");
        endPanel.Find("btnBack").GetComponent<Button>().gameObject.SetActive(false);
        isGameOver = true;
    }

}
