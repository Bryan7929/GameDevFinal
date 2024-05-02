using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CameraShift : MonoBehaviour
    {
        public float shiftAmount = 2f;
        public bool CamShiftRight = true;
        public GameObject objectToDisable;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if(CamShiftRight == true)
            {
        if(other.gameObject.CompareTag("MC"))
            {            
            Debug.Log("Camera Shifting...");
            Vector3 newPosition = Camera.main.transform.position;
            newPosition.x += shiftAmount;
            Camera.main.transform.position = newPosition;
            objectToDisable.SetActive(false);

            }
        }
            else if(CamShiftRight == false)
            {
        if(other.gameObject.CompareTag("MC"))
            {            
            Debug.Log("Camera Shifting...");
            Vector3 newPosition = Camera.main.transform.position;
            newPosition.x -= shiftAmount;
            Camera.main.transform.position = newPosition;
            objectToDisable.SetActive(false);
            }
        }
    }
}