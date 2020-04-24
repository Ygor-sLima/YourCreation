using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerController : MonoBehaviour {

    public GameObject menu;
    public Transform MenuOnScreenPos;
    public Transform MenuOffScreenPos;
    public Text textoUI;
    public string texto;
    public Button btnPS;
    public int speed;

    bool PlayerIsOn;
    bool taIndo;
    bool taIndoF;
    bool MenuInScreen = false;

	void Start () {
        textoUI.enabled = false;
        menu.transform.position = MenuOffScreenPos.position;
        btnPS.interactable = false;
	}

    void Update()
    {
        
        if(menu.transform.position == MenuOnScreenPos.position)
        {

            taIndo = false;
            taIndoF = false;
            MenuInScreen = true;
            btnPS.interactable = true;

        }
        else if (menu.transform.position == MenuOffScreenPos.position)
        {
            taIndo = false;
            taIndoF = false;
            MenuInScreen = false;
            btnPS.interactable = false;

        }

        if (PlayerIsOn && (!MenuInScreen && Input.GetKeyDown(KeyCode.B) || taIndo))
        {
            taIndoF = false;
            taIndo = true;
            menu.transform.position = Vector2.MoveTowards(menu.transform.position, MenuOnScreenPos.position, speed * Time.deltaTime);
            btnPS.interactable = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) || taIndoF)
        {
            MenuInScreen = false;
            taIndoF = true;
            menu.transform.position = Vector2.MoveTowards(menu.transform.position, MenuOffScreenPos.position, speed * Time.deltaTime);
            btnPS.interactable = false;

        }
        else if (!PlayerIsOn)
        {
            menu.transform.position = Vector2.MoveTowards(menu.transform.position, MenuOffScreenPos.position, speed * Time.deltaTime);
            taIndo = false;
            taIndoF = false;
            MenuInScreen = false;
            btnPS.interactable = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerIsOn = true;
        textoUI.text = texto;   
        textoUI.enabled=true;
    }

    

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerIsOn = false;
        textoUI.enabled = false;
    }
}
