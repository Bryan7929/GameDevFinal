using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RollCredits : MonoBehaviour
{
public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("MC"))
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
