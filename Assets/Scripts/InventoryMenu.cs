﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;
    private bool isVisible => canvasGroup.alpha > 0;

    public static InventoryMenu Instance
    {
        get
        {
            if (instance==null)
            {
                throw new System.Exception("There is currently no InventoryMenu instance but you are trying to access it. Make the InventoryMenu script is applied to a game object in your scene.");
            }
            return instance;
        }
        private set { instance = value; }
    }

    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        rigidbodyFirstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 
    }

    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rigidbodyFirstPersonController.enabled = true;
        
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("ShowInventory"))
        {
            if (isVisible)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new System.Exception("There is already one instance of InventoryMenu and there can only be one.");
        }
        rigidbodyFirstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        HideMenu();
    }
}
