using System;
using UnityEngine;

namespace Pope
{
    public class PopeActions : MonoBehaviour
    {
        [SerializeField] Camera camera;
        [SerializeField] GameObject lightBeam;
        
        const float raycastMaxDistance = 360f;
        Transform beam;
        
        void Start()
        {
            beam = Instantiate(lightBeam).transform;
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Bless();
            }
            
            Ray();
        }

        void Ray()
        {
            Vector3 rayDirection = camera.transform.forward;
            RaycastHit hit;

            Vector3 rayStart = camera.ViewportToWorldPoint(Vector3.zero);
            
            if (Physics.Raycast(rayStart, rayDirection, out hit, raycastMaxDistance))
            {
                Vector3 position = new Vector3(hit.point.x, beam.position.y, hit.point.z);
                
                beam.position = position;
            }
        }
        
        void Bless()
        {
            Vector3 rayDirection = camera.transform.forward;
            RaycastHit hit;

            Vector3 rayStart = camera.ViewportToWorldPoint(Vector3.zero);
            
            if (Physics.Raycast(rayStart, rayDirection, out hit, raycastMaxDistance))
            {
                Vector3 position = new Vector3(hit.point.x, beam.position.y, hit.point.z);
                
                beam.position = position;
                var pilgrims = hit.collider.GetComponent<PilgrimGroup>();
                pilgrims.OnHit();
                
            }
        }
    }
}