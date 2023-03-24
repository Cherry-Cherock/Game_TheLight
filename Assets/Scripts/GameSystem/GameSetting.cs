using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{    
    public static bool FullScreen;
     public static Vector2[] Resolutions = new Vector2[] { new Vector2(1920, 1080),new Vector2(500, 500) , new Vector2(1280, 720)};
     public static int[] Difficulty = new[] { 0, 1, 2 };
     public static int DifficultyIndex;
     public static int ResolutionIndex;
     public static bool LanguageCN;
    public static void InitSetting()
    {
        
        FullScreen = PlayerPrefs.HasKey(PlayerPrefsID.FullScreen) ? PlayerPrefs.GetInt(PlayerPrefsID.FullScreen) == 1 : defaultFullScreen;
        ResolutionIndex = PlayerPrefs.GetInt(PlayerPrefsID.ResolutionIndex, defaultResolutionIndex);
        DifficultyIndex = PlayerPrefs.GetInt(PlayerPrefsID.DifficultyIndex, defaultDifficultyIndex);
        LanguageCN = PlayerPrefs.HasKey(PlayerPrefsID.languageCN) ? PlayerPrefs.GetInt(PlayerPrefsID.languageCN) == 1 : defaultLanguageCN;
        //log
        Debug.Log("------初始化设置------"+"\n"+
                  "FullScreen: "+FullScreen+"\n"+
                  "ResolutionIndex: "+ResolutionIndex+"\n"+
                  "DifficityIndex: "+DifficultyIndex+"\n"+
                  "LanguageCN: "+LanguageCN);
    }

    public static void SetSetting()
    {
        PlayerPrefs.SetInt(PlayerPrefsID.FullScreen, FullScreen ? 1 : 0);
        PlayerPrefs.SetInt(PlayerPrefsID.ResolutionIndex, ResolutionIndex);
        PlayerPrefs.SetInt(PlayerPrefsID.DifficultyIndex, DifficultyIndex);
        PlayerPrefs.SetInt(PlayerPrefsID.languageCN, LanguageCN ? 1 : 0);
        
        // if (FullScreen)
        // {
        //     Screen.SetResolution((int)Resolutions[0].x, (int)Resolutions[0].y, true);
        // }
        // else
        
            Screen.SetResolution((int)Resolutions[ResolutionIndex].x, (int)Resolutions[ResolutionIndex].y, false);
            Debug.Log("zzzzz: "+(int)Resolutions[ResolutionIndex].x+", "+(int)Resolutions[ResolutionIndex].y);
        
    }
    
    
    #region Default value
    public static bool defaultFullScreen = true;
    public static int defaultResolutionIndex = 0; 
    public static int defaultDifficultyIndex = 0;
    public static bool defaultLanguageCN = false;
    #endregion
}
