using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactCheck : MonoBehaviour
{
    //敌人自身爆炸特效
    public GameObject enemyExplosion;
    //主角飞船的爆炸特效
    public GameObject playerExplosion;

    //物体被销毁时玩家获得的分数
    public int scoreValue;

    private GameMgr gameMgr;

    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameMgr");
        gameMgr = go.GetComponent<GameMgr>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }
        //播放敌人自身爆炸特效
        if (enemyExplosion != null)
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            if (other.tag != "Weapon")
            {
                Destroy(other.gameObject);
            }
            
        }

        //增加UI分数
        gameMgr.AddScore(scoreValue);

        //播放主角飞船的爆炸特效
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject.transform.parent.gameObject);
            gameMgr.GameOver();
        }



        Destroy(gameObject);
    }
}
