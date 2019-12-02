using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickUp : MonoBehaviour
{
    // SerializeFields

    [Header("Enemy Flag")]
    [SerializeField] GameObject otherFlag;

    [Header("Player Flag")]
    [SerializeField] GameObject myFlag;

    [Header("Canvas Timer")]
    [SerializeField] GameObject objectTimer; // canavas timer(object) used to hide the time
    [SerializeField] Text textTimer; // canvas timer (string or text) used to calculate time

    // Components

    private bool setTimer = false; // Set timer

    // Update is called once per frame
    void Update()
    {
        if (setTimer == true)  // Reduce the time by 1 sec
        {
            ReduceTime();
        }


        if (float.Parse(textTimer.text) <= 0.0f && textTimer.color == Color.red)// pars to convert string to float(couse we use time. delta(float)). Condetion used to pickup the flag.
        {
            textTimer.text = "10";
            otherFlag.SetActive(false);
            myFlag.SetActive(true);
        }

        checkIfCaptureTheFlag();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "PickUpFlag")
        {
            setTimer = true;
            objectTimer.SetActive(true);
       
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "PickUpFlag" && myFlag.activeSelf == false)
        {
            objectTimer.SetActive(false);
            setTimer = false;
            textTimer.text = "10";
        }
    }

    void ReduceTime()
    {
        // The Timer is in string format, we need to convert the string '10' into float number 10.0f
        float currentTime = float.Parse(textTimer.text);

        
           
        // Calculate the time which is reduced by 1(sec) => 10.0f becomes 9.0f and so on....
        if (currentTime > 0f)
            currentTime = currentTime - Time.deltaTime;

        //To change the text, which is in canvax, we need to convert the float timer back into string
        textTimer.text = currentTime.ToString();

    }

    void checkIfCaptureTheFlag()
    {
        
        if (myFlag.activeSelf == true)
        {
   
            textTimer.color =Color.green;
            ReduceTime();

            if (float.Parse(textTimer.text) <= 0.0f)
            {
           
                otherFlag.SetActive(true);
                myFlag.SetActive(false);
                objectTimer.SetActive(false);
                textTimer.color = Color.red;
                textTimer.text = "10";
            }
            
        }
    }
}
