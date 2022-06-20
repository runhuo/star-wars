using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {
    public float delayTime;
    // Use this for initialization
    void Start() {
        Destroy(gameObject, delayTime);
    }
}
