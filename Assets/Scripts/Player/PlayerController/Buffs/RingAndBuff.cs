using System.Collections;
using System.Collections.Generic;
using Player.InventorySystem;
using UnityEngine;

public class RingAndBuff 
{
    /*//true: apply false: close
    public static void ApplyCloseBuffByRing(bool b, ItemDefinition ring)
    {
        if (b)
        {
            switch (ring.Id)
            {
                //magicShield
                case 300:
                    List<BuffDefinition> bd = new List<BuffDefinition>();
                    bd.Add(new BuffDefinition(5, 4, 2));
                    BuffsController.ApplyBuff(new Buff(ring.Id, bd));
                    break;
                //physicalShield
                case 301:
                    List<BuffDefinition> bd1 = new List<BuffDefinition>();
                    bd1.Add(new BuffDefinition(4, 4, 2));
                    BuffsController.ApplyBuff(new Buff(ring.Id, bd1));
                    break;
                //warriorShield
                case 303:
                    List<BuffDefinition> bd2 = new List<BuffDefinition>();
                    bd2.Add(new BuffDefinition(3, 3, 2));
                    BuffsController.ApplyBuff(new Buff(ring.Id, bd2));
                    break;
            }
        }
        else
        {
            BuffsController.CloseBuff(ring.Id);
        }
    }*/
}
