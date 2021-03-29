using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveTime = 0.1f;
    float speed = 5.0f;

    Vector3 preMousePos;

    private BoxCollider2D boxcollider;
    private Rigidbody2D rb2D;
    //moveTimeÇåvéZÇ∑ÇÈÇÃÇíPèÉâªÇ∑ÇÈÇΩÇﬂÇÃïœêî
    private float inverseMoveTime;

    public GameObject target;

    private bool isPressed = false;
    private bool isPressed2 = false;

    void Start()
    {
        boxcollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKey(KeyCode.Space) && !isPressed)
        {
            isPressed = true;
            Feed();
        }
        if (Input.GetKey(KeyCode.Q) && !isPressed2)
        {
            isPressed2 = true;
            Love();
        }
    }

    void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            preMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosDiff = Input.mousePosition - preMousePos;
            preMousePos = Input.mousePosition;
            Vector3 newPos = this.gameObject.transform.position + new Vector3(mousePosDiff.x / Screen.width, 0, mousePosDiff.y / Screen.height)*speed;
            
            //rb2D.MovePosition(newPos);

            this.transform.position = newPos;
        }
    }

    void Feed()
    {
        Vector3 newItemPos = this.gameObject.transform.position + new Vector3(1.0f, 0, 0);

        Instantiate(target, newItemPos, Quaternion.identity);
    }

    void Love()
    {
        Vector3 newItemPos = this.gameObject.transform.position + new Vector3(1.0f, 0, 1.0f);

        Instantiate(target, newItemPos, Quaternion.identity);
    }
}
