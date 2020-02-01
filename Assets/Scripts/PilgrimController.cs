using System;
using UnityEngine;
namespace Pope
{
    public class PilgrimController : MonoBehaviour
    {
        [SerializeField] PilgrimGroup pilgrimGroup;
        [Header("Config")] 
        [SerializeField] Vector2Int size;
        [SerializeField] float distance;
        [SerializeField] float LODz1 = 3;
        [SerializeField] float LODz2 = 5;
        
        PilgrimGroup[,] pilgrims;
        Vector3 positionOffset;
        new Transform transform;
        void Awake()
        {
            transform = GetComponent<Transform>();
            pilgrims = new PilgrimGroup[size.x, size.y];
            positionOffset.x = size.x / -2f * distance + distance / 2;
            positionOffset.z = size.y / -2f * distance + distance / 2;
        }
        void Start()
        {
            for (int x = 0; x < size.x; x++)
            {
                for (int z = 0; z < size.y; z++)
                {
                    Vector3 position = new Vector3(x * distance, 0f, z * distance) + positionOffset;
                    pilgrims[x, z] = Instantiate(pilgrimGroup, transform);
                    pilgrims[x, z].transform.localPosition = position;
                }
            }
        }
    }
}