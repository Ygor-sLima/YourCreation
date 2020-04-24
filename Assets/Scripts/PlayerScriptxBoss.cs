using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScriptxBoss : MonoBehaviour {

    private Rigidbody2D rb;

    public float speed;
    private Vector2 moveVelocity;
    private Animator anim;
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 moveInput;
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Thanks");
        }
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }
}
