using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCamera : MonoBehaviour
{
    Camera planeCamera;
    // Start is called before the first frame update
    void Start()
    {
        planeCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        planeCamera.transform.position = this.transform.position - this.transform.forward * 20.0f + Vector3.up * 8.0f;
        planeCamera.transform.LookAt(this.transform.position);
    }
}
