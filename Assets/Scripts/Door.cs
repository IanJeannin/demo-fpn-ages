﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObjects
{
    private Animator animator;
    private bool isOpen = false;
    private int shouldOpenAnimParameter=Animator.StringToHash("shouldOpen");
    /// <summary>
    /// Using a constructor here to initialize displayText in the editor
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    public override void InteractWith()
    {
        if(!isOpen)
        {
            base.InteractWith();
            animator.SetBool(shouldOpenAnimParameter, true);
            displayText = string.Empty;
            isOpen = true;
        }
    }
}