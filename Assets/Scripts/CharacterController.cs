using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Components
    public Animator soldierAnimator;
    Rigidbody rb;

    // SerializeFields
    [Header("Soldier Movment")]
    [SerializeField] private float speed;

    [Header("Main Camera")]
    [SerializeField] private GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        soldierAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        precessMovement();
        animateCharacter();
    }
    void precessMovement()
    {
        Vector3 fromCameraToMe = transform.position - mainCamera.transform.position;
        fromCameraToMe.y = 0;
        fromCameraToMe.Normalize();


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = (fromCameraToMe * vertical + mainCamera.transform.right * horizontal) * speed;


        if (movement != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movement), speed);


        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    void animateCharacter()
    {
        if (Input.GetKey("w") || Input.GetKey("s")|| Input.GetKey("a") || Input.GetKey("d") )
            soldierAnimator.SetBool("isWalking", true);
        else
            soldierAnimator.SetBool("isWalking", false);


        if (Input.GetKey(KeyCode.RightShift)) 
        { 
            soldierAnimator.SetBool("isRunning", true);
            speed = 3;
        }
        else      
        {
            soldierAnimator.SetBool("isRunning", false);
            speed = 1;
        }
    }
}
