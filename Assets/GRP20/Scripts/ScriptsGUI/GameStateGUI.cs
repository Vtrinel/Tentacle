using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP20
{
    public class GameStateGUI : MonoBehaviour
    {
        public Animator anim;

        public void ShowWinText()
        {
            anim.SetTrigger("win");
        }

        public void ShowLoseText()
        {
            anim.SetTrigger("lose");
        }
    }
}

