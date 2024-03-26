using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] creature playerCreature;
    ProjectileThrower projectileThrower;

    [SerializeField] int Max = 10;
    [SerializeField] int Remaining = 4;

    void Start()
    {
        projectileThrower = playerCreature.GetComponent<ProjectileThrower>();
    }

    //called once per frame
    void Update()
    {
        Vector3 input = Vector3.zero;

        if (Input.GetButton("Horizontal"))
        {
            Debug.Log("Horizontal Movement Pressed");
            input.x = Input.GetAxis("Horizontal");
        }
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump Button Pressed");
            playerCreature.Jump();
        }

        playerCreature.MoveCreature(input);

        //Gun reload code
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            //checks for ammo and fires if there's a remaining bullet
            Debug.Log("Firing Primary");
            if (Remaining != 0)
            {
                Remaining -= 1;
                projectileThrower.Launch(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            else if (Remaining == 0)
            {
                //Prints "Out of Ammo" if there's no remaining bullets
                Debug.Log("Out of Ammo");
            }

        }
        if (Input.GetKeyDown(KeyCode.R))
            { 
                // Reloads single bullet
                Debug.Log("Updating Ammo");
                Debug.Log(Remaining);
                if(Remaining != Max)
                {
                Remaining += 1;
                }
                else if(Remaining == Max){
                    Debug.Log("Max Ammo Capacity");
                }
            }
    }
}
