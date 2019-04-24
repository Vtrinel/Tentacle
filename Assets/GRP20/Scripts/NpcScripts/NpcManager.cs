using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class NpcManager : MonoBehaviour
    {
        public List<NpcController> npcControllers = new List<NpcController>();
        public TentacleManager[] tentacleManagers;
        public Transform escapePosition;

        public float terrifyingDistance = 5;
        public Transform terrifyingPosition;
        [HideInInspector] public bool controlTerror = true;

        private void Start()
        {
            GetAllTentacles();

            for (int i = 0; i < npcControllers.Count; i++)
            {
                npcControllers[i].escapePosition = escapePosition;
            }
        }

        private void Update()
        {
            CheckAllPoints();
        }

        void GetAllTentacles()
        {
            tentacleManagers = GameManager.gameManager.level.tentacleManagers;
        }

        void CheckAllPoints()
        {
            if (!controlTerror) return;

            bool terror = false;

            for (int i = 0; i < tentacleManagers.Length; i++)
            {
                float tentaclePosX = tentacleManagers[i].tentacle.tentaclePoints[tentacleManagers[i].tentacle.tentaclePoints.Count - 1].transform.position.x;
                Vector3 tentaclePos = new Vector3(tentaclePosX, 0, 0);
                Vector3 terrorPos = new Vector3(terrifyingPosition.position.x, 0, 0);

                float distance = Vector3.Distance(terrorPos, tentaclePos);

                if(distance < terrifyingDistance)
                {
                    Debug.Log("TERROR ON !!!");
                    terror = true;
                    break;
                }
            }

            NpcTerror(terror);
        }

        void NpcTerror(bool _terror)
        {
            for (int i = 0; i < npcControllers.Count; i++)
            {
                npcControllers[i].Terrified(_terror);
            }
        }

        public void NPCEscape()
        {
            controlTerror = false;

            for (int i = 0; i < npcControllers.Count; i++)
            {
                npcControllers[i].Terrified(false);
                npcControllers[i].Escape();
            }
        }
    }
}

