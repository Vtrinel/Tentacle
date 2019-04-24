using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class PatrolObject : ObstacleMovement
    {
        public enum MovementType
        {
            Linear,
            SmoothDamp,
            LeanTweenMove
        }

        public Transform[] patrolPoints;
        public int currentPatrolPointIndex;
        public float nextPointPrecision = 0.1f;

        [Header("Move")]
        public MovementType movementType;
        public float smoothTime = 1;
        Vector3 velocity;

        List<Vector3> positions = new List<Vector3>();

        private void Start()
        {
            for (int i = 0; i < patrolPoints.Length; i++)
            {
                positions.Add(patrolPoints[i].position);
            }
        }

        private void Update()
        {
            Move();
        }

        public override void Move()
        {
            if (!canMove) return;

            switch (movementType)
            {
                case MovementType.Linear:
                    transform.position = Vector3.Lerp(transform.position, patrolPoints[currentPatrolPointIndex].position, smoothTime);
                    break;
                case MovementType.SmoothDamp:
                    transform.position = Vector3.SmoothDamp(transform.position, patrolPoints[currentPatrolPointIndex].position, ref velocity, smoothTime);
                    break;
                case MovementType.LeanTweenMove:
                    //LeanTween.moveSpline(gameObject, positions.ToArray(), smoothTime).setEase(LeanTweenType.easeInOutBounce);
                    LeanTween.move(gameObject, patrolPoints[currentPatrolPointIndex], smoothTime);
                    // LeanTween.moveSpline(gameObject, new Vector3[] { new Vector3(0f, 0f, 0f), new Vector3(1f, 0f, 0f), new Vector3(1f, 0f, 0f), new Vector3(1f, 0f, 1f) }, 1.5f).setEase(LeanTweenType.easeOutQuad).setOrientToPath(true);
                    break;
            }
            

            if (CustomMethod.AlmostEqual(transform.position, patrolPoints[currentPatrolPointIndex].position, nextPointPrecision))
            {
                NextMovePoint();
            }
        }

        void NextMovePoint()
        {
            currentPatrolPointIndex++;

            if (currentPatrolPointIndex > patrolPoints.Length - 1)
            {
                currentPatrolPointIndex = 0;
            }
        }
    }
}

