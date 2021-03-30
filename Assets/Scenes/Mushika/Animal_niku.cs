using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_niku : MonoBehaviour
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

        if (timeElapsed >= timeOut && chase == false)
        {
            rb.velocity = new Vector2(movex * speed, movey * speed);

            timeElapsed = 0.0f;
            timeOut = Random.Range(1.0f, 3.0f);
        }

        if (chase == true)
        {
            rb.velocity = new Vector2(0, 0); //animal-player
        }

        Debug.Log(food);

    }

    public bool GetFood()
    {
        food++;
        if (food >= 3)
        {
            Destroy(this.gameObject);
            return true;
        }
        return false;
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
