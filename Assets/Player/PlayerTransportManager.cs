using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public static class PlayerTransportManager
{
    static GameObject _ThirdPerson = GameObject.Find("ThirdPersonController");
    static GameObject _transport = null;
    static bool _inTransport = false;

    public static GameObject thirdPerson { get => _ThirdPerson; }
    public static GameObject transport { get => _transport; }
    public static bool inTransport { get => _inTransport; }

    static LayerMask transportLayerMask = 256;
    static Collider[] hitCollidersTransport;

    public static void GiveControlToTransport()
    {
        _inTransport = true;
        _ThirdPerson.SetActive(false);

        if (_transport.CompareTag("Car"))
        {
            _transport.GetComponent<CarUserControl>().enabled = true;
            _transport.GetComponent<CarCamera>().enabled = true;
        }
        else if (_transport.CompareTag("Plane"))
        {
            _transport.GetComponent<PlaneController>().enabled = true;
            _transport.GetComponent<PlaneCamera>().enabled = true;
        }
    }

    public static void GiveControlToHuman()
    {
        _inTransport = false;
        _ThirdPerson.SetActive(true);

        if (_transport.CompareTag("Car"))
        {
            _transport.GetComponent<CarUserControl>().enabled = false;
            _transport.GetComponent<CarCamera>().enabled = false;
        }
        else if (_transport.CompareTag("Plane"))
        {
            _transport.GetComponent<PlaneController>().enabled = false;
            _transport.GetComponent<PlaneCamera>().enabled = false;
        }
    }

    public static void RideUnride()
    {
        hitCollidersTransport = Physics.OverlapSphere(thirdPerson.transform.position, 2, transportLayerMask);

        if (inTransport)
        {
            thirdPerson.transform.position = transport.transform.Find("LeavePos").transform.position;
            PlayerTransportManager.GiveControlToHuman();
        }
        else
        {
            if (hitCollidersTransport.Length != 0)
            {
                _transport = hitCollidersTransport[0].gameObject;
                GiveControlToTransport();
            }
            else
            {
                _transport = null;
            }
        }
    }
}
