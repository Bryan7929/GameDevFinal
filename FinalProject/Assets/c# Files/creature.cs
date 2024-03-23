    using System.Collections;
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using UnityEngine;

    public class creature : MonoBehaviour
    {
        [Header("stats")]
        [SerializeField] int health = 69;
        [SerializeField] float speed = 0f;
        [SerializeField] float jumpForce = 10;
        
        [Header("physics")]
        [SerializeField] LayerMask groundMask;
        [SerializeField] float jumpOffset = -0.5f;
        [SerializeField] float jumpRadius = 0.25f;

        public enum CreatureMovementType{tf, physics};
        [SerializeField] CreatureMovementType movementType = CreatureMovementType.tf;
        Rigidbody2D rb;


        // Start is called before the first frame update
        void Start(){
            Debug.Log(health);
            rb = GetComponent<Rigidbody2D>();
        }
        
        public void MoveCreature(Vector3 direction)
        {
            if(movementType == CreatureMovementType.tf)
            {
            MoveCreatureTransform(direction);
            } else if (movementType == CreatureMovementType.physics)
            {
                MoveCreatureRb(direction);
            }
        }


        public void MoveCreatureRb(Vector3 direction) {
            Vector3 currentVelocity = new Vector3(0,rb.velocity.y, 0);
            rb.velocity = (currentVelocity) + (direction * speed);
        }
        
        public void MoveCreatureTransform(Vector3 direction)
        {
            transform.position += direction * Time.deltaTime * speed;
        }
        public void Jump()
        {
        if(Physics2D.OverlapCircleAll(transform.position + new Vector3(0,jumpOffset,0), jumpRadius, groundMask).Length > 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    } 
}