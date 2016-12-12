﻿using UnityEngine;
using System.Collections;

/// <summary>
/// The class that lets the camera move to pre-defined spots
/// </summary>
public class FollowCam : MonoBehaviour
{
    //target to lerp to
    private GameObject target;

    //all the camera spots
    private CameraSpot[] staticPos;

    int index = 0;

    float heightDamping = 0.8f;
    float positionDamping = 0.8f;
    float rotationDamping = 0.8f;

    // Use this for initialization
    void Start()
    {
        staticPos = FindObjectsOfType<CameraSpot>();
        for(int i = 1; i <staticPos.Length; i++)
        {
            staticPos[i - 1] = GameObject.Find("Camera Spot " + i).GetComponent<CameraSpot>();
        }
        target = staticPos[index].gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //on input, cycle through
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            index++;
            if (index >= staticPos.Length)
                index -= staticPos.Length;
            target = staticPos[index].gameObject;
        }

        // go to that spot
        Vector3 pos = Vector3.Lerp(transform.position, target.transform.position, positionDamping * Time.deltaTime);
        transform.forward = Vector3.Lerp(transform.forward, target.transform.forward, Time.deltaTime * rotationDamping);
        transform.position = pos;
    }
}
