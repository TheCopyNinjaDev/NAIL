using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipHammer : MonoBehaviour
{
    public SaveAndLoad saveAndLoad;
    public Item[] items;
    public GameObject[] hammers;


    //Загружает именно тот молот, который был выбран, когда приложение закрылось
    private void Update() 
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(saveAndLoad.LoadBool(i.ToString()) && i != 0)
            {
                items[i].Equip();
                hammers[0].SetActive(false);
                hammers[i].SetActive(true);
            }
        }  
    }
}
