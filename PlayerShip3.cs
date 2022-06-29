using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip3 : PlayerShipController
{
    [Header("�����ͷ�����")]
    // �ͷż����������ﵽ�����������ͷż���
    public int threshold;
    [Header("���ܳ���ʱ��")]
    // ���ܳ���ʱ��
    public int skillTime;
    // ������
    public int skillScore;
    // �������
    public GameObject skillPanel;
    // �Ƿ������ͷż���
    public bool isSkilling = false;



    protected override void SkillContorller()
    {
        base.SkillContorller();

        if (isSkilling == false)
        {
            skillScore = GameMgr.Instance.skillScore;
            // ����ﵽ�����ͷ���������ʾ����ͷż���
            if (skillScore >= threshold)
            {
                skillPanel = GameMgr.Instance.skillPanel;
                if (skillPanel.activeSelf == false)
                    skillPanel.SetActive(true);

                // ����Q���ͷż���
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
