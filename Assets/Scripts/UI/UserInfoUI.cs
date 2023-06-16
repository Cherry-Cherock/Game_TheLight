using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInfoUI : BaseUI
{
    private TMP_Text playerAttack;
    private TMP_Text playerDefense;
    public override void Initialize()
    {
        
        playerAttack = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "playerAttack");
        playerAttack.text = PlayerController.curDamage.ToString();
        
        playerDefense = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "playerDefense");
        playerDefense.text = PlayerController.curDamage.ToString();
        
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
