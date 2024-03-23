using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{

    [SerializeField] creature playerCreature;
    ProjectileThrower projectileThrower;

    void Start()
    {
        projectileThrower = playerCreature.GetComponent<ProjectileThrower>();
    }

    //called once per frame
    void Update()
    {
//-----------------------------------------------
        Vector3 input = Vector3.zero;

        if (Input.GetButton("Horizontal")){
            Debug.Log("Horizontal Movement Pressed");
            input.x = Input.GetAxis ("Horizontal");
        }
        if(Input.GetButtonDown("Jump")){
         Debug.Log("Jump Button Pressed");
         playerCreature.Jump();
        }
        if(Input.GetKey(KeyCode.R)) {
            Debug.Log("Reload Started");    
        }
        playerCreature.MoveCreature(input);
//-----------------------------------------------

    }
}
/*
        if(Input.GetKeyDown(KeyCode.E)) {
            projectileThrower.Launch(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
*/