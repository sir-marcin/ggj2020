using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public static ParticleSpawner Instance;

    ParticleSystem[] particleSystems;
    int index;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>(true);
    }

    public void Spawn(Vector3 pos)
    {
        if (index >= particleSystems.Length)
        {
            index = 0;

        }
        particleSystems[index].transform.position = pos;
        particleSystems[index].gameObject.SetActive(false);
        particleSystems[index].gameObject.SetActive(true);
        index++;

    }
}
