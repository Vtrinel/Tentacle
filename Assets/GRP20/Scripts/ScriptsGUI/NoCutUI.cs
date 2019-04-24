using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP20
{
    public class NoCutUI : MonoBehaviour
    {
        public Image image;
        private bool isCounting;

        public float targetTime;
        float currentTime;

        public void StartCountdown(float _targetDuration)
        {
            targetTime = _targetDuration;
            currentTime = 0;
            isCounting = true;
        }

        private void Update()
        {
            if (isCounting)
            {
                currentTime += Time.deltaTime;

                float amount = currentTime / targetTime;

                image.fillAmount = amount;

                if (amount == 1) isCounting = false;
            }
        }
    }
}

