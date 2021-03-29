using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb = null;
    private float timeOut = 2.0f;
    private float timeElapsed;
    private float movex;
    private float movey;
    private float speed = 2;
    private int food = 0;

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

        if (timeElapsed >= timeOut)
        {
            rb.velocity = new Vector2(movex*speed, movey*speed);

            timeElapsed = 0.0f;
            timeOut = Random.Range(1.0f, 3.0f);
        }

        if (Input.GetKey("left shift"))
        {
            Debug.Log("‘‚¦‚½");
            food++;
        }

        if(food >= 3)
        {
            Debug.Log("’‡ŠÔ‚É‚È‚Á‚½");
        }
        Debug.Log(food);
    }
}
