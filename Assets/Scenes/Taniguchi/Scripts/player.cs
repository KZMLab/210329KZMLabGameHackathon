using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveTime = 0.1f;
    public float speed = 0.05f;

    public int pointsPerGrass = 10; //草の回復量
    public int pointsPerMeet = 20; //肉の回復量

    [HideInInspector]public int life = 1; //playerの体力
   
    [HideInInspector] public int foodCount = 0; //所持するえさの数
    [HideInInspector] public int kusa_num = 0; //味方草食動物の数
    [HideInInspector] public int niku_num = 0; //味方肉食動物の数

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

        foodCount = 0;
        life = 1;
        animator = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Q) && !isPressed)
        {
            isPressed = true;
            Love();
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isPressed2)
        {
            isPressed2 = true;
            Feed();
        }
        Debug.Log(foodCount);
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
        if (foodCount > 0)
        {
            foodCount--;
            Vector3 newItemPos = this.gameObject.transform.position + new Vector3(3.0f, 2.0f, 0);

            Instantiate(target, newItemPos, Quaternion.identity);
            animator.SetTrigger("PlayerFeed");
        }
        isPressed2 = false;
    }

    void Love()
    {
        Vector3 newItemPos = this.gameObject.transform.position;

        Instantiate(target2, newItemPos, Quaternion.identity);
        animator.SetTrigger("PlayerLove");
        
        isPressed = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "grass")
        {
            //体力を回復しotherオブジェクトを削除
            other.gameObject.SetActive(false);
            Debug.Log("草を食べる");
        }
        else if (other.tag == "Food")
        {
            //体力を回復しotherオブジェクトを削除
            foodCount++;
            other.gameObject.SetActive(false);
            Debug.Log("動物に接触");
        }
        else if (other.tag == "Animal_niku")
        {
            life--;
        }
    }
}
