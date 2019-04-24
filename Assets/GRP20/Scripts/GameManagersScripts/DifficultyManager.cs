using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class DifficultyManager : MonoBehaviour
    {

        public LevelManager easyLevel, normalLevel, hardLevel;
        [Range(0,2)]
        public int difficultyLevel; //0 = esasy, 1 = normal, 2 = hard
        LevelManager selectedLevel;

        public void SelectLevel()
        {
            switch (difficultyLevel)
            {
                case 0:
                    selectedLevel = easyLevel;
                    break;
                case 1:
                    selectedLevel = normalLevel;
                    break;
                case 2:
                    selectedLevel = hardLevel;
                    break;
                default:
                    selectedLevel = normalLevel;
                    break;
            }

            selectedLevel.StartLevel();
        }
    }
}

