using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class TentacleAnimator : MonoBehaviour
    {

        public List<Transform> positions;
        public Transform startPoint, endPoint;
        float distance;

        public AnimationCurve curveY;
        public AnimationCurve curveZ;
        public float amplitude = 1;


        // Use this for initialization
        void Start()
        {
            distance = Vector3.Distance(startPoint.position, endPoint.position);
        }

        private void OnBecameInvisible()
        {
            
        }

        // Update is called once per frame
        void LateUpdate()
        {
            PointAnimator();
        }

        void PointAnimator()
        {

            for (int i = 0; i < positions.Count; i++)
            {
                Vector3 position = positions[i].position;
                float pointDistance = Vector3.Distance(position, endPoint.position);

                //AdjustPosition
                float percent = pointDistance / distance;
                float nextY = curveY.Evaluate(percent) * amplitude;
                float nextZ = curveZ.Evaluate(percent) * amplitude;

                Vector3 nextPos = new Vector3(positions[i].localPosition.x, 0 + nextY, 0 + nextZ);
                positions[i].localPosition = nextPos;
            }

        }
    }
}

