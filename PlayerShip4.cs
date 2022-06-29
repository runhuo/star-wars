using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip4 : PlayerShipController
{
    // 激光炮发射间隔时间
    public float waitTime;
    private float nextWeapon;
    // 激光炮
    public GameObject Weapon;
    // 激光炮发射位置
    public Transform weaponPos;
    // 激光炮发射音频
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
