using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip3 : PlayerShipController
{
    [Header("技能释放条件")]
    // 释放技能条件，达到该条件才能释放技能
    public int threshold;
    [Header("技能持续时间")]
    // 技能持续时间
    public int skillTime;
    // 技能条
    public int skillScore;
    // 技能面板
    public GameObject skillPanel;
    // 是否正在释放技能
    public bool isSkilling = false;



    protected override void SkillContorller()
    {
        base.SkillContorller();

        if (isSkilling == false)
        {
            skillScore = GameMgr.Instance.skillScore;
            // 如果达到技能释放条件，提示玩家释放技能
            if (skillScore >= threshold)
            {
                skillPanel = GameMgr.Instance.skillPanel;
                if (skillPanel.activeSelf == false)
                    skillPanel.SetActive(true);

                // 按下Q键释放技能
                if (Input.GetKey(KeyCode.Q))
                {
                    GameMgr.Instance.airplane[2].transform.Find("PlayerShip3_Weapon").gameObject.SetActive(true);
                    isSkilling = true;
                }
            }
        }
        else
        {
            GameMgr.Instance.skillScore = 0;
        }
        

        if (isSkilling)
        {
            StartCoroutine(SkillTimer());
        }
    }

    IEnumerator SkillTimer()
    {
        yield return new WaitForSeconds(skillTime);
        GameMgr.Instance.airplane[2].transform.Find("PlayerShip3_Weapon").gameObject.SetActive(false);
        skillPanel.SetActive(false);
        isSkilling = false;
        GameMgr.Instance.skillScore = 0;
    }
}
