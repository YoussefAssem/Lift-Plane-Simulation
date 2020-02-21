using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCamera : MonoBehaviour
{
    Camera carCamera;

    [SerializeField] Vector3 offset;

    [SerializeField] float backwardOffset = 5f;
    [SerializeField] float upwardOffset = 2f;


    // Start is called before the first frame update
    void Start()
    {
        carCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        carCamera.transform.position = gameObject.transform.position + offset - gameObject.transform.forward * backwardOffset + gameObject.transform.up * upwardOffset;
        carCamera.transform.LookAt(gameObject.transform.position);
    }
}
