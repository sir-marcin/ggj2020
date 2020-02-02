using System;
using System.Collections;
using DG.Tweening;
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
        bool blessed;
        Collider col;
        
        void Awake()
        {
            fade = SmoothFadeOut();
            HandTracker.OnHandVisible += FadeOnHandDown;
            col = GetComponent<Collider>();
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
        }

        public void Bless()
        {
            blessing += incrementValue;
            
            if (!blessed && blessing >= 1)
            {
                blessed = true;
                col.enabled = false;
                transform.DOLocalMove(transform.localPosition + Vector3.up * 200f, 4f).SetEase(Ease.InQuad)
                    .OnComplete(() => gameObject.SetActive(false));
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