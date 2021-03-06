﻿using UnityEngine;
using System.Collections;

public class PlayerStandSMB : CustomSMB
{


    static GunHanddle gunHanddle = null;
    static float lastFireTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        if (tpsInput == null)
        {
            tpsInput = GameObject.FindGameObjectWithTag("Player").GetComponent<TPSInput>();
            Debug.Log("Get tpsinput in player Stand SMB");
        }
        if (gunHanddle == null)
        {
            gunHanddle = tpsInput.GetComponent<GunHanddle>();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var ti = animator.GetAnimatorTransitionInfo(layerIndex);
        if (ti.normalizedTime > 0)
        {
            return;
        }

        if (!tpsInput)
        {
            return;
        }

        if (gunHanddle.CurrentGun.gunState == GunState.Empty)
        {
            animator.SetBool("isAim", false);
            tpsInput.IsAim = false;
            tpsInput.CanFire = false;
            return;
        }

        if (!tpsInput.IsAim)
        {
            animator.SetBool("isAim", false);
            return;
        }
        if (tpsInput.IsFirePressed)
        {
            animator.SetBool("fired", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
