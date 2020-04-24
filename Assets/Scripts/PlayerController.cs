using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public bool useArt;
    public bool useProg;
    public bool useMusic;

    private Rigidbody2D rb;
    private static int inteligence = 1;
    private static int art = 1;
    private static int music = 1;
    private int forNextLevel = 5;
    private int errorsSolved = 0;
    private Vector2 moveVelocity;
    private Animator anim;
    public Text[] textoInt;
    // Use this for initialization

    public int Inteligence { get { return inteligence; } set { inteligence = value; } }
    public int ErrorsSolved { get { return errorsSolved; } set { errorsSolved = value; } }
    public int ForNextLevel { get { return forNextLevel; } set { forNextLevel = value; } }
    public int Art { get { return art; } set { art = value; } }
    public int Music { get { return music; } set { music = value; } }

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if(inteligence >= 5)
        {
            inteligence = 5;
        }
        if(art >= 5)
        {
            art = 5;
        }
        if(music >= 5)
        {
            music = 5;
        }



        Vector2 moveInput;

        if (useProg)
        {
            textoInt[0].text = "Programming Skills: " + inteligence;
            textoInt[2].text = "Your current level: " + inteligence;
            textoInt[1].text = "Errors to solve for next level: " + forNextLevel;
            textoInt[3].text = "Errors solved: " + errorsSolved;
        }
        else if (useArt)
        {
            textoInt[0].text = "Art Skills: " + art;
            textoInt[2].text = "Your current level: " + art;
            textoInt[1].text = "Arts to make for next level: " + forNextLevel;
            textoInt[3].text = "Arts made: " + errorsSolved;
        }
        else if (useMusic)
        {
            textoInt[0].text = "Music Skills: " + music;
            textoInt[2].text = "Your current level: " + music;
            textoInt[1].text = "Musics to make for next level: " + forNextLevel;
            textoInt[3].text = "Musics made/Notes played: " + errorsSolved;
        }



        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            moveInput = new Vector2(-1, 1);
            anim.SetInteger("X", -1);
            anim.SetInteger("Y", 1);

        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            moveInput = new Vector2(-1, -1);
            anim.SetInteger("X", -1);
            anim.SetInteger("Y", -1);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            moveInput = new Vector2(1, 1);
            anim.SetInteger("X", 1);
            anim.SetInteger("Y", 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            moveInput = new Vector2(1, -1);
            anim.SetInteger("X", 1);
            anim.SetInteger("Y", -1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = new Vector2(-1, 0);
            anim.SetInteger("X", -1);
            anim.SetInteger("Y", 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = new Vector2(1, 0);
            anim.SetInteger("X", 1);
            anim.SetInteger("Y", 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            moveInput = new Vector2(0, 1);
            anim.SetInteger("X", 0);
            anim.SetInteger("Y", 1);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveInput = new Vector2(0, -1);
            anim.SetInteger("X", 0);
            anim.SetInteger("Y", -1);
        }
        else
        {
            moveInput = new Vector2(0, 0);
            anim.SetInteger("X", 0);
            anim.SetInteger("Y", 0);
        }

        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }


}
