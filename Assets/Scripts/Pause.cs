using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public GameObject pauseButton;
    public GameObject pauseMenu;
    public GameObject[] hammers;
    public GameObject[] hammersUI;
    public GameObject sun;

    private void Update()
    {
        //Выбираем молот
        for (int i = 0; i < hammersUI.Length; i++)
        {
            if (hammersUI[i].GetComponent<Item>().bought)
            {
                if (hammersUI[i].GetComponent<Item>().equiped)
                {
                    hammersUI[i].GetComponentInChildren<Text>().text = "Equiped";
                    hammers[i].SetActive(true);
                }
                else
                {
                    hammersUI[i].GetComponentInChildren<Text>().text = "Equip";
                    hammers[i].SetActive(false);
                }
            }
        }
    }

    

    //Ставит игру на паузу
    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    //Снимает игру с паузы
    public void Close()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        sun.SetActive(true);
    }

    //Перезапускает уровень
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
