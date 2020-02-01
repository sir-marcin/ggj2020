using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracker : MonoBehaviour
{
    public static event Action<int> OnMachanko = (distance) => {};

    OVRInput.Controller activeController;
    Vector3 lastPosition;
    int timer;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        activeController = OVRInput.GetActiveController();
        timer = 0;
        rb = GetComponent<Rigidbody>();

        Debug.Log($"activeController {activeController}");
    }

    // Update is called once per frame
    void Update()

    {


        if (timer % 10 == 0)
        {

            float distance = Vector3.Distance(lastPosition, transform.position);
            Debug.Log($"distance {distance}");

            if (distance > 0.01) {
                OnMachanko.Invoke(distance);
            }
            
            lastPosition = transform.position;
            Debug.Log($"lastPosition {lastPosition}");

        }

        // Debug.Log($"activeController {activeController}");
        // Vector3 vel = OVRInput.GetLocalControllerVelocity(activeController);

        // Debug.Log($"CONTROLLER VEL {vel}");

        // Debug.Log($"VELOCITY {rb.velocity}");
        // Debug.Log($"VELOCITY MAG {rb.velocity.magnitude}");
    }

    void FixedUpdate()
    {
        // Debug.Log($"activeController {activeController}");
        // // if (timer % 60 == 0)
        // // {

        // Vector3 vel = OVRInput.GetLocalControllerVelocity(activeController);

        // Debug.Log($"CONTROLLER VEL {vel}");

        // Debug.Log($"VELOCITY {rb.velocity}");
        // Debug.Log($"VELOCITY MAG {rb.velocity.magnitude}");

        // }
    }
}
