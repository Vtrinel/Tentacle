using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GRP20
{
    public class Obstacle : MonoBehaviour, ICuttable
    {
        public UnityEvent cutEvent;
        private CutController cutController;
        public Collider obstacleCollider;

        public ObstacleMovement obstacleMovement;

        void Start()
        {
            cutController = GameManager.gameManager.cutController;
        }

        public void Cut()
        {
            Debug.Log("WRONG CUT");
            cutController.WrongCut();
            GameManager.gameManager.managerUI.noCutUI.StartCountdown(cutController.noCutDuration);
            GameManager.gameManager.timeManager.StartHitSlowMotion();
            GameManager.gameManager.vfxManager.CutImpact(transform.position);
            GameManager.gameManager.audioManager.BoatImpact();
            obstacleCollider.enabled = false;
            cutEvent.Invoke();
        }

        public void StartMove()
        {
            if (obstacleMovement == null) return;

            obstacleMovement.canMove = true;
        }

        public void StopMove()
        {
            if (obstacleMovement == null) return;

            obstacleMovement.canMove = false;
        }
        
    }
}

