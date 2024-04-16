using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class DeathTap : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("MC"))
        {
            Debug.Log("Insta Death triggered");
            SceneManager.LoadScene("LevelOne");
        }
    }
}