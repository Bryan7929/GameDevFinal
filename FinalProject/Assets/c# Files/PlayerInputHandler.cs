using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] creature playerCreature;
    ProjectileThrower projectileThrower;
    private Animator _animator;

static int x = 0;
    [SerializeField] static int Max = 10;
    [SerializeField] static int Remaining = 4;

    void Start()
    {
        projectileThrower = playerCreature.GetComponent<ProjectileThrower>();
        _animator = GetComponent<Animator>();

    }

    //called once per frame
    void Update()
    {
        _animator.SetBool("IsWalking", x != 1);

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
        if (Input.GetKeyDown(KeyCode.Space)) //Shoots primary
        { 
            Debug.Log("Firing Primary");
            //checks Reserves b4 shooting
            if (Remaining != 0){
                projectileThrower.Launch(Camera.main.ScreenToWorldPoint(Input.mousePosition));

                Remaining -= 1;
              
            }
            else if (Remaining == 0){
                //N/A ammo message
                Debug.Log("Out of Ammo - *CLICK*");
            }
        }
        if (Input.GetKeyDown(KeyCode.R)){ 
                Chamber(); //Starts Reload
            }
         //Gun reload code-----------------------------------------------------------------------------
    }



















    static void Chamber(){
                Debug.Log("Updating Ammo");
                Debug.Log(Remaining);
                // Reloads single bullet
                if(Remaining != Max){
                Remaining += 1;
                }

                else if(Remaining == Max){
                    Debug.Log("Max Ammo Capacity");
                }
    }
}



















/*
// Get the current position of the projectile thrower
Vector3 throwerPosition = projectileThrower.transform.position;

// Adjust the Y-coordinate to shoot vertically back
throwerPosition.y += 10f; // Adjust the value as needed

// Launch the projectile from the adjusted position
projectileThrower.Launch(throwerPosition);
*/