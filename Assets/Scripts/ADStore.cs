using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class ADStore : MonoBehaviour
{
    public int price;
    public int full_price;

    public GameObject equipment;
    public Image circle_fill;
    public Text priceHolder;
    public SaveAndLoad saveAndLoad;
    public AD_Rewarded aD_Rewarded;

    private void Start()
    {
        equipment.SetActive(saveAndLoad.LoadBool(transform.parent.gameObject.name));
        gameObject.SetActive(!saveAndLoad.LoadBool(transform.parent.gameObject.name));
        price = Convert.ToInt32(GetComponentInChildren<Text>().text);
        full_price = price;
    }


    //Покупает вещь за рекламу
    public void Buy()
    {
        aD_Rewarded.ShowADreward();
        if(Advertisement.IsReady("rewardedVideo"))
        {
            price--;
            circle_fill.fillAmount = (float)price / full_price;
            priceHolder.text = price.ToString();
            if (price == 0)
            {
                gameObject.GetComponentInParent<Item>().bought = true;
                saveAndLoad.SaveBool(gameObject.GetComponentInParent<Item>().bought,
                transform.parent.gameObject.name);
                equipment.SetActive(true);
                gameObject.SetActive(false);
            }
        }
        
    }
}
