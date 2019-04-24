using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP20
{
    public class SploushEffect : MonoBehaviour
    {
        public Image sploushImage;

        public AnimationCurve scaleCurve;
        public AnimationCurve alphaCurve;

        [SerializeField] float animDuration;
        float currentDuration;

        
        public bool isCounting;

        private void Awake()
        {
            Color newColor = new Color(sploushImage.color.r, sploushImage.color.g, sploushImage.color.b, 0);
            sploushImage.color = newColor;
        }

        private void Update()
        {
            Timer();
        }

        public void StartTimer()
        {
            isCounting = true;
        }

        void Timer()
        {
            if (!isCounting) return;

            currentDuration += Time.deltaTime;

            float percent = currentDuration / animDuration;

            Animation(percent);

            if (currentDuration >= animDuration)
            {
                isCounting = false;
                currentDuration = 0;
                //END TIMER
            }
        }

        void Animation(float _animTime)
        {
            //Scale animation
            float scale = scaleCurve.Evaluate(_animTime);
            transform.localScale = new Vector3(scale, scale, scale);

            //Alpha animation
            float alpha = alphaCurve.Evaluate(_animTime);
            Color newColor = new Color(sploushImage.color.r, sploushImage.color.g, sploushImage.color.b, alpha);
            sploushImage.color = newColor;
        }
    }
}

