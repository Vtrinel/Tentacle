using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class TentaclePoint : MonoBehaviour,ICuttable, ITentacle
    {
        public SphereCollider sphereCollider;
        public int pointIndex;
        float radius = 0.25f;
        public TentacleManager manager;
        bool isCut;

        [Header("debug")]
        public bool debug;

        public bool IsCut
        {
            get
            {
                return isCut;
            }

            set
            {
                isCut = value;
            }
        }

        

        private void Update()
        {
            if (debug)
            {
                if (Input.GetKeyDown(KeyCode.V))
                {

                }
            }
        }

        public void PointCreation(int _pointIndex)
        {
            sphereCollider = gameObject.AddComponent<SphereCollider>();
            sphereCollider.radius = radius;
            sphereCollider.isTrigger = true;
            pointIndex = _pointIndex;
        }

        public void Cut()
        {
            if (manager == null) return;
            if (IsCut) return;

            manager.CutTentacle(pointIndex);
            IsCut = true;
            GameManager.gameManager.vfxManager.CutImpact(transform.position);
            GameManager.gameManager.timeManager.StartFreezeFrame();
            CamShake.camShake.StartShakeCam();
        }

        public bool IsAlive()
        {
            bool cut = isCut;
            return !cut;
        }
    }
}

