using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] creature playerCreature;
    ProjectileThrower projectileThrower;
    private Animator _animator;
    public AudioSource GunShot;
    public AudioSource Reload;
    public AudioSource EmptyFire;


    public Text textComponent; //testing UI string change

    static int x = 0;
    [SerializeField] static int Max = 10;
    [SerializeField] static int Remaining = 4;
    public AmmoDisplay ammoText;

    void Start()
    {
        projectileThrower = playerCreature.GetComponent<ProjectileThrower>();
        _animator = GetComponent<Animator>();

        if(textComponent != null)
        {
            textComponent.text = "New Text";
        }
    }

    //called once per frame
    void Update()
    {
        _animator.SetBool("IsWalking", x != 1);
        ammoText.ammo = Remaining;
        Vector3 input = Vector3.zero;

        if (Input.GetButton("Horizontal")){
            Debug.Log("Horizontal Movement Pressed");
            input.x = Input.GetAxis("Horizontal");
        }
        if (Input.GetButtonDown("Jump")){
            Debug.Log("Jump Button Pressed");
            playerCreature.Jump();
        }
        playerCreature.MoveCreature(input);

        //Gun reload code-----------------------------------------------------------------------------
        if (Input.GetMouseButtonDown(1)) //Shoots primary| changed from firing with "spacebar" to fire with left mouse click
        { 
            Debug.Log("Firing Primary");
            //checks Reserves b4 shooting
            if (Remaining != 0){
                projectileThrower.Launch(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                GunShot.Play();
                //ammoText.text = "Ammo: " + Remaining + "/" + Max;
                Remaining -= 1;
              
            }
            else if (Remaining == 0){
                //N/A ammo message
                Debug.Log("Out of Ammo - *CLICK*");
                EmptyFire.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.R)){ 
                Chamber(); //Starts Reload
                Reload.Play();
            }
         //Gun reload code^^^^^-----------------------------------------------------------------------
    }



    static void Chamber(){
                Debug.Log("Updating Ammo");
                Debug.Log(Remaining);
                // Reloads single bullet
                if(Remaining != Max){
                Remaining += 1;
             //   ammoText.text = "Ammo: " + Remaining + "/" + Max;

                }

                else if(Remaining == Max){
                    Debug.Log("Max Ammo Capacity");
                }
    }
}
