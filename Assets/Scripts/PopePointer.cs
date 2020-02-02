using System;
using UnityEngine;

namespace Pope
{
    public class PopePointer : MonoBehaviour
    {
        [SerializeField] GameObject particleSystem;
        [SerializeField] GameObject cube;

        void Awake()
        {
            HandTracker.OnHandVisible += ToggleParticles;
        }

        void OnDestroy()
        {
            HandTracker.OnHandVisible -= ToggleParticles;
        }

        void ToggleParticles(bool state)
        {
            if (particleSystem.activeSelf == state)
            {
                return;
            }
            
            particleSystem.SetActive(state);
        }
    }
}