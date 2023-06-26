using System.Collections;
using System.Collections.Generic;using TMPro.Examples;
using UnityEngine;
[CreateAssetMenu(menuName = "Buff/Create BuffDefinition", fileName = "New buff")]
public class BuffDefinition : ScriptableObject
{
    [SerializeField]
    private int _type;
    [SerializeField]
    private int _option;
    [SerializeField]
    private int _amount;
    
    public int Type
    {
        get { return _type; }
        set { _type = value; }
    }
    
    public int Option
    {
        get { return _option; }
        set { _option = value; }
    }
    
    public int Amount 
    {
        get { return _amount; }   
        set { _amount = value; }  
    }
}


