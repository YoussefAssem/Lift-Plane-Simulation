using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float thrust = 0.0f;

    [SerializeField] float pitchForce = 1.0f;
    [SerializeField] float yawForce = 1.0f;
    [SerializeField] float rollForce = 1.0f;

    private float pitchInput;
    private float yawInput;
    private float rollInput;

    public float speed;

    public float area;
    public float lift;
    public float drag;
    Rigidbody r;

    [SerializeField] GameObject tail = null;

    //public float hf;
    //public float vf;
    //public float cAngle;
    //public float test;
    public float tempAngle;
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        pitchInput = Input.GetAxis("Horizontal");
        yawInput = Input.GetAxis("Vertical");
        rollInput = Input.GetAxis("Horizontal Wing");

        if (Input.GetKeyDown(KeyCode.R))
        {
            thrust = thrust + 10000;
            thrust = Mathf.Clamp(thrust, 0, 160000);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            thrust = thrust - 10000;
            thrust = Mathf.Clamp(thrust, 0, 160000);
        }

        speed = Mathf.Sqrt(r.velocity.x* r.velocity.x + r.velocity.z* r.velocity.z);
        lift = getLift();
        drag = getDrag();

        //cAngle = (360-transform.rotation.eulerAngles.x) * (float)(3.14/180);
        //test = Mathf.Cos(cAngle);
        //hf = thrust*Mathf.Cos(cAngle) - r.drag * Mathf.Cos(cAngle) - lift * Mathf.Sin(cAngle);
        //vf = thrust * Mathf.Sin(cAngle) + lift * Mathf.Cos(cAngle) - (float)(r.mass * 9.81);

        print("trust:" + thrust);

        r.AddForce(transform.forward * thrust);
        r.AddForce(transform.up * lift);
        r.AddForce(-transform.forward * drag);

        r.AddForceAtPosition(transform.right * Time.deltaTime * pitchForce * -pitchInput, tail.transform.position);
        r.AddForceAtPosition(transform.up * Time.deltaTime * yawForce * -yawInput, tail.transform.position);
        r.AddTorque(transform.forward * Time.deltaTime * rollForce * -rollInput);

        //print("ANGLE :" + tempAngle);
        //print("CR:"+Clark_Y.GetCR(tempAngle));
        //print("CL:" + Clark_Y.GetCL(tempAngle));
        print("coordinates:" + transform.position.x);
        print("coordinates:" + transform.position.y);
        print("coordinates:" + transform.position.z);

        print("speed:" + r.velocity.magnitude);
    }

    float getDensity(float alt)
    {
        if (alt < 1000)
        {
            return (float)1.225;
        }
        else if (alt < 2000)
        {
            return (float)1.112;
        }
        else if (alt < 3000)
        {
            return (float)1.007;
        }
        else if (alt < 4000)
        {
            return (float)0.9099;
        }
        else
        {
            return (float)0.8200;
        }
    }

    float getLift()
    {
        if (this.transform.rotation.eulerAngles.x < 90)
        {
            tempAngle = -this.transform.rotation.eulerAngles.x;
        }
        else
        {
            tempAngle = 360 - this.transform.rotation.eulerAngles.x;
        }
        return (float)Clark_Y.GetCL(tempAngle) * r.velocity.magnitude * r.velocity.magnitude * getDensity(this.transform.position.y) / 2 * area;
    }

    float getDrag()
    { 
        if (this.transform.rotation.eulerAngles.x < 90)
        {
            tempAngle = - this.transform.rotation.eulerAngles.x;
        }
        else
        {
            tempAngle = 360 - this.transform.rotation.eulerAngles.x;
        }
        return (float)Clark_Y.GetCR(tempAngle) * r.velocity.magnitude * r.velocity.magnitude * getDensity(this.transform.position.y) / 2 * area;
    }
}