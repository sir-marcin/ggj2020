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
        Vector3 startPosition = new Vector3(0f, 50f, 50f);
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
            p.ToggleMesh();
            var time = Random.Range(minFlyTime, maxFlyTime);

            var pTran = p.transform;
            
            pTran.localPosition = new Vector3(Random.Range(-widthVariation, widthVariation), startPosition.y, startPosition.z);
            pTran.Rotate(Vector3.up, 180f);
            p.gameObject.SetActive(true);
            //p.transform.DOLocalMove(Vector3.right * Random.Range(-widthVariation, widthVariation), time).OnComplete(p.ToggleMesh);

            var target = Vector3.right * Random.Range(-2, 2);
            
            p.transform.DOLocalPath(
                GetPath(pTran.localPosition, target), time, PathType.CatmullRom).OnComplete(p.ToggleMesh);

            p.Target = target;
            
            index++;
        }

        Vector3[] GetPath(Vector3 from, Vector3 to)
        {
            Vector3 middlePoint = (from - to) / 2;

            middlePoint.x += Random.Range(-10f, 10f);
            middlePoint.y = to.y + 5f;
            
            return new Vector3[]
            {
                from,
                middlePoint,
                to
            };
        }
    }
}