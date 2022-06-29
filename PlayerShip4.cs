using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip4 : PlayerShipController
{
    // �����ڷ�����ʱ��
    public float waitTime;
    private float nextWeapon;
    // ������
    public GameObject Weapon;
    // �����ڷ���λ��
    public Transform weaponPos;
    // �����ڷ�����Ƶ
    public AudioSource audioSource;



    protected override void SkillContorller()
    {
        base.SkillContorller();

        if (Input.GetKey(KeyCode.Mouse1) && Time.time > nextWeapon)
        {
            nextWeapon = Time.time + waitTime;
            Instantiate(Weapon, weaponPos.position, Quaternion.Euler(-90, -180, 0));
            audioSource.Play();
        }
    }
}
