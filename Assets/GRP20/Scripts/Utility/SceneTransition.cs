using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace GRP20
{
    public class SceneTransition : MonoBehaviour
    {
        public void LoadScene(string _sceneName)
        {
            SceneManager.LoadScene(_sceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

