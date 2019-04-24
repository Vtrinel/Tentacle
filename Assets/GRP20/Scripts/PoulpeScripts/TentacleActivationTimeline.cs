using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class TentacleActivationTimeline : MonoBehaviour
    {
        [System.Serializable]
        public class TimelineEvent
        {
            public float timeEvent;
            public TentacleManager[] tentacleManagers;
        }

        public TimelineEvent[] timelineEvents;
        int timelineIndex;
        bool activateTentacles = true;

        void Start()
        {
            //StartCoroutine(StartTentacles());
        }

        void Update()
        {

        }

        public void StartTimeline()
        {
            for (int i = 0; i < timelineEvents.Length; i++)
            {
                StartCoroutine(StartTentacles(i));
            }
        }
        
        void StartMovement(int _timeEventIndex)
        {
            int length = timelineEvents[_timeEventIndex].tentacleManagers.Length;

            for (int i = 0; i < length; i++)
            {
                timelineEvents[_timeEventIndex].tentacleManagers[i].gameObject.SetActive(true);
                timelineEvents[_timeEventIndex].tentacleManagers[i].CanMove = true;
            }
        }
        
        public IEnumerator StartTentacles()
        {
            yield return new WaitForSeconds(GetTimeToWait());
            StartMovement(timelineIndex);
            timelineIndex++;

            if (timelineIndex > timelineEvents.Length-1)
            {
                Debug.Log("END");
                yield break;
            }
            
            StartCoroutine(StartTentacles());
        }

        public IEnumerator StartTentacles(int _index)
        {
            float time = timelineEvents[_index].timeEvent;
            yield return new WaitForSeconds(time);
            StartMovement(_index);
        }

        float GetTimeToWait()
        {
            float timeToWait;

            if (timelineIndex == 0)
            {
                timeToWait = timelineEvents[timelineIndex].timeEvent;
                return timeToWait;
            }

            timeToWait = timelineEvents[timelineIndex].timeEvent - timelineEvents[timelineIndex - 1].timeEvent;
            return timeToWait;
        }

    }
}

