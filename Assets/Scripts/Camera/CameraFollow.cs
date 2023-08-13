using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    public Vector3 minValues, maxValue;

    //Editors Fields
    [HideInInspector]
    public bool setupComplete = false;

    public bool followFloor = false;
    private float goalAltitute;

    private void OnEnable()
    {
        target.GetComponent<PlayerController>().HasLanded += UpdateCameraAltitue;
    }

    private void Start()
    {
        if (followFloor)
            goalAltitute = target.position.y;
    }

    private void UpdateCameraAltitue()
    {
        if (!followFloor) return;

        goalAltitute = target.position.y;
    }

    private void LateUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;

        if (followFloor)
            targetPosition.y = goalAltitute + offset.y;

        Vector3 boundPosition = new Vector3
        (
            Mathf.Clamp(targetPosition.x, minValues.x, maxValue.x),
            Mathf.Clamp(targetPosition.y, minValues.y, maxValue.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValue.z)
        );

        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
   /*  private void OnDisable()
    {
        target.GetComponent<PlayerController>().HasLanded -= UpdateCameraAltitue;
    } */
}


