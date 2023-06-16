using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInfoUI : BaseUI
{
    private TMP_Text playerHP;
    private TMP_Text playerAttack;
    private TMP_Text playerSpeed;
    private TMP_Text playerPDefense;
    private TMP_Text playerMDefense;
    
    public override void Initialize()
    {
        playerHP = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "playerHP");
        playerHP.text = ProFileUI.healthMax.ToString();
        
        playerAttack = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "playerAttack");
        playerAttack.text = PlayerController.curDamage.ToString();
        
        playerSpeed = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "playerSpeed");
        playerSpeed.text = PlayerController.moveSpeed.ToString();
        
        playerPDefense = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "playerPDefense");
        playerPDefense.text = PlayerController.curPDefense.ToString();
        
        playerMDefense = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "playerMDefense");
        playerMDefense.text = PlayerController.curMDefense.ToString();
        
        AddPointerClickEvent("Button_Close", go =>
        {
            transform.gameObject.SetActive(false);
            GameManager.HandleGameStart();
        });
    }
    
    
    public override void Show()
    { 
        base.Show();
        UpdatePlayerData();
    }

    void UpdatePlayerData()
    {
        playerAttack.text = PlayerController.curDamage.ToString();
    }
}
