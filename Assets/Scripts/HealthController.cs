using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    public int vida;
    public int NumMax;

    public Image[] coracoes;
    public Sprite cheio;
    public Sprite vazio;
    
	// Update is called once per frame
	void Update () {
       

        for (int i = 0; i < coracoes.Length; i++)
        {

            if(vida>NumMax)
            {
                vida = NumMax;
            }

            if(i<vida)
            {
                coracoes[i].sprite = cheio;
            }
            else
            {
                coracoes[i].sprite = vazio;
            }

            if(i < NumMax)
            {
                coracoes[i].enabled = true;
            }
            else
            {
                coracoes[i].enabled = false;
            }
        }

	}
}
