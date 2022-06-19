using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
    public float scrollSpeed;
    private Vector3 startPos;
    // Use this for initialization
    void Start() {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        float dis = Mathf.Repeat(scrollSpeed * Time.time, 30);
        transform.position = startPos + dis * Vector3.forward * (-1);
    }
}
