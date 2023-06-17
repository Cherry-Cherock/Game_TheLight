using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using Player.InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserInfoUI : BaseUI
{
    private TMP_Text playerHP;
    private TMP_Text playerAttack;
    private TMP_Text playerSpeed;
    private TMP_Text playerPDefense;
    private TMP_Text playerMDefense;

    private List<Image> buffs = new List<Image>();
    private Image buff1;
    private Image buff2;
    private Image buff3;
    private Image buff4;
    
    public override void Initialize()
    {
        //---------------------------------角色状态数据-----------------------------------------------------
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
        
        //---------------------------------角色装备的buff----------------------------------------------------
        buff1 = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "BUFF1");
        buff2 = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "BUFF2");
        buff3 = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "BUFF3");
        buff4 = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "BUFF4");
        buffs.Add(buff1);
        buffs.Add(buff2);
        buffs.Add(buff3);
        buffs.Add(buff4);
       
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
//Resources.Load("Arts/UI/Sprites/",typeof(Sprite))as Sprite;
    void UpdateRingsEquipUI()
    {
        for (int i = 0; i < BuffRingInventory.ringsEquip.Count; i++)
        {
            buffs[i].sprite = BuffRingInventory.ringsEquip[i].UiSprite;
        }

        for (int i = BuffRingInventory.ringsEquip.Count; i<buffs.)
        {
            
        }
    }

    void AddRingsEquip(ItemDefinition ring)
    {
        if (BuffRingInventory.IsRingsEquipAvaliable())
        {
            BuffRingInventory.AddRingsEquip(ring);
            UpdateRingsEquipUI();
        }
        else
        {
            Debug.Log("戒指满了");
        }
    }
}
