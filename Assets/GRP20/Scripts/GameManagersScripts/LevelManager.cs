using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GRP20
{
    public class LevelManager : MonoBehaviour
    {
        public TentacleManager[] tentacleManagers;
        public TentacleActivationTimeline tentacleActivationTimeline;
        public LevelTimer levelTimer;

        private void Start()
        {
            DisableAll();
        }

        public void StartLevel()
        {
            //tentacleActivationTimeline.StartCoroutine(tentacleActivationTimeline.StartTentacles());
            tentacleActivationTimeline.StartTimeline();
            levelTimer.StartLevelTimer();
        }

        void Update()
        {
            CheckDeadTentacle();
        }

        void CheckDeadTentacle()
        {
            int count = 0;

            for (int i = 0; i < tentacleManagers.Length; i++)
            {
                if (tentacleManagers[i].isDead)
                {
                    count++;
                }
            }

            if(count == tentacleManagers.Length)
            {
                AllTentaclesDead();
            }
        }

        void DisableAll()
        {
            for (int i = 0; i < tentacleManagers.Length; i++)
            {
                tentacleManagers[i].gameObject.SetActive(false);
            }
        }

        void AllTentaclesDead()
        {
            GameManager.gameManager.GameOver(true);
        }

        public void StopAll()
        {
            for (int i = 0; i < tentacleManagers.Length; i++)
            {
                tentacleManagers[i].tentacleMovement.StopMovement();
            }
        }
    }
}

