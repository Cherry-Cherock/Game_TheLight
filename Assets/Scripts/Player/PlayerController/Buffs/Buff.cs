using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    private int _ringId;
    private List<BuffDefinition> _bd;
    private bool _isApply;
    public Buff(int ringId ,List<BuffDefinition> bd)
    {
        _ringId = ringId;
        _bd = bd;
        _isApply = false;
    }
    
    public int RingId  
    {
        get { return _ringId; }   
        set { _ringId = value; }  
    }
    public List<BuffDefinition> Bd   
    {
        get { return _bd; }   
        set { _bd = value;}  
    }
    
    public bool IsApply  
    {
        get { return _isApply; }   
        set { _isApply = value; }  
    }
}
