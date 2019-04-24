using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class MovingObject : ObstacleMovement
    {
        [Header("Pouting movement values")]
        [Tooltip("Fluctuation de la direction du movement (1 = Droite, -1 = Gauche")]
        public AnimationCurve moveDirectionCurve;
        [Tooltip("l'amplitude de la fluctuation du mouvement")]
        public float curveAmplitude = 20;

        public Vector3 moveDirection = Vector3.back;
        public float speed = 10;
        public Rigidbody rb;

        public bool CanMove
        {
            get
            {
                return canMove;
            }

            set
            {
                if(value == false)
                {
                    rb.velocity = Vector3.zero;
                }

                canMove = value;
            }
        }

        void Start()
        {
            moveDirectionCurve.postWrapMode = WrapMode.Loop; //Set curve to loop
        }

        
        void Update()
        {
            Move();
        }

        public override void Move()
        {
            if (!canMove) return;

            //Set direction
            float fluctuation = moveDirectionCurve.Evaluate(Time.time);
            float newAngle = fluctuation * curveAmplitude;
            Vector3 direction = new Vector3(moveDirection.x + newAngle, moveDirection.y, moveDirection.z);

            //Apply movement to rigidbody
            rb.velocity = direction * (speed * Time.deltaTime);
        }


        [ContextMenu("Initialize")]
        public void Intialiaze()
        {
            rb = GetComponent<Rigidbody>();

            if(rb == null)
            {
                rb = gameObject.AddComponent<Rigidbody>();
            }
        }
    }
}
