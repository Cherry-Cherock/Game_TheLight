using System.Collections;
using System.Collections.Generic;using TMPro.Examples;
using UnityEngine;

public class BuffDefinition 
{
    private int _id;
    private int _uid;
    private int _type;
    private int _option;
    private int _amount;
    

    //option 1=>加 2=>减 3=>乘 4=>除
    public BuffDefinition(int type,int option, int amount)
    { 
        _uid++;
        _id = _uid;
       _type = type;
       _option = option;
       _amount = amount;
       
    }
    
    public int Id   
    {
        get { return _id; }   
        set { _id = value; }  
    }
    
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


