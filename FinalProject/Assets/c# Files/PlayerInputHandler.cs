using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{

    [SerializeField] creature playerCreature;
    ProjectileThrower projectileThrower;

    void Start ()
    {
        projectileThrower = playerCreature.GetComponent<ProjectileThrower>();
    }

    // Update is called once per frame
    void Update()
    {
/*-----------------------------------------------*/
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.A)){
            Debug.Log("A held\n");
            input.x = -1;
        }
        if (Input.GetKey(KeyCode.D)){
            Debug.Log("D held\n");
            input.x = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerCreature.Jump();
        }

        if(Input.GetKeyDown(KeyCode.E)) {
            projectileThrower.Launch(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
/*-----------------------------------------------*/
        if(Input.GetKey(KeyCode.R)) {
            Debug.Log("Reload Started");
            
}
/*-----------------------------------------------*/



        playerCreature.MoveCreature(input);
    }
}


    /*    if(Input.GetKeyDown(KeyCode.Q)){
            playerCreature.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f,1f), Random.Range(0f,1f),Random.Range(0f,1f));
        }*/