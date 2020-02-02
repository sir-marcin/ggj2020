using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pope
{
    public class PilgrimGroup : MonoBehaviour
    {
        [SerializeField] ParticleSystem particleSystem;
        [SerializeField] AudioSource audioSource;
        [SerializeField] float fadeSpeed = 1f;
        
        [SerializeField] AudioClip[] clips;
        
        ParticleSystem.Particle[] particles;
        int count;

        float incrementValue = .1f;
        float blessing;
        float initialVolume;
        IEnumerator fade;

        void Awake()
        {
            fade = SmoothFadeOut();
            HandTracker.OnHandVisible += FadeOnHandDown;
        }

        void OnDestroy()
        {
            HandTracker.OnHandVisible -= FadeOnHandDown;
        }

        void Start()
        {
            particles = new ParticleSystem.Particle[particleSystem.particleCount];
            count = particles.Length;
            
            particleSystem.GetParticles(particles);
            initialVolume = audioSource.volume;
        }

        void FadeOnHandDown(bool state)
        {
            if (!audioSource.isPlaying || audioSource.time < .1f)
            {
                return;
            }

            StartCoroutine(SmoothFadeOut());
        }
        
        public void OnHit(bool state)
        {
            if (!state)
            {
                StartCoroutine(fade);
            }
            else if (!audioSource.isPlaying)
            {
                StopCoroutine(fade);
                audioSource.clip = clips[Random.Range(0, clips.Length)];
                audioSource.Play();
                audioSource.volume = initialVolume;
            }
            
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

        IEnumerator SmoothFadeOut()
        {
            while (audioSource.volume > .05f)
            {
                audioSource.volume = Mathf.Lerp(audioSource.volume, 0f, Time.deltaTime * fadeSpeed);

                yield return null;
            }

            audioSource.Stop();
        }
    }
}