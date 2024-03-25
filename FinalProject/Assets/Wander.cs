using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{


    public float speed = 2f; // Adjust this value to control the speed of movement
    public float moveDistance = 2f; // Adjust this value to control how far the object moves left and right

    private Vector3 startPosition;
    private bool moveRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x >= startPosition.x + moveDistance)
        {
            moveRight = false;
        }
        else if (transform.position.x <= startPosition.x - moveDistance)
        {
            moveRight = true;
        }
    }
}