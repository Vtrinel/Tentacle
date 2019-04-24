using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class CamShake : MonoBehaviour
    {
        public static CamShake camShake;

        public Transform camTransform;
        Vector3 camIniPosition;

        [Header("Shake amplitude")]
        public AnimationCurve shakeAmplitudeEvolution;
        public float baseAmplitude = 1;
        float amplitude = 1;

        [Header("Shake duration")]
        public float baseDuration = 1;
        float duration = 1;
        float currentDuration = 0;

        bool isShaking;

        private void Awake()
        {
            camShake = this;

            if (camTransform == null)
            {
                camTransform = Camera.main.transform;
            }
        }

        void Start()
        {
            camIniPosition = camTransform.position;
        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                StartShakeCam();
            }

            Shaking();
        }

        public void StartShakeCam()
        {
            amplitude = baseAmplitude;
            duration = baseDuration;
            currentDuration = 0;
            isShaking = true;
        }

        public void StartShakeCam(float _amplitude, float _duration)
        {
            amplitude = _amplitude;
            duration = _duration;
            currentDuration = 0;
            isShaking = true;
        }

        void Shaking()
        {
            if (!isShaking) return;

            //TIMER
            currentDuration += Time.deltaTime;

            float shakePercent = currentDuration / duration;

            //AMPLITUDE
            float curveAmplitude = shakeAmplitudeEvolution.Evaluate(shakePercent);
            float ampli = amplitude * curveAmplitude;

            //SHAKE
            Vector3 newPos = Random.insideUnitCircle * ampli;
            camTransform.position = camIniPosition + newPos;

            if(currentDuration >= duration)
            {
                isShaking = false;
            }
        }
    }
}

