using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_kusa : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb = null;
    private float timeOut = 2.0f;
    private float timeElapsed;
    private float timeAttack;
    private float movex;
    private float movey;
    private float speed = 2;
    private int food = 0;
    private int hp = 3;
    private bool chase = false;
    private int item = 0;
    private GameObject player;
    private bool state = true;  //true:ñÏê∂Å@false:íáä‘

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movex = Random.Range(-1.0f, 1.0f);
        movey = Random.Range(-1.0f, 1.0f);

        timeElapsed += Time.deltaTime;
        
        if (timeElapsed >= timeOut && chase == false && state == true)
        {
            rb.velocity = new Vector2(movex * speed, movey * speed);

            timeElapsed = 0.0f;
            timeOut = Random.Range(1.0f, 3.0f);
        }

        if (chase == true && state == true)
        {
            rb.velocity = new Vector2(0, 0); //-(animal-player)ìÆï®ÇÕÇ…Ç∞ÇÈï˚å¸Ç≈
        }
        
        if (state == false)
        {
            rb.velocity = new Vector2(player.transform.position.x, player.transform.position.y);

        }

        if (Input.GetKeyDown("q"))
        {
            state = false;
            
        }

        Debug.Log(state);


    }

    public void GetFood()
    {
        food++;
        if (food >= 3)
        {
            state = false;
        }
    }


    public int Hit()
    {
        chase = true;
        hp--;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            item = Random.Range(2, 5);
            return item;
        }
        return 0;

    }

}
