using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
    [Header("±³¾°Ðý×ª")]
    public float roteSpeed = 0.5f;
    // Update is called once per frame
    void Update()
    {
        RotateSkyBox();
    }

    private void RotateSkyBox()
    {

        float rotation = Camera.main.GetComponent<Skybox>().material.GetFloat("_Rotation");
        Camera.main.GetComponent<Skybox>().material.SetFloat("_Rotation", rotation + roteSpeed*Time.deltaTime);
    }
}
