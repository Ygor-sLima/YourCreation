using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorSpawnerController : MonoBehaviour {

    public float startTimeBtwSpawn;
    public Text textoUI;
    public string textoMostrar;
    public GameObject[] errors;
    public PlayerController a;
    public float startTimeBtwReSpawn;

    private bool thereIsErro;
    private float timeBtwSpawn;
    private bool isOn;
    private int dificuldade;
    private GameObject erroGerado;
    private bool GOAlive;
    private float timeBtwReSpawn;
    private string textoIntMenor;
    private bool condicHab;
    private bool condicDesHab;

    void Start()
    {
        textoUI.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (a.useProg)
        {
            condicHab = a.Inteligence >= dificuldade;
            condicDesHab = a.Inteligence < dificuldade;
        }
        else if (a.useArt)
        {
            condicHab = a.Art >= dificuldade;
            condicDesHab = a.Art < dificuldade;
        }
        else if(a.useMusic)
        {
            condicHab = a.Music >= dificuldade;
            condicDesHab = a.Music < dificuldade;
        }
        if (isOn)
        {
            if (Input.GetKeyDown(KeyCode.Space) && condicHab && GOAlive)
            {
                thereIsErro = false;
                a.ErrorsSolved++;
                textoUI.GetComponent<Text>().enabled = false;
                Destroy(erroGerado.gameObject);
                GOAlive = false;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && condicDesHab)
            {
                textoUI.text = textoIntMenor;
            }

        }

        if (timeBtwSpawn <= 0 && !GOAlive)
        {
            thereIsErro = true;
            int rand = Random.Range(0, errors.Length);
            dificuldade = errors[rand].GetComponent<ErroController>().dificuldade;
            this.GetComponent<BoxCollider2D>().size = errors[rand].GetComponent<BoxCollider2D>().size;
            erroGerado = GameObject.Instantiate(errors[rand], transform.position, Quaternion.identity) as GameObject;
            textoIntMenor = erroGerado.GetComponent<ErroController>().textoErro;
            timeBtwSpawn = startTimeBtwSpawn;
            GOAlive = true;        
        }
        else if(!GOAlive && timeBtwSpawn > 0)
        {
            timeBtwSpawn -= Time.deltaTime;
        }
        
        //ReSpawn

        else if(GOAlive && timeBtwReSpawn <= 0 && thereIsErro)
        {
            Destroy(erroGerado.gameObject);
            int rand = Random.Range(0, errors.Length);
            dificuldade = errors[rand].GetComponent<ErroController>().dificuldade;
            this.GetComponent<BoxCollider2D>().size = errors[rand].GetComponent<BoxCollider2D>().size;
            erroGerado = GameObject.Instantiate(errors[rand], transform.position, Quaternion.identity) as GameObject;
            textoIntMenor = erroGerado.GetComponent<ErroController>().textoErro;
            timeBtwReSpawn = startTimeBtwReSpawn;
        }
        else if (GOAlive && timeBtwReSpawn > 0 && thereIsErro)
        {
            timeBtwReSpawn -= Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (thereIsErro)
        {
            textoUI.GetComponent<Text>().text = textoMostrar;
            isOn = true;
            textoUI.GetComponent<Text>().enabled = true;
        }
        else
        {
            isOn = false;
            textoUI.GetComponent<Text>().enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (thereIsErro)
        {
            isOn = false;
            textoUI.GetComponent<Text>().enabled = false;
        }
        else
        {
            isOn = false;
            textoUI.GetComponent<Text>().enabled = false;
        }
    }

}
