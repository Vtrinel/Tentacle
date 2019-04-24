using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class TentacleTarget : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            ITentacle tentacle = other.GetComponent<ITentacle>();

            if (tentacle != null)
            {
                if (tentacle.IsAlive())
                {
                    Debug.Log(" !!! GameOver !!! ");
                    GameManager.gameManager.GameOver(false);
                }
            }
        }
    }
}

