using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GRP20
{
    public class NpcController : MonoBehaviour
    {

        public enum IdleAnim
        {
            Boxing,
            SittingIdle,
            SittingTalking,
            TreadingWater,
            OldManIdle,
            Terrified,
            Swimming01,
            Swimming02
        }

        public enum RunAwayAnim
        {
            Running01,
            Running02,
            Running03,
            GoofyRunning
        }

        [Header("NPC's animations")]
        public Animator animator;
        public IdleAnim idleAnim;
        public RunAwayAnim runAwayAnim;

        [Header("NPC's movement")]
        public NavMeshAgent navMeshAgent;
        public Transform escapePosition;
        [SerializeField] bool startTerrified = true;

        // Use this for initialization
        public virtual void Start()
        {
            SetIdleAnim();
            SetRunAnim();
            Terrified(startTerrified);
        }

        // Update is called once per frame
        public virtual void Update()
        {

        }

        public void SetIdleAnim()
        {
            switch (idleAnim)
            {
                case IdleAnim.Boxing:
                    animator.SetFloat("IdleIndex", 6);
                    break;
                case IdleAnim.SittingIdle:
                    animator.SetFloat("IdleIndex", 1);
                    break;
                case IdleAnim.SittingTalking:
                    animator.SetFloat("IdleIndex", 2);
                    break;
                case IdleAnim.TreadingWater:
                    animator.SetFloat("IdleIndex", 5);
                    break;
                case IdleAnim.OldManIdle:
                    animator.SetFloat("IdleIndex", 0);
                    break;
                case IdleAnim.Terrified:
                    animator.SetFloat("IdleIndex", 7);
                    break;
                case IdleAnim.Swimming01:
                    animator.SetFloat("IdleIndex", 3);
                    break;
                case IdleAnim.Swimming02:
                    animator.SetFloat("IdleIndex", 4);
                    break;
                default:
                    animator.SetFloat("IdleIndex", 1);
                    break;
            }
        }

        public void SetRunAnim()
        {
            switch (runAwayAnim)
            {
                case RunAwayAnim.Running01:
                    animator.SetFloat("RunIndex", 0);
                    break;
                case RunAwayAnim.Running02:
                    animator.SetFloat("RunIndex", 1);
                    break;
                case RunAwayAnim.Running03:
                    animator.SetFloat("RunIndex", 2);
                    break;
                case RunAwayAnim.GoofyRunning:
                    animator.SetFloat("RunIndex", 3);
                    break;
                default:
                    animator.SetFloat("RunIndex", 0);
                    break;
            }
        }

        public void Escape()
        {
            animator.SetFloat("StateIndex", 1);
            navMeshAgent.SetDestination(escapePosition.position);
        }

        public void Terrified(bool _isTerrified)
        {
            animator.SetBool("IsTerrified", _isTerrified);
        }
    }
}

