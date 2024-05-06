

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AmmoDisplay : MonoBehaviour
{
    public int ammo;
    public bool isFiring;
    public TextMeshProUGUI ammoDisplay;

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(" ammo display text: " + ammo);

         if (ammoDisplay != null)
        {
            ammoDisplay.text = ammo.ToString();
        }
        else
        {
            Debug.LogWarning("TextMeshPro component not assigned!");
        }
        if (Input.GetMouseButtonDown(0) && !isFiring && ammo > 0)
        {
            isFiring = true;
            ammo--;
            isFiring = false;

        }
    }
}
