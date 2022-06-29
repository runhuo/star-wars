using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoteController : MonoBehaviour {
    public float rotSpeed; // 旋转速度
    public bool randomRote = true; //是否随机旋转
    public float rotAxisX; // X轴速度
    public float rotAxisY; // Y轴角速度
    public float rotAxisZ;  // Z轴角速度
    // Use this for initialization
    void Start() {
        if (randomRote)
        {
           Rigidbody rbd = GetComponent<Rigidbody>();
           rbd.angularVelocity = Random.insideUnitSphere * rotSpeed;
        }
        else
        {
            Rigidbody rbd = GetComponent<Rigidbody>();
            rbd.angularVelocity = new Vector3(rotAxisX * rotSpeed, rotAxisY * rotSpeed, rotAxisZ * rotSpeed);

        }
    }
}
