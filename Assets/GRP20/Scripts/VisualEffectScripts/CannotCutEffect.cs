using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannotCutEffect : MonoBehaviour {

    public Animator animator;

    public void CannotCutEffectAppear()
    {
        animator.SetTrigger("appear");
    }

    public void CannotCutEffectDisappear()
    {
        animator.SetTrigger("disappear");
    }
}
