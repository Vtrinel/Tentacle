using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class ObstacleManager : MonoBehaviour
    {
        public Obstacle[] obstacles;

        private void Start()
        {
            ObstacleStop();
            ObstacleGameobjectActive(false);
            ObstacleColliderEnabled(false);
        }

        public void ObstacleStart()
        {
            for (int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i].StartMove();
            }
        }

        public void ObstacleStop()
        {
            for (int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i].StopMove();
            }
        }

        public void ObstacleColliderEnabled(bool _enable)
        {
            for (int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i].obstacleCollider.enabled = _enable;
            }
        }

        public void ObstacleGameobjectActive(bool _active)
        {
            for (int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i].gameObject.SetActive(_active);
            }
        }
    }
}

