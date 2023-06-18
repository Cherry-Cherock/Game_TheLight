using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuffsController
{
    //player current buffs
    public static List<Buff> curBuffs = new List<Buff>();
    
    public static void ApplyBuff(Buff buff)
    {
        if (buff.IsApply!=true && buff.Bd.Count>0)
        {
            //----------------Apply---------------------
            /*buff.IsApply = true;*/
            foreach (var b in buff.Bd)
            {
                switch (b.Type)
                {
                    //player health
                    case 1:
                        PlayerController.healthMax = HandleChange(PlayerController.healthMax, true, b.Option, b.Amount);
                        break;
                    //player speed
                    case 2:
                        PlayerController.moveSpeed = HandleChange(PlayerController.moveSpeed, true, b.Option, b.Amount);
                        break;
                    //player basic attack
                    case 3:
                        PlayerController.curDamage = HandleChange(PlayerController.curDamage, true, b.Option, b.Amount);
                        break;
                    //player PDefense
                    case 4:
                        PlayerController.curPDefense = HandleChange(PlayerController.curPDefense, true, b.Option, b.Amount);
                        break;
                    //player MDefense
                    case 5:
                        PlayerController.curMDefense = HandleChange(PlayerController.curMDefense, true, b.Option, b.Amount);
                        break;
                    //player jump
                    case 6: 
                       
                        break;
                    //enemy speed
                    case 7:
                        
                        break;
                }
            }
            curBuffs.Add(buff);
            //-------------print current all buffs---------------
            string ringlog = "";
            foreach (var bf in curBuffs)
            {
                ringlog += bf.RingId.ToString() + " ,";
            }
            Debug.Log(ringlog);
            //------------------------------------------------
        }
        else
        {
            Debug.Log("buff applying! or empty buff!");
        }
    }

    public static void CloseBuff(Buff bb)
    {
        bb.IsApply = false;
            foreach (var b in bb.Bd)
            {
                switch (b.Type)
                {
                    //player health
                    case 1:
                        PlayerController.healthMax = HandleChange(PlayerController.healthMax, false, b.Option, b.Amount);
                        break;
                    //player speed
                    case 2:
                        PlayerController.moveSpeed = HandleChange(PlayerController.moveSpeed, false, b.Option, b.Amount);
                        break;
                    //player basic attack
                    case 3:
                        PlayerController.curDamage = HandleChange(PlayerController.curDamage, false, b.Option, b.Amount);
                        break;
                    //player PDefense
                    case 4:
                        PlayerController.curPDefense = HandleChange(PlayerController.curPDefense, false, b.Option, b.Amount);
                        break;
                    //player MDefense
                    case 5:
                        PlayerController.curMDefense = HandleChange(PlayerController.curMDefense, false, b.Option, b.Amount);
                        break;
                    //player jump
                    case 6: 
                       
                        break;
                    //enemy speed
                    case 7:
                        
                        break;
                }
            }
    }


    public static Buff FindBuffByRingId(int id)
    {
        foreach (var bu in curBuffs)
        {
            if (bu.RingId == id)
            {
                curBuffs.Remove(bu);
                return bu;
            }
        }
        return null;
    }


    public static int HandleChange(int cur, bool ac, int op, int am)
    {
        //apply/close buff
        switch (op)
        {
            case 1:
                cur += ac? am : -am;
                break;
            case 2:
                cur -= ac? am : -am;
                break;
            case 3:
                cur = ac? cur * am : cur / am; 
                break;
            case 4:
                cur = ac? cur / am : cur * am;
                break;
        }

        return cur;
    }
    
    

}
