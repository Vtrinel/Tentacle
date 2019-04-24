using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GRP20
{
    [ExecuteInEditMode]
    public class TentacleManager : MonoBehaviour
    {
        public Tentacle tentacle;
        public TentacleCreator tentacleCreator;
        public LayerMask tentaclePointsLayer;

        [Header("Tentacle Movement behaviour")]
        public TentacleMovement tentacleMovement;
        bool canMove;

        [Header("Life")]
        public int killIndex;
        public bool isDead;

        [Header("Events")]
        public UnityEvent cutEvent;

        [Header("debug")]
        public int indexToCut = 2;
        public bool startMoving;


        public bool CanMove
        {
            get
            {
                return canMove;
            }

            set
            {
                canMove = value;
                //tentacleMovement.StopMovement();
            }
        }

        void Start()
        {
            CanMove = startMoving;
        }

        // Update is called once per frame
        void Update()
        {
            tentacle.UpdateTentacle();

            if (Input.GetKeyDown(KeyCode.V))
            {
                CutTentacle(indexToCut);
            }
        }

        private void FixedUpdate()
        {
            if (!isDead && canMove)
            {
                tentacleMovement.Move();
            }
        }

        
        public void CutTentacle(int _cutIndex)
        {
            //SFX
            GameManager.gameManager.audioManager.PlayTentacleImpact();
            
            //Check Death
            if (_cutIndex <= killIndex)
            {
                isDead = true;

                if(tentacleMovement != null)
                    tentacleMovement.Fall();

                cutEvent.Invoke();
            }

            //Get width
            float sw = CustomMethod.GetLineWidthAtPoint(_cutIndex, tentacle.lineRenderer);
            float ew = CustomMethod.GetLineWidthAtPoint(tentacle.tentaclePoints.Count - 1, tentacle.lineRenderer);

            //Get number and amplitude of point
            Vector2 a = tentacle.tentaclePoints[_cutIndex].transform.localPosition;
            Vector2 b = tentacle.tentaclePoints[tentacle.tentaclePoints.Count - 1].transform.localPosition;
            float amp = Vector2.Distance(a, b);
            int number = tentacle.tentaclePoints.Count - _cutIndex;


            //CREATE NEW TENTACLE
            tentacleCreator.tentaclePointAmplitude = amp;
            tentacleCreator.tentaclePointNumber = number;
            tentacleCreator.TentacleCreation(sw, ew, transform.position);

            Tentacle newTentacle = tentacleCreator.currentTentacle;
            int count = 0;

            for (int i = 0; i < newTentacle.tentaclePoints.Count; i++)
            {
                int index = _cutIndex + count;
                newTentacle.tentaclePoints[i].transform.localPosition = tentacle.tentaclePoints[index].transform.localPosition;
                count++;
            }

            newTentacle.UpdateTentacle();

            //CUT TENTACLE
            tentacle.CutTentacle(_cutIndex);
            tentacle.lineRenderer.endWidth = sw; //update width

            //VFX
            GameManager.gameManager.splashManager.StartSplash();
        }

        [ContextMenu("Set isTrigger To All Points")]
        public void SetTriggers()
        {
            tentacle.SetTriggerPoints();
        }

        [ContextMenu("Set Layers to points")]
        public void SetLayers()
        {
            tentacle.SetCollisionLayer(tentaclePointsLayer);
        }
    }
}

