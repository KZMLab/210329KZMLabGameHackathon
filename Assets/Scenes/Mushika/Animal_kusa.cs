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
    private int state = 0;  //true:ñÏê∂Å@false:íáä‘
    private float random_x;
    private float random_y;

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
        Transform mytransform = this.transform;

        if (timeElapsed >= timeOut && chase == false && state == 0)
        {
            rb.velocity = new Vector2(movex * speed, movey * speed);

            timeElapsed = 0.0f;
            timeOut = Random.Range(1.0f, 3.0f);
        }

        if (chase == true && state == 0)
        {
            rb.velocity = new Vector2(0, 0); //-(animal-player)ìÆï®ÇÕÇ…Ç∞ÇÈï˚å¸Ç≈
        }
        
        if (state == 1)
        {
            player = GameObject.Find("Player");
            mytransform.position = new Vector2(player.transform.position.x + random_x, player.transform.position.y + random_y);
            Debug.Log("é¿çsíÜ");

        }

    }

    public void GetFood()
    {
        food++;
        if (food >= 3)
        {
            Transform mytransform = this.transform;
            state = 1;
            player = GameObject.Find("Player");
            random_x = Random.Range(-3.0f, 3.0f);
            random_y = Random.Range(-3.0f, 3.0f);
            mytransform.position = new Vector2(player.transform.position.x + random_x, player.transform.position.y + random_y);
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
