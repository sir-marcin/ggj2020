using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OVRInput.Controller activeController;
        activeController = OVRInput.GetActiveController();

        activeController = OVRInput.GetActiveController();
        Debug.Log($"activeController {activeController}");


        Vector3 vel = OVRInput.GetLocalControllerVelocity(activeController);
        Debug.Log($"vel {vel}");
    }

    // Update is called once per frame
    void Update()
    {


    }
}
