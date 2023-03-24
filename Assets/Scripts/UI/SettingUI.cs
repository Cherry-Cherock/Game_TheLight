using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : BaseUI
{
    //----难度-----
    Toggle togEasy;
    Toggle togMedium;
    Toggle togHard;
    int difficultyIndex = 0;
    //----分辨率----
    Toggle togR0;
    Toggle togR1;
    Toggle togR2;
    int resolutionIndex = 0;
    
    public override void Initialize()
    {
        //------------------------------------难度-----------------------------------------------
        togEasy = UnityHelper.GetTheChildNodeComponetScripts<Toggle>(gameObject, "ToggleEasy");
        togEasy.onValueChanged.AddListener((b) => { if (b) difficultyIndex = 0; TogggleControl(togEasy); });
        
        togMedium = UnityHelper.GetTheChildNodeComponetScripts<Toggle>(gameObject, "ToggleMedium");
        togMedium.onValueChanged.AddListener((b) => { if (b) difficultyIndex = 1; TogggleControl(togMedium); });
        
        togHard = UnityHelper.GetTheChildNodeComponetScripts<Toggle>(gameObject, "ToggleHard");
        togHard.onValueChanged.AddListener((b) => { if (b) difficultyIndex = 2; TogggleControl(togHard); });
        //-------------------------------------分辨率----------------------------------------------
        togR0 = UnityHelper.GetTheChildNodeComponetScripts<Toggle>(gameObject, "Toggle0");
        togR0.onValueChanged.AddListener((b) => { if (b) resolutionIndex = 0; TogggleControl(togR0); });
        
        togR1 = UnityHelper.GetTheChildNodeComponetScripts<Toggle>(gameObject, "Toggle1");
        togR1.onValueChanged.AddListener((b) => { if (b) resolutionIndex = 1; TogggleControl(togR1); });
        
        togR2 = UnityHelper.GetTheChildNodeComponetScripts<Toggle>(gameObject, "Toggle2");
        togR2.onValueChanged.AddListener((b) => { if (b) resolutionIndex = 2; TogggleControl(togR2); });
        
        AddPointerClickEvent("Button_Close", go =>
        {
            Confirm();
            Close();
        });
        
        
    }
    public override void Show()
    { 
        base.Show();
        InitPanel();
    }
    
    void InitPanel()
    {
        togEasy.isOn = GameSetting.DifficultyIndex == 0;
        togMedium.isOn = GameSetting.DifficultyIndex == 1;
        togHard.isOn = GameSetting.DifficultyIndex == 2;
        togR0.isOn = GameSetting.ResolutionIndex == 0;
        togR1.isOn = GameSetting.ResolutionIndex == 1;
        togR2.isOn = GameSetting.ResolutionIndex == 2;
    }

    void Confirm()
    {
        GameSetting.DifficultyIndex = difficultyIndex;
        
        GameSetting.ResolutionIndex = resolutionIndex;
        Debug.Log("ResolutionIndex: "+ GameSetting.ResolutionIndex);
        //Check not null
        if(GameSetting.DifficultyIndex < 0)
        {
            Debug.Log("难度小于0！"+ GameSetting.DifficultyIndex);
        }

        if (GameSetting.ResolutionIndex < 0)
        {
            Debug.Log("分辨率小于0！" + GameSetting.ResolutionIndex);
        }
        GameSetting.SetSetting();
    }
    
    void Close()
    {
        // InitPanel();
        Debug.Log("-----完成设置------"+"\n"+
                  "FullScreen: "+ GameSetting.FullScreen+"\n"+
                  "ResolutionIndex: "+ GameSetting.ResolutionIndex+"\n"+
                  "DifficityIndex: "+ GameSetting.DifficultyIndex+"\n"+
                  "LanguageCN: "+ GameSetting.LanguageCN
            );
        UIManager.ShowLast();
    }
    
    
    
    
    
    /// <summary>
    /// 用于控制toggle组件的TargetGraogic 和 Graphic节点的打开跟关闭,且俩个节点都是独立的
    /// </summary>
    void TogggleControl(Toggle _toggle)
    {
        if (_toggle.transition == Selectable.Transition.ColorTint)
        {
            bool _isOn = _toggle.isOn;
            _toggle.targetGraphic?.gameObject.SetActive(!_isOn);
            _toggle.graphic?.gameObject.SetActive(_isOn);
        }
    }
    
    
}
