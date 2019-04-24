using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class ViciousTentacleMovement : TentacleMovement
    {

        [Header("Vicious Tentacle Movement")]
        [Range(0f, 1f)]
        public float impulseChancePercent = 0.1f;
        public Transform endPoint;
        [SerializeField] float stopMovementPrecision = 0.5f;


        private void Start()
        {

        }

        public override void Move()
        {
            base.Move();

            if (stopMoving) return;
            float chance = Random.Range(0f, 1f);

            if (chance <= impulseChancePercent)
            {
                //movement
                body.AddForce(moveDirection * speed, ForceMode.Impulse);
                Debug.Log("Impulse");
            }

            //check if need to stop movement
            if (CustomMethod.AlmostEqualOnOneAxis(transform.position, endPoint.position, stopMovementPrecision, CustomMethod.Axis.X))
            {
                StopMovement();
            }
        }
    }
}

