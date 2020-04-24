
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject player;
    public Sprite[] button;
    public string nextScene;
    public bool useArt;
    public bool useProg;
    public bool useMusic;
    public AudioSource As;
    private PlayerController Pc;
    private int timeclicked;
	
    
    void Start()
    {
        Pc = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (useProg)
        {
            switch (Pc.Inteligence)
            {
                case 1:
                    this.GetComponent<Image>().sprite = button[0];
                    break;
                case 2:
                    this.GetComponent<Image>().sprite = button[1];
                    break;
                case 3:
                    this.GetComponent<Image>().sprite = button[2];
                    break;
                case 4:
                    this.GetComponent<Image>().sprite = button[3];
                    break;
                case 5:
                    this.GetComponent<Image>().sprite = button[4];
                    break;
                default:
                    break;
            }
        }
        else if (useArt)
        {
            switch (Pc.Art)
            {
                case 1:
                    this.GetComponent<Image>().sprite = button[0];
                    break;
                case 2:
                    this.GetComponent<Image>().sprite = button[1];
                    break;
                case 3:
                    this.GetComponent<Image>().sprite = button[2];
                    break;
                case 4:
                    this.GetComponent<Image>().sprite = button[3];
                    break;
                case 5:
                    this.GetComponent<Image>().sprite = button[4];
                    break;
                default:
                    break;
            }
        }
        else if (useMusic)
        {
            switch (Pc.Music)
            {
                case 1:
                    this.GetComponent<Image>().sprite = button[0];
                    break;
                case 2:
                    this.GetComponent<Image>().sprite = button[1];
                    break;
                case 3:
                    this.GetComponent<Image>().sprite = button[2];
                    break;
                case 4:
                    this.GetComponent<Image>().sprite = button[3];
                    break;
                case 5:
                    this.GetComponent<Image>().sprite = button[4];
                    break;
                default:
                    break;
            }
        }
    }
    public void TaskOnClick()
    {

        if (useProg)
        {
            if (Pc.ErrorsSolved >= Pc.ForNextLevel)
            {
                if (Pc.Inteligence == 5)
                {
                    As.mute = true;
                    SceneManager.LoadScene(nextScene);
                }
                Pc.Inteligence += 1;
                Pc.ForNextLevel += 10;
            }
        }
        else if (useArt)
        {
            if (Pc.ErrorsSolved >= Pc.ForNextLevel)
            {
                if (Pc.Art == 5)
                {
                    As.mute = true;
                    SceneManager.LoadScene(nextScene);
                }
                Pc.Art += 1;
                Pc.ForNextLevel += 10;
            }
        }
        else if (useMusic)
        {
            if (Pc.ErrorsSolved >= Pc.ForNextLevel)
            {
                if (Pc.Music == 5)
                {
                    As.mute = true;
                    SceneManager.LoadScene(nextScene);
                }
                Pc.Music += 1;
                Pc.ForNextLevel += 10;
            }
        }
    }

}
