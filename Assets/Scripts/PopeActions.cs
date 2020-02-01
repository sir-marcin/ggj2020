using System;
using UnityEngine;

namespace Pope
{
    public class PopeActions : MonoBehaviour
    {
        [SerializeField] Camera camera;
        
        const float raycastMaxDistance = 360f;
        
        void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Bless();
            }
        }

        void Bless()
        {
            Vector3 rayDirection = camera.transform.forward;
            RaycastHit hit;

            Vector3 rayStart = camera.ViewportToWorldPoint(Vector3.zero);
            
            if (Physics.Raycast(rayStart, rayDirection, out hit, raycastMaxDistance))
            {
                var pilgrims = hit.collider.GetComponent<PilgrimGroup>();
                pilgrims.OnHit();
            }
        }
    }
}