using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static PlayerControl inputActions;
    public static event Action rebindComplete;
    public static event Action rebindCanceled;
    public static event Action<InputAction, int> rebindStarted;
    private void Awake()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControl();
        }
        
    }

    public static void StartRebind(string actionName, int bindingIndex, TMP_Text statusText)
    {
        Debug.Log(statusText);
        InputAction action = inputActions.asset.FindAction(actionName);
        if (action == null || action.bindings.Count <= bindingIndex)
        {
            Debug.Log("Can't find action or binding");
            return;
        }

        if (action.bindings[bindingIndex].isComposite)
        {
            var firstPartIndex = bindingIndex + 1;
            if (firstPartIndex < action.bindings.Count && action.bindings[firstPartIndex].isPartOfComposite)
            {
                DoRebind(action, firstPartIndex, statusText, true);
                
            }
        }
        else
        {
            DoRebind(action,bindingIndex,statusText,false);
            
        }
    }

    private static void DoRebind(InputAction actionToRebind, int bindingIndex, TMP_Text statusText, bool allCompositeParts)
    {
        if (actionToRebind == null || bindingIndex < 0) return;
        
        statusText.text = "Listening...";
        
        actionToRebind.Disable();
        var rebind = actionToRebind.PerformInteractiveRebinding(bindingIndex);
        rebind.OnComplete(operation =>
        {
            actionToRebind.Enable();
            operation.Dispose();
            if (allCompositeParts)
            {
                var nextBindingIndex = bindingIndex + 1;
                if (nextBindingIndex < actionToRebind.bindings.Count && actionToRebind.bindings[nextBindingIndex].isPartOfComposite)
                {
                    DoRebind(actionToRebind,nextBindingIndex,statusText,allCompositeParts);
                }
            }
            rebindComplete?.Invoke();
        });
        rebind.OnCancel(operation =>
        {
            actionToRebind.Enable();
            operation.Dispose();
            rebindCanceled?.Invoke();
        });
        rebindStarted?.Invoke(actionToRebind,bindingIndex);
        rebind.Start();
    }

    public static string GetBindingName(string actionName, int bindingIndex)
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControl();
        }

        InputAction action = inputActions.asset.FindAction(actionName);
        return action.GetBindingDisplayString(bindingIndex);
    }
}
