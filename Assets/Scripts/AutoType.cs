using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutoType : MonoBehaviour {

    public float Pausa = 0.2f;
    public Text txtUI;
    public string scene;
    public AudioSource As;

    private string texto;
	// Use this for initialization
	void Start () {
        texto = txtUI.text;
        txtUI.text = "";
        StartCoroutine(Type());
        
	}
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            As.mute = true;
            SceneManager.LoadScene(scene);
        }
    }
    IEnumerator Type()
    {
        foreach(char letter in texto.ToCharArray())
        {
            txtUI.text += letter;
            yield return new WaitForSeconds(Pausa); 
        }
    }
}
