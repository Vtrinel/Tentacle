using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP20
{
    public class LevelTimer : MonoBehaviour
    {

        public float levelDuration = 30;
        float duration;
        public bool startCount;

        [Range(0.0f,1.0f)]
        [SerializeField] float timePercentAlert = 0.25f;


        [Header("GUI")]
        public Image bar;
        public Animator iconAnim;
        public RectTransform niddle;
        public float minRot = -360, maxRot = 0;

        public void StartLevelTimer()
        {
            duration = levelDuration;
            startCount = true;
        }

        void Update()
        {
            if (GameManager.gameManager.gameIsOver) return;
            if (!startCount) return;

            duration -= Time.deltaTime;
            float percent = duration / levelDuration;
            bar.fillAmount = percent;
            float rot = Mathf.Lerp(minRot, maxRot, percent);
            niddle.eulerAngles = new Vector3(niddle.eulerAngles.x, niddle.eulerAngles.y, rot);
            

            if(percent <= timePercentAlert)
            {
                GameManager.gameManager.audioManager.PlayTimer();
                iconAnim.SetBool("isScaling", true);
            }

            if (duration <= 0)
            {
                GameManager.gameManager.GameOver(true);
                iconAnim.SetBool("isScaling", false);
            }

        }
    }
}

