using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThrower : MonoBehaviour
{
[SerializeField] GameObject ProjectilePrefab;
[SerializeField] float speed = 4;

    public void Launch(Vector3 targetPos) {
        GameObject newProjectile = Instantiate(ProjectilePrefab,transform.position, Quaternion.identity);
        newProjectile.transform.rotation = Quaternion.LookRotation(transform.forward, targetPos - transform.position);
        newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.up * speed;
        Destroy(newProjectile, 15);
    }
}
