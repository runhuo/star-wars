using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    // 单例模式
    public static GameMgr Instance;

    // 敌人
    public GameObject[] enemys;

    // 飞机
    public GameObject[] airplane;

    //每生成一个敌人的间隔
    public float spawnWait;
    //每一波敌人的数量
    public int waveCount;

    //每波敌人间的等待时间
    public float waveWait;

    //启动游戏后开始生成敌人的等待时间
    public float startWait;

    //UI相关

    // 当前分数
    private int scoreCount = 0;
    public Text lbScore;
    // 最高分数
    private static int bestScoreCount;
    public Text bestScoretText;
    // 技能条
    public int skillScore = 0;

    // 结束游戏面板
    public GameObject m_endPanel;
    // 技能面板
    public GameObject skillPanel;

    //本局游戏是否结束的标志变量
    private bool isGameOver = false;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        StartCoroutine(SpawnWaves());
        //初始化最高分
        bestScoretText.text = string.Format("Best Score:{0}", bestScoreCount);

        Debug.Log(UIManager.Instance.airplaneId);
        // 根据玩家的选择，更换飞机模型
        switch (UIManager.Instance.airplaneId)
        {
            case 1:
                airplane[0].gameObject.SetActive(true);
                break;
            case 2:
                airplane[1].gameObject.SetActive(true);
                break;
            case 3:
                airplane[2].gameObject.SetActive(true);
                break;
            case 4:
                airplane[3].gameObject.SetActive(true);
                break;
        }
    }


    //随机生成敌人物体(协程)
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < waveCount; ++i)
            {
                int index = Random.Range(0, enemys.Length);
                GameObject go = enemys[index];
                Vector3 pos = new Vector3(Random.Range(-16, 16), 0, 10); // 生成敌人的位置
                Quaternion rot = Quaternion.identity;
                Instantiate(go, pos, rot);
                yield return new WaitForSeconds(spawnWait);
            }
            //当主角死亡时，跳出出生逻辑
            if (isGameOver)
            {
                break;
            }

            yield return new WaitForSeconds(waveWait);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }


    //命中敌人增加分数,技能条
    public void AddScore(int value)
    {
        scoreCount += value;
        skillScore += value;
        Debug.Log("ScoreCount:" + scoreCount);
        lbScore.text = "Score:" + scoreCount.ToString();
    }

    public void GameOver()
    {
        m_endPanel.SetActive(true);
        m_endPanel.transform.Find("title").GetComponent<Text>().text = string.Format("Game Over!");
        m_endPanel.transform.Find("btnBack").gameObject.SetActive(false);
        isGameOver = true;
        if (scoreCount >= bestScoreCount)
        {
            bestScoreCount = scoreCount;
            bestScoretText.text = string.Format("Best Score:{0}", bestScoreCount);
        }
    }

    public void ReStartGame()
    {
        Time.timeScale = 1;
        //重新加载场景，开始新的一局游戏
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // 回到开始菜单
    public void BackMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }

    // 按下Esc键，游戏暂停
    void Pause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (m_endPanel.gameObject.activeSelf == false && isGameOver == false)
            {
                Time.timeScale = 0;
                m_endPanel.gameObject.SetActive(true);
                m_endPanel.transform.Find("title").GetComponent<Text>().text = string.Format("Waiting");
            }
        }
    }

    public void Back()
    {
        Time.timeScale = 1;
        m_endPanel.gameObject.SetActive(false);
    }
}
