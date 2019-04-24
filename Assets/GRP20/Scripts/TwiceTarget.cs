using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace GRP20
{
    public class TwiceTarget : MonoBehaviour, ICuttable
    {
        public UnityEvent cutEvent;

        public void Cut()
        {
            GameManager.gameManager.audioManager.StopMusic();
            GameManager.gameManager.vfxManager.CutImpact(transform.position);
            cutEvent.Invoke();
        }

        void Start()
        {

        }


        void Update()
        {

        }
    }
}

