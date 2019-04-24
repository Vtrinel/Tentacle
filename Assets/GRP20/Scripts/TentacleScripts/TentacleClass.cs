using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    [System.Serializable]
    public class Tentacle
    {
        public LineRenderer lineRenderer;
        public List<TentaclePoint> tentaclePoints;

        public void UpdateTentacle()
        {
            lineRenderer.positionCount = tentaclePoints.Count;
            lineRenderer.numCapVertices = 30;
            //lineRenderer.numCornerVertices = 0;

            for (int i = 0; i < tentaclePoints.Count; i++)
            {
                lineRenderer.SetPosition(i, tentaclePoints[i].transform.position);
            }
        }

        public void CutTentacle(int indexToCut)
        {
            int nbrToRemove = tentaclePoints.Count - indexToCut; 

            for (int i = indexToCut; i < tentaclePoints.Count; i++)
            {
                tentaclePoints[i].IsCut = true;
            }

            tentaclePoints.RemoveRange(indexToCut, nbrToRemove);
        }

        public void SetCollisionLayer(LayerMask _newLayerMask)
        {
            for (int i = 0; i < tentaclePoints.Count; i++)
            {
                tentaclePoints[i].gameObject.layer = CustomMethod.LayerMaskToLayer(_newLayerMask);
            }
        }

        public void SetTriggerPoints()
        {
            for (int i = 0; i < tentaclePoints.Count; i++)
            {
                tentaclePoints[i].sphereCollider.isTrigger = true;
            }
        }

        //Constructor
        public Tentacle(List<TentaclePoint> _tentaclePoints, LineRenderer _lineRenderer)
        {
            tentaclePoints = new List<TentaclePoint>();
            tentaclePoints = _tentaclePoints;

            lineRenderer = _lineRenderer;
        }
    }
}

