﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
    #region SerializeFields
    [SerializeField]
    private GameObject inventoryMenuItemTogglePrefab;
    [Tooltip("Content of the scrollview for the list of inventory items.")]
    [SerializeField]
    private Transform inventoryListContentArea;
    [Tooltip("Place in the UI for displaying the name of the selected inventory item.")]
    [SerializeField]
    private Text itemLabelText;
    [Tooltip("Place in the UI for displaying info about the selected inventory item.")]
    [SerializeField]
    private Text descriptionAreaText;
    #endregion

    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;
    private bool isVisible => canvasGroup.alpha > 0;
    private AudioSource audioSource;

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

    public void ExitMenuButtonClicked()
    {
        HideMenu();
    }

    /// <summary>
    /// Instantiates a new InventoryMenuItemToggle prefab and adds it to the menu.
    /// </summary>
    /// <param name="inventoryObjectToAdd"></param>
    public void AddItemToMenu(InventoryObject inventoryObjectToAdd)
    {
        GameObject clone = Instantiate(inventoryMenuItemTogglePrefab, inventoryListContentArea);
        InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();
        toggle.AssociatedInventoryObject = inventoryObjectToAdd;
    }

    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        rigidbodyFirstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        audioSource.Play();
    }

    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rigidbodyFirstPersonController.enabled = true;
        audioSource.Play();
    }

    /// <summary>
    /// Event handler for InventoryMenuItemToggleSelected.
    /// </summary>
    private void OnInventoryMenuItemSelected(InventoryObject inventoryObjectThatWasSelected)
    {
        itemLabelText.text = inventoryObjectThatWasSelected.ObjectName;
        descriptionAreaText.text = inventoryObjectThatWasSelected.Description;
    }

    private void OnEnable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected += OnInventoryMenuItemSelected;
    }

    private void OnDisable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected -= OnInventoryMenuItemSelected;
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
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.volume = 0;
        HideMenu();
        audioSource.volume = 1;
        StartCoroutine(WaitForAudioClip());
        Debug.Log("We're not done waiting");
    }

    private IEnumerator WaitForAudioClip()
    {
        float originalVolume = audioSource.volume;
        audioSource.volume = 0;
        Debug.Log("Start Waiting");
        yield return new WaitForSeconds(audioSource.clip.length);
        Debug.Log("StopWaiting");
        audioSource.volume = originalVolume;
    }
}
