using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GRP20
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager gameManager;

        [Header("References")]
        public CutController cutController;
        public ManagerUI managerUI;
        public VfxManager vfxManager;
        public SplashManager splashManager;
        public TimeManager timeManager;
        public GameStateGUI gameStateGUI;
        public LevelManager level;
        public AudioManager audioManager;
        public NpcManager npcManager;

        [HideInInspector]
        public bool gameIsOver;
        [SerializeField] float timeBeforeEnd = 3;

        void Awake()
        {
            gameManager = this;
        }

        void Update()
        {

        }

        public void GameOver(bool _playerWin)
        {
            if (gameIsOver) return;

            if (_playerWin)
            {
                gameStateGUI.ShowWinText();
                level.StopAll();
                audioManager.WinSound();
                npcManager.controlTerror = false;
            }
            else
            {
                gameStateGUI.ShowLoseText();
                level.StopAll();
                audioManager.LoseSound();
                audioManager.StopMusic();
                npcManager.NPCEscape();
                //ReloadLevel();
            }

            audioManager.StopTimer();
            StartCoroutine(EndGame(_playerWin));
            gameIsOver = true;
        }

        void ReloadLevel()
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index);
        }

        IEnumerator EndGame(bool _win)
        {
            yield return new WaitForSeconds(timeBeforeEnd);
            Debug.Log("END OF THE GAME");
            if (_win)
            {
#if SIGWARE
                    LevelManager.Instance.Win();
#else
                SceneManager.LoadScene(0);
#endif
            }
            else
            {
#if SIGWARE
	            LevelManager.Instance.Lose();
#else
                SceneManager.LoadScene(0);
#endif
            }

        }
    }
}

