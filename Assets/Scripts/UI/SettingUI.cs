using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : BaseUI
{
    public override void Initialize()
    {
        AddPointerClickEvent("Button_Close", go => 
        {
            UIManager.Show<StartUI>();
        });
    }
    
    
}
