using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ProFileUI : MonoBehaviour
{
    //HP
    private Image HPBar;
    
    //mana
    public static int CurMana;
    public static int manaMax = 20;
    private Image ManaBar;
    void Start()
    {
        CurMana = manaMax;
        HPBar = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "HP");
        ManaBar = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "Mana");
    }
    
    void Update()
    {
        HPBar.fillAmount = (float)PlayerController.curHealth / (float)PlayerController.healthMax;
        ManaBar.fillAmount = (float)CurMana / (float)manaMax;
    }
}
