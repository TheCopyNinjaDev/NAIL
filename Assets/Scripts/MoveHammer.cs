using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHammer : MonoBehaviour
{
    AudioSource audioSource;
    Rigidbody rb;
    Vector3 lastPosition = Vector3.zero;
    Vector3 startPos;
    Quaternion startRot;
    float distance = 2.504177f;
    bool hasCome = false;
    bool animated = false;


    public AudioClip knock;
    public GameObject text;
    public GameObject panel;
    public GameObject sun;
    public static float speed = 0;
    public static bool hitted = false;
    public static bool animate_clouds = false;
    public static bool resetPosClouds = false;
    public static bool player = true;
    public Selector selector;


    void Start()
    {
        Time.timeScale = 1.0f;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        startPos = transform.position;
        startRot = transform.rotation;
        hasCome = false;
        hitted = false;
    }

    private void Update()
    {
        if (!player && !hitted && !selector.pvp) Bot();
    }

    private void FixedUpdate()
    {
        Speedometer();
    }

    private void OnMouseDrag()
    {
        if (!hitted && (player || selector.pvp)) Move();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("nail")) KnockSound();
        if (!hitted) CheckHit(collision);
    }

    private void OnCollisionStay(Collision other) 
    {
        if(!hitted)
        {
            CheckMiss(other);
        }    
    }

    

    //Двигает молот по оси y
    void Move()
    {
        if(Time.timeScale != 0)
        {
            panel.SetActive(false);
            rb.constraints = RigidbodyConstraints.None;
            Vector3 pos = new Vector3(Input.mousePosition.x - 70.0f, Input.mousePosition.y, Input.mousePosition.z);
            Ray ray = Camera.main.ScreenPointToRay(pos);
            Vector3 point = ray.origin + (ray.direction * distance);
            transform.position = new Vector3(point.x, point.y, startPos.z);
            Thor();
        }   
    }

    //Проигрывает звук удара, при соприкосновении молота к чему либо
    void KnockSound()
    {
        audioSource.clip = knock;
        audioSource.volume = speed / 100 + 0.3f;
        audioSource.Play();
    }

    //Расчитывает скорость падение молота
    void Speedometer()
    {
        speed = (transform.position - lastPosition).magnitude / Time.fixedDeltaTime;
        lastPosition = transform.position;
    }

    //Смотрит производится ли попадание по гвоздю
    void CheckHit(Collision c)
    {
        if (c.gameObject.CompareTag("nail"))
        {
            hitted = true;
            StartCoroutine(RestartScene());
        }
    }

    //Смотрит промахнулся ли игрок
    void CheckMiss(Collision c)
    {
        if(!c.gameObject.CompareTag("nail"))
        {
            text.GetComponent<Animation>().Play();
            hitted = true;
            StartCoroutine(RestartScene());
            player = !player;
        }
    }

    //Возвращает молот на место
    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(1.0f);
        Time.timeScale = 1.0f;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        transform.position = startPos;
        transform.rotation = startRot;
        player = !player;
        hasCome = false;
        hitted = false;
        UnThor();
    }

    //Управляет действиями бота
    void Bot()
    {
        Thor();
        float yPosDestination = Random.Range(startPos.y + 1.0f, 2.5f);
        Vector3 destination = new Vector3(startPos.x, yPosDestination, startPos.z);
        float step = 1.0f * Time.deltaTime;
        if (!hasCome) transform.position = Vector3.MoveTowards(transform.position, destination, step);
        if (Vector3.Distance(transform.position, destination) < 0.1f)
        {
            hasCome = true;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
    
    //Приколы Мьельнира
    void Thor()
    {
        if (gameObject.name == "ThorHammer")
        {
            if (!GameObject.Find("Lightning").GetComponent<ParticleSystem>().isPlaying)
            {
                GameObject.Find("Lightning").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Lightning").GetComponentInChildren<ParticleSystem>().Play();
            }
            sun.SetActive(false);
            GameObject clouds = GameObject.Find("Clouds");
            
            if (!animated)
            {
                clouds.GetComponent<Animation>().Play();
                clouds.GetComponentInChildren<ParticleSystem>().Play();
                clouds.GetComponent<AudioSource>().Play();
                clouds.GetComponentInChildren<AudioSource>().Play();
                animated = true;
            }
        }
    }

    //Убирает эффекты молота тора
    void UnThor()
    {
        if (gameObject.name == "ThorHammer")
        {
            if (GameObject.Find("Lightning").GetComponent<ParticleSystem>().isPlaying)
            {
                GameObject.Find("Lightning").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("Lightning").GetComponentInChildren<ParticleSystem>().Stop();
            }
            sun.SetActive(true);
            animated = false;
            GameObject clouds = GameObject.Find("Clouds");
            clouds.GetComponent<Animation>().Play("resetPosClouds");
            clouds.GetComponentInChildren<ParticleSystem>().Stop();
            clouds.GetComponent<AudioSource>().Stop();
            clouds.GetComponentInChildren<AudioSource>().Stop();
        }
    }
}
