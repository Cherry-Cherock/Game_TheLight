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

    private TMP_Text buffNum;
    
    private List<Image> buffs = new List<Image>();
    private List<Button> removeBuffBtn = new List<Button>();
    private List<Image> buffsInventory = new List<Image>();
    private Image buff1;
    private Image buff2;
    private Image buff3;
    private Image buff4;


    private Button b1;
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
        
        buffNum = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "BuffNumber");
        buffNum.text = buffNum.text ="<color=#F8913F>"+BuffRingInventory.ringsInventory.Count+"</color> / 18";
        
        //---------------------------------角色装备的buff----------------------------------------------------
        buff1 = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "BUFF1");
        buff2 = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "BUFF2");
        buff3 = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "BUFF3");
        buff4 = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "BUFF4");
        buffs.Add(buff1);
        buffs.Add(buff2);
        buffs.Add(buff3);
        buffs.Add(buff4);
       //---------------------------------Buff Inventory---------------------------------------------------
       for (int i = 0; i < 18; i++)
       {
           Image b = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "B"+i);
           buffsInventory.Add(b);
           var index = i;
           AddPointerClickEvent("bf"+i, go =>
           {
               AddRingsEquip(BuffRingInventory.ringsInventory[index]);
           });
       }
       //-------------------------------Remove buff buttons-------------------------------------------
       for (int i = 1; i < buffs.Count+1; i++)
       {
           Button b = UnityHelper.GetTheChildNodeComponetScripts<Button>(gameObject, "removeButton"+i);
           removeBuffBtn.Add(b);
           var index = i;
           AddPointerClickEvent("removeButton"+i, go =>
           {
               RemoveBuff(index);
           });
       }
       
       
        AddPointerClickEvent("Button_Close", go =>
        {
            transform.gameObject.SetActive(false);
            GameManager.HandleGameStart();
        });
    }
    
    
    public override void Show()
    { 
        base.Show();
        buffNum.text ="<color=#F8913F>"+BuffRingInventory.ringsInventory.Count+"</color> / 18";
        UpdatePlayerData();
        UpdateRingsEquipUI();
        UpdateRingsInventoryUI();
    }

    void UpdatePlayerData()
    {
        playerAttack.text = PlayerController.curDamage.ToString();
    }
    
    void UpdateRingsEquipUI()
    {
        for (int i = 0; i < BuffRingInventory.ringsEquip.Count; i++)
        {
            buffs[i].sprite = BuffRingInventory.ringsEquip[i].UiSprite;
            removeBuffBtn[i].gameObject.SetActive(true);
        }

        for (int i = BuffRingInventory.ringsEquip.Count; i < buffs.Count; i++)
        {
            buffs[i].sprite = Resources.Load("Arts/UI/Sprites/Toggle_Switch_Bg",typeof(Sprite))as Sprite;
        }
    }

    void RemoveBuff(int i)
    {
        Debug.Log("移除："+i);
    }
    void UpdateRingsInventoryUI()
    {
        if (BuffRingInventory.ringsInventory.Count > 0)
        {
            for (int i = 0; i < BuffRingInventory.ringsInventory.Count; i++)
            {
                buffsInventory[i].transform.GetChild(1).gameObject.SetActive(false);
                buffsInventory[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = BuffRingInventory.ringsInventory[i].UiSprite;
                buffsInventory[i].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        Debug.Log(BuffRingInventory.ringsInventory.Count);
        for (int i = BuffRingInventory.ringsInventory.Count; i < buffsInventory.Count; i++)
        {
            buffsInventory[i].transform.GetChild(1).gameObject.SetActive(true);
            buffsInventory[i].transform.GetChild(0).gameObject.SetActive(false);
        }
      
    }

    void AddRingsEquip(ItemDefinition ring)
    {
        if (BuffRingInventory.IsRingsEquipAvaliable(ring))
        {
            BuffRingInventory.AddRingsEquip(ring);
            UpdateRingsEquipUI();
        }
        else
        {
            Debug.Log("戒指错误");
        }
    }
}
