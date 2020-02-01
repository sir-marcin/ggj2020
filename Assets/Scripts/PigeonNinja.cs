using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pope
{
    public class PigeonNinja : MonoBehaviour
    {
        [SerializeField] float widthVariation = 3;
        [SerializeField] float minFlyTime = 5f;
        [SerializeField] float maxFlyTime = 10f;
        
        Pigeon[] pigeons;

        int index;
        Vector3 startPosition = new Vector3(0f, 10f, 20f);
        WaitForSeconds wait = new WaitForSeconds(5);
        
        void Awake()
        {
            pigeons = GetComponentsInChildren<Pigeon>(true);
        }

        void Start()
        {
            StartCoroutine(KeepFlying());
        }

        IEnumerator KeepFlying()
        {
            while (true)
            {
                Fly();
                yield return wait;
            }
        }
        
        void Fly()
        {
            if (index >= pigeons.Length)
            {
                index = 0;
            }

            var p = pigeons[index];
            p.transform.localPosition = new Vector3(Random.Range(-widthVariation, widthVariation), startPosition.y, startPosition.z);
            p.transform.localRotation = Quaternion.Euler(new Vector3(Random.Range(-1080, 1080), Random.Range(-1080, 1080), Random.Range(-1080, 1080)));
            p.gameObject.SetActive(true);
            var time = Random.Range(minFlyTime, maxFlyTime);
            p.transform.DOLocalMove(Vector3.right * Random.Range(-widthVariation, widthVariation), time);
            p.transform.DOLocalRotate(Vector3.zero, time);

            index++;
        }
    }
}