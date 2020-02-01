using System;
using UnityEngine;

namespace Pope
{
    public class PilgrimGroup : MonoBehaviour
    {
        [SerializeField] ParticleSystem particleSystem;

        ParticleSystem.Particle[] particles;
        int count;
        
        void Start()
        {
            particles = new ParticleSystem.Particle[particleSystem.particleCount];
            count = particles.Length;
            
            particleSystem.GetParticles(particles);
        }

        public void OnHit()
        {
            for (int i = 0; i < count; i++)
            {
                particles[i].color = Color.black;
            }
        }
    }
}