using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class SplashManager : MonoBehaviour
    {

        public List<SploushEffect> sploushEffects;
        public List<SploushEffect> availableEffect = new List<SploushEffect>();
        public List<SploushEffect> onScreenEffect = new List<SploushEffect>();

        private void Start()
        {
            availableEffect = sploushEffects;
        }

        private void Update()
        {
           
        }

        public void StartSplash()
        {
            CheckAvailableEffect();
            SploushEffect sploush = SelectAvailableEffect();
            if(sploush != null) sploush.StartTimer();
        }

        public SploushEffect SelectAvailableEffect()
        {
            if (availableEffect.Count < 1) return null;

            //select random effect
            int ran = Random.Range(0, availableEffect.Count-1);
            SploushEffect selected = availableEffect[ran];

            availableEffect.Remove(selected); //remove from available list
            onScreenEffect.Add(selected); //add to OnScreen list

            return selected;
        }

        public void CheckAvailableEffect()
        {
            if (onScreenEffect.Count < 1) return;

            for (int i = 0; i < onScreenEffect.Count; i++)
            {
                if (!onScreenEffect[i].isCounting)
                {
                    availableEffect.Add(onScreenEffect[i]);
                    onScreenEffect.Remove(onScreenEffect[i]);
                }
            }

            return;
            foreach (SploushEffect effect in onScreenEffect)
            {
                if (!effect.isCounting)
                {
                    availableEffect.Add(effect);
                    onScreenEffect.Remove(effect);
                }
            }
        }
    }
}

