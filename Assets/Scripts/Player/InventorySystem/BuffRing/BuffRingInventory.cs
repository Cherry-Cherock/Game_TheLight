using System;
using System.Collections;
using System.Collections.Generic;
using Player.InventorySystem;
using UnityEngine;

public class BuffRingInventory : MonoBehaviour
{
    public static List<ItemDefinition> ringsEquip = new List<ItemDefinition>();
    public static List<ItemDefinition> ringsInventory= new List<ItemDefinition>();
    
    public static bool IsRingsEquipAvaliable(ItemDefinition ring)
    {
        foreach (var e in ringsEquip)
        {
            if (e.Name.Equals(ring.Name))
            {
                return false;
            }
        }
        return ringsEquip.Count < 4;
    }
    
    public static bool IsRingsInventoryAvaliable(GameObject ring)
    {
        foreach (var e in ringsInventory)
        {
            if (e.Name.Equals(ring.GetComponent<GameItem>().Stack.Item.Name))
            {
                return false;
            }
        }
        return ringsInventory.Count < 19;
    }
    
    
    
    public static void AddRingsEquip(ItemDefinition ring)
    {
        ringsEquip.Add(ring);
    }
    
    public static void AddRingsInventory(ItemStack itemStack)
    {
        ringsInventory.Add(itemStack.Item); 
    }
   
    
}
