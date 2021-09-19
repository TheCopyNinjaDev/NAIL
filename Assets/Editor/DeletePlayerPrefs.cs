using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorTools : EditorWindow
{
    [SerializeField] static CoinSystem coinSystem = new CoinSystem();

    [MenuItem("Tools/ResetPlayerPrefs")]
    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("<b> **** Player Prefs Deleted **** </b>");
    }

    [MenuItem("Tools/GiveMe1000")]
    public static void GiveMe1000()
    {
        coinSystem.AddCoins(1000);
    }
}
