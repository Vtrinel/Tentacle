using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class CutCollider : MonoBehaviour
    {
        public bool canCut = false;
        public CutTrailEffect trailEffect;

        private void OnTriggerEnter(Collider other)
        {
            if (!canCut) return;

            ICuttable cuttable = other.GetComponent<ICuttable>();

            if (cuttable != null)
            {
                trailEffect.SetCutColor();
                cuttable.Cut();
                Debug.Log("TOUCHED WITH CutCollider");
            }
        }
    }
}

