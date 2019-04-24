using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

namespace GRP20
{
    public class TimelineEvent : MonoBehaviour
    {
        public PlayableDirector timeline;
        public UnityEvent TimelineStop;

        void Start()
        {

        }


        void Update()
        {
            if(timeline.time == timeline.duration)
            {
                Stop();
            }
        }

        void Stop()
        {
            TimelineStop.Invoke();
            //GameManager.gameManager.level.StartLevel();
            this.enabled = false;
        }
    }

}
