using System;
using System.Collections;
using System.Collections.Generic;
using Player.InventorySystem;
using UnityEngine;

public class BuffRingInventory : MonoBehaviour
{
    public static List<ItemDefinition> ringsEquip = new List<ItemDefinition>();

    public List<ItemDefinition> RingsEquip => ringsEquip;


    public static List<ItemDefinition> ringsInventory= new List<ItemDefinition>();
    public List<ItemDefinition> RingsInventory => ringsInventory;
    
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
    

    
    
    
    public static void AddRingsEquip(ItemDefinition ring)
    {
        ringsEquip.Add(ring);
    }
    
    public static void AddRingsInventory(ItemStack itemStack)
    {
        ringsInventory.Add(itemStack.Item); 
    }
   
    
}
