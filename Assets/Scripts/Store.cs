using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    int price;
    public CoinSystem coinSystem;
    public GameObject equipment;

    public SaveAndLoad saveAndLoad;

    private void Start()
    {
        price = Convert.ToInt32(gameObject.GetComponentInChildren<Text>().text);
        equipment.SetActive(saveAndLoad.LoadBool(transform.parent.gameObject.name));
        gameObject.SetActive(!saveAndLoad.LoadBool(transform.parent.gameObject.name));
    }


    //Покупает молот за монеты
    public void Buy()
    {
        if (coinSystem.LoadCoins() >= price)
        {
            coinSystem.TakeAwayCoins(price);
            gameObject.GetComponentInParent<Item>().bought = true;
            saveAndLoad.SaveBool(gameObject.GetComponentInParent<Item>().bought,
             transform.parent.gameObject.name);
            equipment.SetActive(true);
            gameObject.SetActive(false);
        }
        else print("not enough money");
    }
}
