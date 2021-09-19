using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    //Сохраняет булевую переменную с определенным значением
    public void SaveBool(bool b, string key)
    {
        if (b)
        {
            PlayerPrefs.SetString(key, "true");
        }
        else
        {
            PlayerPrefs.SetString(key, "false");
        }
    }

    //Выгружет булевую переменную по ключу
    public bool LoadBool(string key)
    {
        if(PlayerPrefs.GetString(key) == "true")
        {
            return true;
        }
        else return false;
    }
}
