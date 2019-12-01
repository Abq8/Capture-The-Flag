using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Camera Pivot Object")]
    [SerializeField] GameObject cameraPivot;

    // Components
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - cameraPivot.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPivot.transform.position + offset; 
    }
   
}
