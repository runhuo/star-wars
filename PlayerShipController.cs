using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}


public class PlayerShipController : MonoBehaviour {
    public float speed;
    public float tilt;

    public Boundary bound;

    private Rigidbody rbd;

    public GameObject bullet;
    public Transform shotPos;
    public float shotSpace;
    private float nextShot;

    private AudioSource shotAudio;

    private void Awake()
    {
        rbd = GetComponent<Rigidbody>();
        shotAudio = GetComponent<AudioSource>();
    }


    //Update is called once per frame
    void Update()
    {
        FireController();
        SkillContorller();
    }

    protected void FireController()
    {
        if (Input.GetButton("Fire1") && Time.time > nextShot)
        {
            //创建子弹物体 
            nextShot = Time.time + shotSpace;
            Instantiate(bullet, shotPos.position, shotPos.rotation);
            shotAudio.Play();
        }
    }

    // 虚函数 释放技能，子类拓展
    protected virtual void SkillContorller()
    {

    }

    protected void MoveController()
    {
        //计算运动方向速度向量
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 vel = new Vector3(h, 0, v);

        //操作刚体速度产生运动
        rbd.velocity = vel * speed;


        //产生偏转
        rbd.rotation = Quaternion.Euler(0, 0, rbd.velocity.x * (-1) * tilt);


        //限制位置
        float posX = Mathf.Clamp(rbd.position.x, bound.xMin, bound.xMax);
        float posZ = Mathf.Clamp(rbd.position.z, bound.zMin, bound.zMax);

        rbd.position = new Vector3(posX, 0, posZ);
    }

    private void FixedUpdate()
    {
        MoveController();
    }
}
