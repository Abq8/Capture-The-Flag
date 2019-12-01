using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotater : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool useOffsetValues;
    public float rotateSpeed;
    public Transform pivot;
    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
        offset = target.position - transform.position;
        pivot.transform.position = target.transform.position;
        //pivot.transform.parent = target.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Fire2") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        //float vertical = Input.GetAxis("Fire2") * rotateSpeed;
       // pivot.Rotate(-vertical, 0, 0);

        //float desiredYangle = target.eulerAngles.y;
        float desiredXangle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXangle, pivot.rotation.y, 0);
        transform.position = target.position - (rotation * offset);

        if (transform.position.y < target.position.y)
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.LookAt(target);

    }
}
