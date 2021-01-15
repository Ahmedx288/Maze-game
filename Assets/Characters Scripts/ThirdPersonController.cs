using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class ThirdPersonController : MonoBehaviour {
    public CharacterController controller;

    public GameObject MiniMapSpawner;
    MiniMapFollow MiniMapFollow;

    public Transform Cam;
    private CinemachineFreeLook freeLook;

    Animator Anim;
    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Manager Manager;

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

        Manager = GameObject.Find("SaveLoad Manager").GetComponent<Manager>();

        
        //Get the script from the mini map camera
        MiniMapFollow = GameObject.Find("Mini Map Camera").GetComponent<MiniMapFollow>();
        //Set the mini map camera
        MiniMapFollow.Player = this.transform;
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

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    //Refresh the player camera and position according to the scene;  (Refresh pointed Objects)
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        Cam = GameObject.Find("Main Camera").GetComponent<Transform>();
        freeLook = GameObject.Find("Third Person Camera").GetComponent<CinemachineFreeLook>();
        freeLook.LookAt = this.transform;
        freeLook.Follow  = this.transform;

        //Send the character to the level starting poing
        transform.position = new Vector3(0,0,0);

        //Get the script from the mini map camera
        //Set the mini map camera
        MiniMapFollow = GameObject.Find("Mini Map Camera").GetComponent<MiniMapFollow>();
        MiniMapFollow.Player = this.transform;

        Manager = GameObject.Find("SaveLoad Manager").GetComponent<Manager>();
        if(Manager.flag){
            transform.position = new Vector3(Manager.ManagerData.trans[0],Manager.ManagerData.trans[1],Manager.ManagerData.trans[2]);
        }

    }
}
