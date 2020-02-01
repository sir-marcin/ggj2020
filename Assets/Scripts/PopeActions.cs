using System;
using UnityEngine;

namespace Pope
{
    [RequireComponent(typeof(Camera))]
    public class PopeActions : MonoBehaviour
    {
        const string pilgrimsTag = "Pilgrims";
        
        [SerializeField] GameObject lightBeam;
        [SerializeField] Transform raycastDirectionObject;
        
        Transform beam;
        Camera camera;
        Vector3 rayDirection;
        PilgrimGroup currentPilgrimGroup;
        
        const float raycastMaxDistance = 360f;

        void Awake()
        {
            camera = GetComponent<Camera>();
            rayDirection = camera.transform.forward;
            HandTracker.OnMachanko += OnMachanko;
        }

        void OnDestroy()
        {
            HandTracker.OnMachanko -= OnMachanko;
        }

        void Start()
        {
            beam = Instantiate(lightBeam, Vector3.down * -100, Quaternion.identity).transform;
        }
        
        void Update()
        {
            Ray();
        }

        void Ray()
        {
            rayDirection = raycastDirectionObject.forward;

            Vector3 rayStart = camera.ViewportToWorldPoint(Vector3.zero);
            
            if (Physics.Raycast(rayStart, rayDirection, out var hit, raycastMaxDistance))
            {
                if (hit.collider.CompareTag(pilgrimsTag))
                {
                    currentPilgrimGroup = hit.collider.gameObject.GetComponent<PilgrimGroup>();
                    beam.position = currentPilgrimGroup.transform.position;
                }
                else
                {
                    currentPilgrimGroup = null;
                    beam.position = hit.point;
                }
            }
        }

        void OnMachanko(float intensity)
        {
            currentPilgrimGroup?.OnHit();
        }
    }
}