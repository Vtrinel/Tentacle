using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class TentacleMovement : MonoBehaviour
    {
        [Header("Tentacle Movement values")]
        public Rigidbody body;
        public float speed = 300;
        public Vector3 moveDirection = Vector3.left;

        [Tooltip("Vaut mieux laisser en false au début")]
        public bool stopMoving = false;

        public virtual void Move()
        {

        }

        public virtual void StopMovement()
        {
            stopMoving = true;
            body.velocity = Vector3.zero; //Stop movement
        }

        public virtual void Fall()
        {
            StopMovement();
            body.useGravity = true;
        }
    }
}

