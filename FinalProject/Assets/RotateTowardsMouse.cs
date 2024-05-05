using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public GameObject spriteObject;

    void Update()
    {
        if (spriteObject == null)
        {
            return;
        }

        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, spriteObject.transform.position.z));

        Vector3 direction = mouseWorldPosition - spriteObject.transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        spriteObject.transform.rotation = Quaternion.Slerp(spriteObject.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
