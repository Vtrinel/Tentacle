using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class TentacleSpecialMovement : TentacleMovement
    {
        [Header("Special Tentacle Movement")]
        public AnimationCurve speedEvolution;
        public Transform startPoint, endPoint;
        [SerializeField] float stopMovementPrecision = 0.5f;

        private float distance;


        private void Start()
        {
            distance = Vector2.Distance(startPoint.position, endPoint.position);
        }

        public override void Move()
        {
            base.Move();

            if (stopMoving) return;

            //Speed calcul
            float currentDistance = Vector2.Distance(transform.position, startPoint.position); //Get distance from this to end
            float disPercent = currentDistance / distance; //get the percent
            float curveEval = speedEvolution.Evaluate(disPercent); //evaluate curve with previous percent
            float currentSpeed = speed * curveEval; //multiply speed with the value on the curve

            Vector3 dir = transform.TransformDirection(-Vector3.right);

            //movement
            body.velocity = dir * currentSpeed * Time.deltaTime; //set velocity on rigidbody



            //check if need to stop movement
            if (CustomMethod.AlmostEqualOnOneAxis(transform.position, endPoint.position, stopMovementPrecision, CustomMethod.Axis.X))
            {
                StopMovement();
            }
        }
    }
}

