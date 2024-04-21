using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] creature playerCreature;
    ProjectileThrower projectileThrower;
    private Animator _animator;
    //public static Text ammoText;
    public Text textComponent; //testing UI string change

    static int x = 0;
    [SerializeField] static int Max = 10;
    [SerializeField] static int Remaining = 4;

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
                //ammoText.text = "Ammo: " + Remaining + "/" + Max;
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
//-----------------------------------------------------------My Own code-------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------ChatGPT code------------------------------------------------------------------
/*
public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] creature playerCreature;
    ProjectileThrower projectileThrower;
    private Animator _animator;
    [SerializeField] static Text ammoText; // Serialized field for the UI text
    static int x = 0;
    [SerializeField] static int Max = 10;
    [SerializeField] static int Remaining = 4;
 
    void Start()
    {
        projectileThrower = playerCreature.GetComponent<ProjectileThrower>();
        _animator = GetComponent<Animator>();
        UpdateAmmoDisplay(); // Update the UI text on start
    }

    void Update()
    {
        _animator.SetBool("IsWalking", x != 1);

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Firing Primary");
            if (Remaining != 0)
            {
                projectileThrower.Launch(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                Remaining -= 1;
                UpdateAmmoDisplay(); // Update UI text after shooting
            }
            else if (Remaining == 0)
            {
                Debug.Log("Out of Ammo - *CLICK*");
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Chamber();
        }
    }

    static void UpdateAmmoDisplay()
    {
        ammoText.text = "Ammo: " + Remaining + "/" + Max;
    }

    static void Chamber()
    {
        Debug.Log("Updating Ammo");
        if (Remaining != Max)
        {
            Remaining += 1;
            UpdateAmmoDisplay(); // Update UI text after reloading
        }
        else if (Remaining == Max)
        {
            Debug.Log("Max Ammo Capacity");
        }
    }
}
*/