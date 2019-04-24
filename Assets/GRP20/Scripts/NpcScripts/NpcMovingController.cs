using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class NpcMovingController : NpcController
    {
        public Transform[] positions;
        int posIndex;

        [SerializeField] float stepPrecision = 1;


        // Use this for initialization
        public override void Start()
        {
            base.Start();
            SetMove();
            animator.SetFloat("StateIndex", 1);
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();

            if (CustomMethod.AlmostEqual(transform.position, positions[posIndex].position, stepPrecision))
            {
                
                SetMove();
            }
        }

        void SetMove()
        {
            posIndex++;

            if (posIndex > positions.Length - 1)
            {
                posIndex = 0;
            }

            navMeshAgent.SetDestination(positions[posIndex].position);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;

            for (int i = 0; i < positions.Length; i++)
            {
                if(i == positions.Length - 1)
                {
                    Gizmos.DrawLine(positions[i].position, positions[0].position);
                    return;
                }

                Gizmos.DrawLine(positions[i].position, positions[i + 1].position);
            }
        }

    }
}

