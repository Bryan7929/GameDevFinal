using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLineRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer; // Reference to the Line Renderer component
    public GameObject playableCharacter; // Reference to the playable character GameObject
    public Camera mainCamera; // Reference to the main camera


    // Update is called once per frame
    void Update()
    {
    Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    mousePosition.z = 0f; // Ensure the z-coordinate is set to 0 (assuming 2D setup)

    // Set the first position of the line to the playable character's position
    lineRenderer.SetPosition(0, playableCharacter.transform.position);

    // Set the second position of the line to the mouse position
    lineRenderer.SetPosition(1, mousePosition);
    }
}
