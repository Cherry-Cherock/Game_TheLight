using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : BaseUI
{
    
    public override void Initialize()
    {
        AddPointerClickEvent("Button_Continue", go =>
        { 
            transform.gameObject.SetActive(false);
            GameManager.HandleGameStart();
        });
    }
}
