using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class TentacleCreator : MonoBehaviour
    {

        public Tentacle currentTentacle;
        public List<TentaclePoint> points;
        public int pointsLayerIndex = 5;

        public Material lineMaterial;
        public int tentaclePointNumber = 10;
        public float tentaclePointAmplitude = 10;

        [Header("Debug")]
        public bool debugMode;

        void Start()
        {

        }

        void Update()
        {
            if (debugMode)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    Creation();
                    currentTentacle.UpdateTentacle();
                }

                if(currentTentacle != null)
                {
                    currentTentacle.UpdateTentacle();
                }
                
            }
        }

        [ContextMenu("Create Tentacle")]
        void Creation()
        {
            TentacleCreation(1, 0,Vector3.zero);
            currentTentacle.UpdateTentacle();
        }
        
        public virtual void TentacleCreation(float _startWidth, float _endWidth,Vector3 spawnPosition)
        {
            GameObject tentacle = new GameObject("tentacle");
            tentacle.transform.position = spawnPosition;
            LineRenderer line = tentacle.AddComponent<LineRenderer>(); //create line Renderer;
            line.material = lineMaterial;

            TentaclePointCreation(tentacle.transform);

            Tentacle t = new Tentacle(points, line);

            line.startWidth = _startWidth;
            line.endWidth = _endWidth;

            currentTentacle = t;
            t.UpdateTentacle();
        }

        public virtual void TentaclePointCreation(Transform _parent)
        {
            points = new List<TentaclePoint>();

            //define amplitude
            float maxDistance = tentaclePointAmplitude / 2;
            float minDistance = -maxDistance;

            //Create all transforms (gameObject)

            for (int i = 0; i < tentaclePointNumber; i++)
            {
                float currentPercent = (float)i / tentaclePointNumber;
                float posX = Mathf.Lerp(minDistance, maxDistance, currentPercent);

                //create GO
                GameObject point = new GameObject("tentaclePoint_" + i);
                point.layer = pointsLayerIndex;
                point.transform.SetParent(_parent);
                point.transform.localPosition = new Vector3(-posX, 0, 0);

                //crate tentacle point component
                TentaclePoint tp = point.AddComponent<TentaclePoint>();
                tp.PointCreation(i);

                points.Add(tp);
            }

        }
    }
}

