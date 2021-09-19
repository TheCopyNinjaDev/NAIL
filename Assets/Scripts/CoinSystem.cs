using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour
{
    private void Update()
    {
        
        if(gameObject.name == "Currency")
        {
            ShowCoins();
        }
    }

    //Возвращает значение - сколько монет хранится в памяти
    public int LoadCoins()
    {
        return PlayerPrefs.GetInt("coin");
    }

    //Показывает общее количество монеток
    void ShowCoins()
    {
        GetComponentInChildren<Text>().text = LoadCoins().ToString();   
    }

    //Сохраняет количество монеток в память
    void SaveCoins(int coins)
    {
        PlayerPrefs.SetInt("coin", coins);
    }

    //Добавляет и сохраняет количество монеток в память
    public void AddCoins(int coins)
    {
        SaveCoins(coins + LoadCoins());
    }

    //Отнимает и сохраняет количество монеток в память
    public void TakeAwayCoins(int coins)
    {
        SaveCoins(LoadCoins() - coins);
    }

    
}
