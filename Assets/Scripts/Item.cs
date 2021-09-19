using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public bool bought;
    public bool equiped = false;
    public int id;
    public GameObject[] hammersUI;
    public SaveAndLoad saveAndLoad;


    private void Start()
    {

        if(id != 0)
        {
            bought = saveAndLoad.LoadBool(gameObject.name);
        }
        

        if (!bought)
        {
            if (GetComponentInChildren<Store>())
            {
                GetComponentInChildren<Button>().onClick.
                AddListener(GetComponentInChildren<Store>().Buy);
            }
            else if(GetComponentInChildren<ADStore>())
            {
                GetComponentInChildren<Button>().onClick.
                AddListener(GetComponentInChildren<ADStore>().Buy);
            }  
        }
    }

    private void Update()
    {
        
        if(bought)
        {
            GetComponentInChildren<Button>().onClick.RemoveAllListeners();
            GetComponentInChildren<Button>().onClick.AddListener(Equip);
        }
    }

    //Выбирает молот
    public void Equip()
    {
        equiped = true;
        saveAndLoad.SaveBool(equiped, id.ToString());
        for (int i = 0; i < hammersUI.Length; i++)
        {
            if (hammersUI[i] != hammersUI[id])
            {
                hammersUI[i].GetComponent<Item>().equiped = false;
                saveAndLoad.SaveBool(hammersUI[i].GetComponent<Item>().equiped,
                 i.ToString());
            }
        }
    }
}
