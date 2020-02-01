using System;
using UnityEngine;

namespace Pope
{
    public class PilgrimGroup : MonoBehaviour
    {
        [SerializeField] ParticleSystem particleSystem;

        ParticleSystem.Particle[] particles;
        int count;

        float incrementValue = .1f;
        float blessing;
        
        void Start()
        {
            particles = new ParticleSystem.Particle[particleSystem.particleCount];
            count = particles.Length;
            
            particleSystem.GetParticles(particles);
        }

        public void OnHit()
        {
            // pokazanie particli blessingu
            // nabijanie blessingu
            // na wymaksowanie podniesienie do gory
            // i instantiate kolejnych pilgrimow na to miejsce

            blessing += incrementValue;

            if (blessing >= 1)
            {
                // blessed!
            }
        }
    }
}