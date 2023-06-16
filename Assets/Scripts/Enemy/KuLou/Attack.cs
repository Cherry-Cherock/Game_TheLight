using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    public string attackType;
    private void Start()
    {
        UpdateEnemyName();
    }

    private void OnValidate()
    {
        UpdateEnemyName();
    }
    
    private void UpdateEnemyName()
    {
        gameObject.name = $"{attackType}:{damage}";
    }
}
