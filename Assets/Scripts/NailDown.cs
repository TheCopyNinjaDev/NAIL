using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NailDown : MonoBehaviour
{
    Vector3 startPos;
    int hits = 0;

    public CoinSystem coinSystem;
    public GameObject ResultScreen;
    public Text win_or_lose;
    public Text number_of_hits;
    public Text coins_earned;
    public Selector selector;
    public int tries = 0;

    private void Start()
    {
        startPos = transform.position;
        Time.timeScale = 1.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Hammering(collision);
        if(transform.position.y <= 0.6290247f)
        {
            transform.position = new Vector3(startPos.x, 0.6290247f, startPos.z);
            if (MoveHammer.player)
            {
                if (!selector.pvp)
                    StartCoroutine(ShowResult("Lose", hits));
                else StartCoroutine(ShowResult("Boom", hits));
            }
            else
            {
                if(!selector.pvp)
                    StartCoroutine(ShowResult("Won", hits));
                else StartCoroutine(ShowResult("OOps", hits));
            }
            tries++;
        }
    }


    //Забивание гвоздя зависит от скорости падения молота
    void Hammering(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && MoveHammer.hitted)
        {
            transform.position = new Vector3(startPos.x, startPos.y - (0.005f * MoveHammer.speed), startPos.z);
            startPos = transform.position;
            GetComponentInChildren<ParticleSystem>().Play();
            hits++;
        }
    }

    //Включает табло показания результата, после ждет 1с и останавливает время
    IEnumerator ShowResult(string result, int hits)
    {
        ResultScreen.SetActive(true);
        win_or_lose.text = result;
        number_of_hits.text = "at " + hits + " hits";
        if (result == "Won")
        {
            coins_earned.text = "+" + (100 / hits);
            coinSystem.AddCoins(100 / hits);
        }
        else
        {
            coins_earned.text = "+" + 10;
            coinSystem.AddCoins(10);
        }
        yield return new WaitForSeconds(1.0f);
        Time.timeScale = 0.0f;
        
    }

}
