using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class TimeManager : MonoBehaviour
    {

        [Header("Pause Values")]
        private bool timePaused;
        float previousTimeScale = 1;
        bool wasInSlowMotion = false;


        [Header("Hit Slow Motion Values")]
        public AnimationCurve timeRecoverEvolution;
        public float timeRecoverDuration = 1.25f;
        [Range(0.01f, 1.0f)]
        public float slowMotionScale = 0.4f;

        float currentRecoverDuration = 0.0f;

        [Header("FreezeFrame")]
        [Tooltip("1 frame =  0,0165 seconds")]
        public float freezeFrameDuration = 0.036f;
        bool gameIsFrozen;

        bool inSlowMotion = false;

        public bool TimePaused
        {
            get
            {
                return timePaused;
            }
            set
            {
                if (value == true)
                {
                    if (inSlowMotion)
                    {
                        wasInSlowMotion = true;
                        inSlowMotion = false;
                    }

                    previousTimeScale = Time.timeScale;
                    Time.timeScale = 0;
                }
                else
                {
                    if (wasInSlowMotion)
                    {
                        inSlowMotion = true;
                    }

                    Time.timeScale = previousTimeScale;
                }

                timePaused = value;
            }
        }

        void Start()
        {
            inSlowMotion = false;
        }

        void Update()
        {
            SlowMotion();
        }

        public void StartHitSlowMotion()
        {
            inSlowMotion = true;
        }

        void SlowMotion()
        {
            if (!inSlowMotion) return;

            currentRecoverDuration += Time.unscaledDeltaTime;

            float percent = currentRecoverDuration / timeRecoverDuration;
            float curveEval = timeRecoverEvolution.Evaluate(percent);
            float targetTimeScale = Mathf.Lerp(slowMotionScale, 1, curveEval);
            Time.timeScale = targetTimeScale;

            if (currentRecoverDuration >= timeRecoverDuration)
            {
                currentRecoverDuration = 0.0f;
                inSlowMotion = false;
                Time.timeScale = 1;
            }
        }


        void Pause()
        {
            TimePaused = true;
        }


        void Resume()
        {
            TimePaused = false;
        }

        public void StartFreezeFrame()
        {
            StartCoroutine(FreezeFrame());
        }

        public IEnumerator FreezeFrame()
        {
            Time.timeScale = 0;
            gameIsFrozen = true;
            yield return new WaitForSecondsRealtime(freezeFrameDuration);
            gameIsFrozen = false;
            Time.timeScale = 1;
        }

    }
}

