using UnityEngine;
using System.Collections;

public class rawimageState_closed : StateMachineBehaviour {

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.gameObject.SetActive(false);
    }

}
