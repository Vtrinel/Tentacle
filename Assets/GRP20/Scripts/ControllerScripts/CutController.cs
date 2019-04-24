using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class CutController : MonoBehaviour
    {

        public Rigidbody body;
        public bool canCut = true;
        public float noCutDuration = 1.5f;
        public bool isCutting;
        public LayerMask targetLayer;
        public Camera mainCam;
        public float camDistance = 10;
        private Vector3 lastMousePosition;
        public int checkRaycast = 200;

        Vector3 targetPosition;

        [Header("Cut collider")]
        public CutCollider cutCollider;

        [Header("Cut effects")]
        public CannotCutEffect cannotCutEffect;
        public CutTrailEffect trailEffect;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            CheckCut();
            Cutting();
            Positionning();
            DrawCutOnScreen();
        }

        private void LateUpdate()
        {
            lastMousePosition = Input.mousePosition;
        }

        void Positionning()
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            Physics.Raycast(ray.origin, ray.direction, out hit, 100, targetLayer, QueryTriggerInteraction.Collide);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.magenta);

            targetPosition = ray.GetPoint(camDistance);
            trailEffect.SetTrailPosition(targetPosition);

            body.MovePosition(targetPosition);
        }

        void CheckCut()
        {
            if (!canCut) return;

            if (Input.GetMouseButton(0))
            {
                isCutting = true;
                cutCollider.canCut = true;
            }
            else
            {
                isCutting = false;
                cutCollider.canCut = false;
            }
        }

        void Cutting()
        {
            if (!canCut) return;
            if (!isCutting) return;

            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            Physics.Raycast(ray.origin, ray.direction, out hit, 100, targetLayer, QueryTriggerInteraction.Collide);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 3);

            if (hit.collider != null)
            {
                ICuttable cuttable = hit.collider.GetComponent<ICuttable>();

                if (cuttable != null)
                {
                    cuttable.Cut();
                    
                    Debug.Log("TOUCHED");
                }
            }

        }


        void DrawCutOnScreen()
        {
            //Raycast between the two mouse position
            float distance = Vector2.Distance(lastMousePosition, Input.mousePosition);
            Vector3 direction = Input.mousePosition - lastMousePosition;
            Debug.DrawRay(lastMousePosition, direction, Color.yellow, 2);
        }

        public void WrongCut()
        {
            canCut = false;
            isCutting = false;
            cutCollider.canCut = false;
            StartCoroutine(NoCutCountdown());

            //VFX
            cannotCutEffect.CannotCutEffectAppear();

            //Trail effect
            trailEffect.StopAllCoroutines();
            trailEffect.SetTrailColor(trailEffect.cannotCutColor);
        }

        IEnumerator NoCutCountdown()
        {
            yield return new WaitForSeconds(noCutDuration);
            canCut = true;
            cutCollider.canCut = true;

            cannotCutEffect.CannotCutEffectDisappear();
            trailEffect.SetTrailColor(trailEffect.canCutColor);
        }
    }
}

