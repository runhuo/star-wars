using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {
    public float flySpeed;
    // Use this for initialization
    void Start() {
        Rigidbody rbd = GetComponent<Rigidbody>();
        if (transform.tag == "Weapon")
            rbd.velocity = Vector3.forward * flySpeed;
        else
            rbd.velocity = transform.forward * flySpeed;
    }
}
