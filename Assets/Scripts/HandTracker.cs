using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandTracker : MonoBehaviour
{
    public static event Action<float> OnMachanko = (distance) => { };


    Vector3 lastPosition;
    int timer;
    // Start is called before the first frame update
    void Start()
    {

        timer = 0;

    }

    // Update is called once per frame
    void Update()

    {


        if (timer % 10 == 0)
        {

            float distance = Vector3.Distance(lastPosition, transform.position);
            // Debug.Log($"distance {distance}");

            if (distance > 0.01)
            {
                OnMachanko.Invoke(distance);
            }

            lastPosition = transform.position;
            // Debug.Log($"lastPosition {lastPosition}");

        }


    }

    void FixedUpdate()
    {

    }
}
