﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float cameraSmoothing;
    public Transform objectPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != objectPosition.position)
        {
            Vector3 targetPosition = new Vector3(objectPosition.position.x, objectPosition.position.y,
                transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSmoothing);
        }   
    }
}
