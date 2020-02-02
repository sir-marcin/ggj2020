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
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip deathClip;

    const string pigeonTag = "Pigeon";

    PigeonState state = PigeonState.Walking;
    new Transform transform;
    public Vector3 Target { get; set; }
    Collider col;
    AudioClip originalClip;

    void Awake()
    {
        transform = GetComponent<Transform>();
        col = GetComponent<Collider>();

        originalClip = audioSource.clip;
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
            Destroy();
        }
    }

    public void Destroy(){
        audioSource.Stop();
        audioSource.clip = deathClip;
        audioSource.Play();

        birdFlying.SetActive(false);
        birdWalking.SetActive(false);
        col.enabled = false;
    }
    
    public void Create(){
        audioSource.Stop();
        audioSource.clip = originalClip;
        audioSource.Play();

        birdFlying.SetActive(true);
        birdWalking.SetActive(false);
        state = PigeonState.Flying;
        col.enabled = true;
    }
}
