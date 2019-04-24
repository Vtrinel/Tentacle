using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource[] tentaclesImpactsSFX;
        public AudioSource winSound, loseSound, innocentImpact, splash, timer,music;

        public void PlayTentacleImpact()
        {
            int ran = Random.Range(0, tentaclesImpactsSFX.Length);
            tentaclesImpactsSFX[ran].Play();
        }

        public void WinSound()
        {
            winSound.Play();
        }

        public void LoseSound()
        {
            loseSound.Play();
        }

        public void BoatImpact()
        {
            innocentImpact.Play();
            splash.Play();
        }

        public void PlayTimer()
        {
            if (timer.isPlaying) return;

            timer.Play();
        }

        public void StopTimer()
        {
            timer.Stop();
        }

        public void StopMusic()
        {
            music.Stop();
        }
    }
}

