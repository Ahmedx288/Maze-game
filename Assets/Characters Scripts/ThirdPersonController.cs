using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonController : MonoBehaviour {
    public CharacterController controller;
    public Transform Cam;
    private CinemachineFreeLook freeLook;
    Animator Anim;
    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Awake() {
        DontDestroyOnLoad(this.gameObject); 
    }

    void Start(){
        Anim = GetComponent<Animator>();

        //Get the main camera and attach it to the character.
        Cam = GameObject.Find("Main Camera").GetComponent<Transform>();

        //Get the third person view camera and set both fields LookAt and Follow to the Character.
        freeLook = GameObject.Find("Third Person Camera").GetComponent<CinemachineFreeLook>();
        freeLook.LookAt = this.transform;
        freeLook.Follow  = this.transform;
    }

    // Movement Control and Animation
    void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f , vertical).normalized;

        if(direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);

            Anim.SetBool("isWalking", true);
        }else {
            Anim.SetBool("isWalking", false);
        }
    }

    //Refresh the player camera and position according to the scene;  (Refresh pointed Objects)
    void OnLevelWasLoaded(){
        Cam = GameObject.Find("Main Camera").GetComponent<Transform>();
        freeLook = GameObject.Find("Third Person Camera").GetComponent<CinemachineFreeLook>();
        freeLook.LookAt = this.transform;
        freeLook.Follow  = this.transform;

        //Send the character to the level starting poing
        transform.position = new Vector3(0,0,0);
    }
}
