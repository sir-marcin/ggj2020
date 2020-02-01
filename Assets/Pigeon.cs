using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    const string pigeonTag = "Pigeon";

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(pigeonTag)){
            ParticleSpawner.Instance.Spawn(transform.position);
            gameObject.SetActive(false);
        }
    }
}
