﻿using UnityEngine;
using System.Collections;
using System;

public class PlayerAttr : MonoBehaviour
{

    public Transform targetAttach;

    public Animator animator;

    /// <summary>
    /// 
    /// </summary>
    public void OnEnable()
    {
        LeanTween.addListener((int)Events.ENEMYCLEARED, OnGameFinish);
    }

    private void OnGameFinish(LTEvent obj)
    {
        Invoke("DelayCall", 1f);
    }

    public void DelayCall()
    {
        if (animator)
        {
            animator.SetTrigger("success");
        }
    }


    public void OnDisable()
    {
        LeanTween.addListener((int)Events.GAMEFINISH, OnGameFinish);
    }



    // Use this for initialization
    void Start()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
