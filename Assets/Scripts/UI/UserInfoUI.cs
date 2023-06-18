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
        //---------------------------------Player data-----------------------------------------------------
        playerHP = UnityHelper.GetTheChildNodeComponetScripts<TMP_Text>(gameObject, "playerHP");
        playerHP.text = PlayerController.healthMax.ToString();
        
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
        
        //---------------------------------Equipped buff rings----------------------------------------------------
        buff1 = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "BUFF1");
        buff2 = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "BUFF2");
        buff3 = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "BUFF3");
        buff4 = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "BUFF4");
        buffs.Add(buff1);
        buffs.Add(buff2);
        buffs.Add(buff3);
        buffs.Add(buff4);
       //----------------------------------Buff Inventory---------------------------------------------------
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
               RemoveBuffUI(index);
           });
       }
       
       
        AddPointerClickEvent("Button_Close", go =>
        {
            ConfirmChange();
            transform.gameObject.SetActive(false);
            GameManager.HandleGameStart();
        });
    }
    
    
    public override void Show()
    { 
        base.Show();
        UpdatePlayerData();
        UpdateRingsEquipUI();
        UpdateRingsInventoryUI();
    }

    void UpdatePlayerData()
    {
        buffNum.text ="<color=#F8913F>"+BuffRingInventory.ringsInventory.Count+"</color> / 18";
        playerAttack.text = PlayerController.curDamage.ToString();
        playerHP.text = PlayerController.healthMax.ToString();
        playerSpeed.text = PlayerController.moveSpeed.ToString();
        playerPDefense.text = PlayerController.curPDefense.ToString();
        playerMDefense.text = PlayerController.curMDefense.ToString();
    }
    
    void UpdateRingsEquipUI()
    {
        foreach (var btn in removeBuffBtn)
        {
            btn.gameObject.SetActive(false);
        }
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

    void RemoveBuffUI(int i)
    {
        Debug.Log("移除："+i);
        buffs[i-1].sprite = Resources.Load("Arts/UI/Sprites/Toggle_Switch_Bg",typeof(Sprite))as Sprite;
        /*RingAndBuff.ApplyCloseBuffByRing(false, BuffRingInventory.ringsEquip[i-1]);*/
        BuffsController.CloseBuff(BuffRingInventory.ringsEquip[i-1].Buff);
        BuffRingInventory.ringsEquip[i - 1].Buff.IsApply = false;
        BuffRingInventory.ringsEquip.RemoveAt(i-1);
        UpdateRingsEquipUI();
        UpdatePlayerData();
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
        for (int i = BuffRingInventory.ringsInventory.Count; i < buffsInventory.Count; i++)
        {
            buffsInventory[i].transform.GetChild(1).gameObject.SetActive(true);
            buffsInventory[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    void ConfirmChange()
    {
       
    }

    void AddRingsEquip(ItemDefinition ring)
    {
        if (BuffRingInventory.IsRingsEquipAvaliable(ring))
        {
            BuffRingInventory.AddRingsEquip(ring);
            BuffsController.ApplyBuff(ring.Buff);
            /*RingAndBuff.ApplyCloseBuffByRing(true,ring);*/
            UpdateRingsEquipUI();
            UpdatePlayerData();
        }
        else
        {
            Debug.Log("戒指错误");
        }
    }
}
