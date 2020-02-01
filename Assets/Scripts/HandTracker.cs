using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracker : MonoBehaviour
{

    int timer;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        // if (timer % 60 == 0)
        // {

        OVRInput.Controller activeController = OVRInput.GetActiveController();

        Vector3 vel = OVRInput.GetLocalControllerVelocity(activeController);

        Debug.Log($"CONTROLLER VEL {vel}");

        Debug.Log($"VELOCITY {rb.velocity}");
        Debug.Log($"VELOCITY MAG {rb.velocity.magnitude}");


        // }
    }
}
