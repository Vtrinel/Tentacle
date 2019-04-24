using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class TentacleShadow : MonoBehaviour
    {
        public LineRenderer lineRenderer;
        public Tentacle tentacle;
        List<Vector3> linePositions;
        public LayerMask groundLayer = 0;
        public float yAjustement = 0.1f;
        [HideInInspector]
        public bool stopUpdate;

        void Start()
        {
            
        }


        void Update()
        {
            UpdateLine();
        }

        float GetYPosition(Transform _transform)
        {
            float _y = transform.position.y;

            /*
            Vector3 raycastEndPoint = new Vector3(_transform.position.x, _transform.position.y - 100, _transform.position.z);
            Vector3 raycastDirection = raycastEndPoint - _transform.position;
            Ray ray = new Ray(_transform.position,raycastDirection);
            RaycastHit hit = new RaycastHit();
            Physics.Raycast(ray.origin, ray.direction.normalized * 8, out hit, 100,groundLayer, QueryTriggerInteraction.Collide);
            Debug.DrawRay(_transform.position, raycastDirection.normalized * 8, Color.yellow);

            if(hit.collider != null)
            {
                ICuttable cuttable = hit.collider.GetComponent<ICuttable>();
                _y = hit.point.y + yAjustement;
            }
            */

            return _y;
        }

        public void UpdateLine()
        {
            if (stopUpdate) return;

            UpdateLinePositions();
            UpdateLineWidth();
        }

        void UpdateLinePositions()
        {
            linePositions = new List<Vector3>();

            for (int i = 0; i < tentacle.lineRenderer.positionCount; i++)
            {
                float _x = tentacle.lineRenderer.GetPosition(i).x;
                float _y = transform.position.y;

                if (i < tentacle.tentaclePoints.Count)
                {
                    _y = GetYPosition(tentacle.tentaclePoints[i].transform);
                }
                
                float _z = tentacle.lineRenderer.GetPosition(i).z;
                Vector3 position = new Vector3(_x, _y, _z);

                linePositions.Add(position);
            }

            lineRenderer.positionCount = tentacle.lineRenderer.positionCount;
            lineRenderer.SetPositions(linePositions.ToArray());
        }

        void UpdateLineWidth()
        {
            lineRenderer.startWidth = tentacle.lineRenderer.startWidth;
            lineRenderer.endWidth = lineRenderer.endWidth;
        }
    }
}

