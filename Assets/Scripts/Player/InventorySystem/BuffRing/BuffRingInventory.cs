using System;
using System.Collections;
using System.Collections.Generic;
using Player.InventorySystem;
using UnityEngine;

public class BuffRingInventory : MonoBehaviour
{
    public static List<ItemDefinition> ringsEquip;

    public List<ItemDefinition> RingsEquip => ringsEquip;


    public static List<ItemDefinition> ringsInventory; 
    public List<ItemDefinition> RingsInventory => ringsInventory;

    private void Awake()
    {
        ringsEquip = new List<ItemDefinition>();
        ringsInventory = new List<ItemDefinition>();
    }

    

    public static bool IsRingsEquipAvaliable()
    {
        return ringsEquip.Count < 4;
    }
    
    

    public static void AddRingsEquip(ItemDefinition ring)
    {
        ringsEquip.Add(ring);
    }
   
    
}
