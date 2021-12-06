using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  comboSMB: StateMachineBehaviour {

    public GameObject comboHighlight;
    public GameObject comboFailedHighlight;
    public GameObject comboSucceedHighlight;

    private bool comboFailed = false;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("attackPressed", false);
        comboFailed = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bool comboIsValid = animator.GetFloat("comboPressValid") > 0.5f;

        if (!comboFailed)
        {
            comboHighlight.SetActive(comboIsValid);
            if (animator.GetBool("attackPressed"))
            {
                animator.SetBool("attackPressed", false);
                if (comboIsValid)
                {
                    animator.SetTrigger("comboAttack");
                    comboSucceedHighlight.GetComponent<Animator>().SetTrigger("displayComboResult");
                }
                else
                {
                    comboFailed = true;
                    comboFailedHighlight.GetComponent<Animator>().SetTrigger("displayComboResult");
                }
            }
        }
    }

    // // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

    // }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
