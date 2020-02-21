using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    Camera thirdPersonCamera;

    [SerializeField] Vector3 offset;

    [SerializeField] float backwardOffset = 5f;
    [SerializeField] float upwardOffset = 2f;


    // Start is called before the first frame update
    void Start()
    {
        thirdPersonCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        thirdPersonCamera.transform.position = gameObject.transform.position + offset - gameObject.transform.forward * backwardOffset + gameObject.transform.up * upwardOffset;
        thirdPersonCamera.transform.LookAt(gameObject.transform.position);
    }
}
