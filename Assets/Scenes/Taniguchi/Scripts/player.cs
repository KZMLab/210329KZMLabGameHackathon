using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveTime = 0.1f;
    public float speed = 0.05f;

    public int pointsPerGrass = 10; //草の回復量
    public int pointsPerMeet = 20; //肉の回復量

    private int life; //playerの体力
   

    private Animator animator;

    Vector3 preMousePos;

    private BoxCollider2D boxcollider;
    private Rigidbody2D rb2D;
    //moveTimeを計算するのを単純化するための変数
    private float inverseMoveTime;

    public GameObject target;
    public GameObject target2;

    private bool isPressed = false;
    private bool isPressed2 = false;

    void Start()
    {
        animator = GetComponent<Animator>();
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
            Love();
        }
        if (Input.GetKey(KeyCode.Q) && !isPressed2)
        {
            isPressed2 = true;
            Feed();
        }
    }

    void Move()
    {
        /**
         * if (Input.GetMouseButtonDown(0))
        {
            preMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosDiff = Input.mousePosition - preMousePos;
            preMousePos = Input.mousePosition;
            //Vector3 newPos = this.gameObject.transform.position + new Vector3(mousePosDiff.x / Screen.width, 0, mousePosDiff.y / Screen.height)*speed;
            Vector3 newPos = this.gameObject.transform.position + new Vector3(mousePosDiff.x / Screen.width, mousePosDiff.y / Screen.height,0) * speed;

            //rb2D.MovePosition(newPos);

            this.transform.position = newPos;
            animator.SetTrigger("PlayerRun");
        }
        */
        Vector3 inputPos = new Vector3(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed, 0);
        this.transform.position += inputPos;
    }

    void Feed()
    {
        Vector3 newItemPos = this.gameObject.transform.position + new Vector3(3.0f, 2.0f, 0);

        Instantiate(target, newItemPos, Quaternion.identity);
        animator.SetTrigger("PlayerFeed");
    }

    void Love()
    {
        Vector3 newItemPos = this.gameObject.transform.position;

        Instantiate(target2, newItemPos, Quaternion.identity);
        animator.SetTrigger("PlayerLove");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "grass")
        {
            //体力を回復しotherオブジェクトを削除
            life += pointsPerGrass;
            other.gameObject.SetActive(false);
            Debug.Log("草を食べる");
        }
        else if (other.tag == "Food")
        {
            //体力を回復しotherオブジェクトを削除
            life += pointsPerMeet;
            other.gameObject.SetActive(false);
            Debug.Log("動物に接触");
        }
    }
}
