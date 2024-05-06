

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThrower : MonoBehaviour
{
    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] float speed = 4;
    [SerializeField] float closerDistance = 1.5f; // Serialized field for closer distance
    [SerializeField] float flyTime = 2;

    public void Launch(Vector3 targetPos)
    {
        Vector3 directionToTarget = targetPos - transform.position;
        Vector3 normalizedDirection = directionToTarget.normalized;
        Vector3 newPosition = transform.position + normalizedDirection * closerDistance;

        GameObject newProjectile = Instantiate(ProjectilePrefab, newPosition, Quaternion.identity);
        Quaternion rotation = Quaternion.LookRotation(transform.forward, targetPos - newPosition);
        newProjectile.transform.rotation = rotation;

        Rigidbody2D rb2D = newProjectile.GetComponent<Rigidbody2D>();
        if (rb2D != null)
        {
            rb2D.velocity = newProjectile.transform.up * speed;
        }
        else
        {
            Debug.LogWarning("Rigidbody2D component not found on the projectile!");
        }

        Destroy(newProjectile, flyTime);
    }
}
