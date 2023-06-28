using System.Collections;
using System.Collections.Generic;
using Player.InventorySystem;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : BaseUI
{
    public List<GameObject> Item;
    public GameItem empty;
    public List<ItemDefinition> GameItems;
    private Inventory _inventory;
    public GameObject healthPotion;
    
    private void Awake()
    {
        _inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }
    public override void Initialize()
    {
        
        for (int i = 0; i<Item.Count; i++)
        {
            var i1 = i;
            AddPointerClickEvent("B"+Item[i].transform.name, go =>
            {
                //TODO handle player purchases
                HandlePlayerPurchases(i1);
            });
        }
        AddPointerClickEvent("Button_Close", go =>
        {
            transform.gameObject.SetActive(false);
            GameManager.HandleGameStart();
        });
       
        AddPointerClickEvent("RefreshBtn", go =>
        { 
         //TODO Refresh shop items
         
         RefreshShop();
        });
    }
    
    
    public void RefreshShop()
    {
        
    }

    public void HandlePlayerPurchases(int i)
    {Debug.Log(i);
        if (i==1)
        {
            Debug.Log("buy health potion");
            PlayerController.curGold -= 700;
            healthPotion.gameObject.SetActive(true);
            empty.Stack.Item = GameItems[i];
            _inventory.AddItem(empty.Stack);
        }
    }
    
}
