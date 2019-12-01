using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    [SerializeField] GameObject otherFlag;
    [SerializeField] GameObject myFlag;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "PickUpFlag")
        {
            otherFlag.SetActive(false);
            myFlag.SetActive(true);
        }
    }
}
