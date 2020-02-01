using UnityEngine;

namespace Pope
{
    public class PopeCamera : MonoBehaviour
    {
        [SerializeField] float rotationSpeed;
        
        new Transform transform;
        Vector3 rotation;
        
        void Awake()
        {
            transform = GetComponent<Transform>();
        }

        void Update()
        {
            rotation = transform.eulerAngles;
            rotation.x -= Input.GetAxis("Mouse Y") * rotationSpeed;
            rotation.y += Input.GetAxis("Mouse X") * rotationSpeed;
            
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}