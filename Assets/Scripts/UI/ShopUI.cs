using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : BaseUI
{
    public List<GameObject> Item;
    
    public override void Initialize()
    {
        foreach (var but in Item)
        { 
            AddPointerClickEvent("B"+but.transform.name, go =>
            {
                //TODO handle player purchases
                HandlePlayerPurchases();

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

    public void HandlePlayerPurchases()
    {
        
    }
    
}
