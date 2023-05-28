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
                //test
                //Debug.Log(but.transform.name);
                //处理购买的商品
                HandlePlayerPurchases();

            });
        }
        
        AddPointerClickEvent("Button_Close", go =>
        { 
            
            transform.gameObject.SetActive(false); 
            Time.timeScale      = 1.0f;
            AudioListener.pause = false;
            GameManager.currentGameState = GameManager.GameState.RUNNING;
        });
       
        AddPointerClickEvent("RefreshBtn", go =>
        { 
         //刷新商品
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
