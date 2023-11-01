using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewCorrect : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] int targetViewAngle;

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(camera.fieldOfView - targetViewAngle) > 1 )
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, targetViewAngle, 0.05f);
        }
    }
}
