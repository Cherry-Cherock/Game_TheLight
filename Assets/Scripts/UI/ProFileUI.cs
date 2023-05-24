using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ProFileUI : MonoBehaviour
{
    //HP
    public static int CurHealth;
    public static int healthMax = 20;
    private Image HPBar;
    
    //mana
    public static int CurMana;
    public static int manaMax = 20;
    private Image ManaBar;
    void Start()
    {
        CurHealth = healthMax;
        CurMana = manaMax;
        HPBar = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "HP");
        ManaBar = UnityHelper.GetTheChildNodeComponetScripts<Image>(gameObject, "Mana");
    }
    
    void Update()
    {
        HPBar.fillAmount = (float)CurHealth / (float)healthMax;
        ManaBar.fillAmount = (float)CurMana / (float)manaMax;
    }
}
