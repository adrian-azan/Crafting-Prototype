using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float xDistance;
    public float yDistance;
    public float zDistance;

    [Range (0f,360f)]
    public float xRotation;
    [Range(0f, 360f)]
    public float yRotation;
    [Range(0f, 360f)]
    public float zRotation;

    
    void LateUpdate()
    {
        Vector3 p = target.transform.position;
        transform.position = new Vector3(p.x + xDistance,
                                         p.y + yDistance,
                                         p.z + zDistance);

        transform.eulerAngles = new Vector3(xRotation, yRotation, zRotation);
    }
}
