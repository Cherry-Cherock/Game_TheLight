using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Rebind : MonoBehaviour
{
    [SerializeField] 
    private InputActionReference inputActionReference;
    
    [SerializeField] 
    private bool excludeMouse = true;
    [Range(0, 10)] 
    [SerializeField] 
    private int selectedBinding;
    [SerializeField] 
    private InputBinding.DisplayStringOptions displayStringOptions;
    [SerializeField] 
    private InputBinding inputBinding;
    private int bindingIndex;
    private string actionName;

    [Header("UI Field")] 
    [SerializeField] 
    private TMP_Text actionText;
    [SerializeField] 
    private Button rebindButton;
    [SerializeField] 
    private TMP_Text rebindText;
    [SerializeField] 
    private Button resetButton;

    private void OnEnable()
    {
        rebindButton.onClick.AddListener((() => DoRebind()));
        resetButton.onClick.AddListener((() => ResetBinding()));
        if (inputActionReference != null)
        {
            GetBindingInfo();
            UpdateUI();
        }

        InputManager.rebindComplete += UpdateUI;
    }

    private void OnDisable()
    {
        InputManager.rebindComplete -= UpdateUI;
    }

    private void OnValidate()
    {
        if (inputActionReference == null)
        {
            return;
        }
        GetBindingInfo();
        UpdateUI();
    }

    void GetBindingInfo()
    {
        if (inputActionReference.action != null)
        {
            actionName = inputActionReference.action.name;
        }

        if (inputActionReference.action.bindings.Count > selectedBinding)
        {
            inputBinding = inputActionReference.action.bindings[selectedBinding];
            bindingIndex = selectedBinding;
        }
    }

    void UpdateUI()
    {
        if (actionText != null)
        {
            actionText.text = actionName;
        }
        if (rebindText != null)
        {
            if (Application.isPlaying)
            {
                rebindText.text = InputManager.GetBindingName(actionName, bindingIndex);
            }
            else
            {
                rebindText.text = inputActionReference.action.GetBindingDisplayString(bindingIndex);
            }
        }
    }

    private void DoRebind()
    {
        InputManager.StartRebind(actionName,bindingIndex,rebindText);
    }

    private void ResetBinding()
    {
        
    }
}
