using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnTheFlag : MonoBehaviour
{
    // SerializeFields
    [Header("Enemy Flag")]
    [SerializeField] GameObject baseFlag;

    [Header("Player Flage")]
    [SerializeField] GameObject myFlag;

    [Header("Object Timer")] // Time to Goal
    [SerializeField] GameObject objectTimer;
   
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Goal" && myFlag.activeSelf == true)
        {
            baseFlag.SetActive(true);
            myFlag.SetActive(false);
            objectTimer.SetActive(false);
        }
    }
}
