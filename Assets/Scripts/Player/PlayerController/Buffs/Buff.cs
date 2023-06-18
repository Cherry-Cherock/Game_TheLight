using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Buff/Create Buff", fileName = "New buff")]
public class Buff: ScriptableObject
{
    [SerializeField]
    private int _ringId;
    
    [SerializeField]
    private List<BuffDefinition> _bd;
    
    [SerializeField]
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
