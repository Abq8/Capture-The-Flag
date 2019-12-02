using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotater : MonoBehaviour
{
    // SerializeFields

    [Header("Rotaion Speed")]
    [SerializeField] private int speedRotation;

    [Header("Camera Pivot Transform")]
    [SerializeField] private Transform camPivot;

    [Header("Camera Hight")]
    [SerializeField] private float height = 1f;

    [Header("Camera Destance")]
    [SerializeField] private float distance = 2f;

    // Components

    private Vector3 offsetX;

     void Start()
    {
        offsetX = new Vector3(0,height,distance);
        Cursor.lockState = CursorLockMode.Locked;
    }

     void LateUpdate()
    {
        offsetX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speedRotation, Vector3.up)* offsetX;

        transform.position = camPivot.position + offsetX;
        transform.LookAt(camPivot.position);
    }
}


