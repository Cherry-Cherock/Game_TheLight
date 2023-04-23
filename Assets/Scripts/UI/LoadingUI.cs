using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    public Slider slider;
    private int max = 100;
    private float wait1 = 0.5f;
    private int wait2;


    private void OnEnable()
    {
        // MyAStar.startLoading += Load;
    }

    public void Load()
    {
        while (slider.value<wait1)
        {
            slider.value+= 0.1f * Time.deltaTime;
        }
    }


    // private void Update()
    // {
    //     if (slider.value<wait1)
    //     {
    //         slider.value+= 0.1f * Time.deltaTime;
    //     }
    // }

  


}


