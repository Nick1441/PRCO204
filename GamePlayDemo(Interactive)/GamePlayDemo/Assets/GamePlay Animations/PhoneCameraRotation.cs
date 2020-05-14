using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCameraRotation : MonoBehaviour
{
    public Transform phoneCamera;
    public Transform mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        phoneCamera.rotation = mainCamera.rotation;
        phoneCamera.position = new Vector3(mainCamera.position.x + 100, mainCamera.position.y, mainCamera.position.z - 1);
    }
}
