using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : BaseUI
{
    Button SettingBtn;
    public override void Initialize()
    {
        AddPointerClickEvent("Button_Setting", go => 
        {
            UIManager.Show<SettingUI>();
        });
        
        AddPointerClickEvent("Button_Quit", go =>
        {
           
            Application.Quit();
        });
    }
}
