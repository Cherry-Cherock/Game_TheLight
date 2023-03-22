using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    private string skillName;
    private int Damage;
    private int CD;
    private KeyCode _key;

    public Skill(string skillName, int Damage, int CD, KeyCode _key)
    {
        this.skillName = skillName;
        this.Damage = Damage;
        this.CD = CD;
        this._key = _key;
    }

    public void UseSkill()
    {
        
    }
}
