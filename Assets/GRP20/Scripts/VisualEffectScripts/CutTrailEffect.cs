using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class CutTrailEffect : MonoBehaviour
    {

        public TrailRenderer trail;
        public Color canCutColor;
        public Color cannotCutColor;
        public Color cutColor;
        public float cutColorDuration = 0.75f;


        void Start()
        {

        }

        void Update()
        {

        }

        public void SetTrailPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetTrailColor(Color _trailColor)
        {
            trail.material.color = _trailColor;
        }

        public void SetCutColor()
        {
            StopAllCoroutines();
            StartCoroutine(CutColor());
        }

        IEnumerator CutColor()
        {
            SetTrailColor(cutColor);
            yield return new WaitForSeconds(cutColorDuration);
            SetTrailColor(canCutColor);
        }
    }
}

