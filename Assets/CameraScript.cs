using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CameraScript : MonoBehaviour
{
    public Transform camera_head;

    public GameObject light_spot;

    private void Update()
    {
        Vector3 diff = camera_head.position - light_spot.transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        camera_head.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
}
