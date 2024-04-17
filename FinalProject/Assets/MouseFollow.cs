using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
        public GameObject gunSprite; // Reference to the sprite GameObject
        public Camera mainCamera; // Reference to the main camera

    // Start is called before the first frame update
    void Start()
    {
    // Get the mouse position in world coordinates
    Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    mousePosition.z = 0f; // Ensure the z-coordinate is set to 0 (assuming 2D setup)

    // Calculate the direction from the sprite to the mouse position
    Vector3 direction = mousePosition - gunSprite.transform.position;
    direction.Normalize(); // Normalize the direction vector

    // Use LookAt to make the sprite point towards the mouse position
    gunSprite.transform.up = direction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
