using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    enum PigeonState
    {
        Walking = 0,
        Flying = 1
    }
    
    [SerializeField] GameObject birdFlying;
    [SerializeField] GameObject birdWalking;
    
    const string pigeonTag = "Pigeon";

    PigeonState state = PigeonState.Walking;
    new Transform transform;
    public Vector3 Target { get; set; }
    
    void Awake()
    {
        transform = GetComponent<Transform>();
    }

    public void ToggleMesh()
    {
        switch (state)
        {
            case PigeonState.Walking:
                birdWalking.SetActive(false);
                birdFlying.SetActive(true);
                state = PigeonState.Flying;
                break;
            case PigeonState.Flying:
                birdWalking.SetActive(true);
                birdFlying.SetActive(false);
                state = PigeonState.Walking;
                var eulerAngles = transform.eulerAngles;
                transform.rotation = Quaternion.Euler(0f, eulerAngles.y, eulerAngles.z);
                break;
        }
    }

    void Update()
    {
        if (state == PigeonState.Walking)
        {
            return;
        }
        
        transform.LookAt(Target);
    }

    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(pigeonTag)){
            ParticleSpawner.Instance.Spawn(transform.position);
            gameObject.SetActive(false);
        }
    }
}
