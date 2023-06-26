using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuffsController
{
    //player current buffs
    public static List<Buff> curBuffs = new List<Buff>();
    //player current state
    public static List<PlayerController.StateKind> curStates = new List<PlayerController.StateKind>();

    //----------------some default data---------------------
    private static int dPlayerBasicDamage = 0;
    public static void ApplyBuff(Buff buff)
    {
        if (buff.IsApply!=true && buff.Bd.Count>0)
        {
            //----------------Apply---------------------
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
                        PlayerController.curBasicDamage = HandleChange(PlayerController.curBasicDamage, true, b.Option, b.Amount);
                        break;
                    //player PDefense
                    case 4:
                        PlayerController.curPDefense = HandleChange(PlayerController.curPDefense, true, b.Option, b.Amount);
                        break;
                    //player MDefense
                    case 5:
                        PlayerController.curMDefense = HandleChange(PlayerController.curMDefense, true, b.Option, b.Amount);
                        break;
                    //Lucky Grass
                    case 6:
                        dPlayerBasicDamage = PlayerController.curBasicDamage;
                        HandleLuckyGrassChange(true);
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
                        PlayerController.curBasicDamage = HandleChange(PlayerController.curBasicDamage, false, b.Option, b.Amount);
                        break;
                    //player PDefense
                    case 4:
                        PlayerController.curPDefense = HandleChange(PlayerController.curPDefense, false, b.Option, b.Amount);
                        break;
                    //player MDefense
                    case 5:
                        PlayerController.curMDefense = HandleChange(PlayerController.curMDefense, false, b.Option, b.Amount);
                        break;
                    //Lucky Grass
                    case 6: 
                       HandleLuckyGrassChange(false);
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


    // ac-> true: apply , false: close
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

    public static void HandleLuckyGrassChange(bool ac)
    {
        if (ac)
        {
            curStates.Add(PlayerController.StateKind.randomBasicDamage);
        }
        else
        {
            curStates.Remove(PlayerController.StateKind.randomBasicDamage);
            PlayerController.curBasicDamage = dPlayerBasicDamage;
            dPlayerBasicDamage = 0;
        }
    }
    
    

}
