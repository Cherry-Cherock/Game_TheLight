using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KeyBindUI : BaseUI
{
  
    
    //----------按钮---------
    Button Up_keyboard;
    Button Up_Gamepad;
    Button Down_keyboard;
    Button Down_Gamepad;
    Button Left_keyboard;
    Button Left_Gamepad;
    Button Right_keyboard;
    Button Right_Gamepad;
    Button Jump_keyboard;
    Button Jump_Gamepad;
    Button ResetBtn;
    //----------文本---------
    TMP_Text UpKey1;
    TMP_Text UpKey2;
    TMP_Text DownKey1;
    TMP_Text DownKey2;
    TMP_Text LeftKey1;
    TMP_Text LeftKey2;
    TMP_Text RightKey1;
    TMP_Text RightKey2;
    TMP_Text JumpKey1;
    TMP_Text JumpKey2;
    public override void Initialize()
    {
        //----------------------------------------------初始化按钮---------------------------------------------------
        Up_keyboard = UnityHelper.GetTheChildNodeComponetScripts<Button>(gameObject, "Up_keyboard");
        Up_Gamepad = UnityHelper.GetTheChildNodeComponetScripts<Button>(gameObject, "Up_Gamepad");
        Down_keyboard = UnityHelper.GetTheChildNodeComponetScripts<Button>(gameObject, "Down_keyboard");
        Down_Gamepad = UnityHelper.GetTheChildNodeComponetScripts<Button>(gameObject, "Down_Gamepad");
        Left_keyboard = UnityHelper.GetTheChildNodeComponetScripts<Button>(gameObject, "Left_keyboard");
        Left_Gamepad = UnityHelper.GetTheChildNodeComponetScripts<Button>(gameObject, "Left_Gamepad");
        Right_keyboard = UnityHelper.GetTheChildNodeComponetScripts<Button>(gameObject, "Right_keyboard");
        Right_Gamepad = UnityHelper.GetTheChildNodeComponetScripts<Button>(gameObject, "Right_Gamepad");
        Jump_keyboard = UnityHelper.GetTheChildNodeComponetScripts<Button>(gameObject, "Jump_keyboard");
        Jump_Gamepad = UnityHelper.GetTheChildNodeComponetScripts<Button>(gameObject, "Jump_Gamepad");
        ResetBtn = UnityHelper.GetTheChildNodeComponetScripts<Button>(gameObject, "ResetBtn");
        //----------------------------------------------初始化文本---------------------------------------------------
        UpKey1 = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "UpKey1");
        UpKey2 = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "UpKey2");
        DownKey1 = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "DownKey1");
        DownKey2 = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "DownKey2");
        LeftKey1 = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "LeftKey1");
        LeftKey2 = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "LeftKey2");
        RightKey1 = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "RightKey1");
        RightKey2 = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "RightKey2");
        JumpKey1 = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "JumpKey1");
        JumpKey2 = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "JumpKey2");
        
        
        //关闭按钮
        AddPointerClickEvent("Button_Close", go =>
        {
            Debug.Log(UpKey1.text);
            
        });
    }
    
    public override void Show()
    { 
        base.Show();
    }

  

    void Close()
    {
        UIManager.ShowLast();
    }
}
