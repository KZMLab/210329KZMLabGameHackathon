using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveTime = 0.1f;
    public float speed = 0.05f;

    public int pointsPerGrass = 10; //���̉񕜗�
    public int pointsPerMeet = 20; //���̉񕜗�

    [HideInInspector]public int life = 1; //player�̗̑�
   
    [HideInInspector] public int foodCount = 0; //�������邦���̐�
    [HideInInspector] public int kusa_num = 0; //�������H�����̐�
    [HideInInspector] public int niku_num = 0; //�������H�����̐�

    private Animator animator;

    Vector3 preMousePos;

    private BoxCollider2D boxcollider;
    private Rigidbody2D rb2D;
    //moveTime���v�Z����̂�P�������邽�߂̕ϐ�
    private float inverseMoveTime;

    public GameObject target;
    public GameObject target2;

    private bool isPressed = false;
    private bool isPressed2 = false;

    /////////////////////////////////////////////////////////////////////////@notsumata
    private float x = 0.0f;
    private float y = 0.0f;
    Vector3 prevPos;
    /////////////////////////////////////////////////////////////////////////@notsumata

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
        /////////////////////////////////////////////////////////////////////////@notsumata
        // 自身の向きベクトル取得
        if(this.transform.position.x != prevPos.x || this.transform.position.y != prevPos.y)
        {
            x = this.transform.position.x - prevPos.x;
            y = this.transform.position.y - prevPos.y;
        }

        Vector2 vec = new Vector2 (x, y).normalized;

        float rot = Mathf.Atan2 (vec.y, vec.x) ;

        prevPos = this.transform.position;
        /////////////////////////////////////////////////////////////////////////@notsumata

        Move();
        if (Input.GetKeyDown(KeyCode.Q) && !isPressed)
        {
            isPressed = true;
            Love();
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isPressed2)
        {
            isPressed2 = true;
            Feed(rot);
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

    void Feed(float rot)
    {
        if (foodCount > 0)
        {
            foodCount--;
            // Vector3 newItemPos = this.gameObject.transform.position + new Vector3(3.0f, 2.0f, 0);

            // Instantiate(target, newItemPos, Quaternion.identity);

            /////////////////////////////////////////////////////////////////////////@notsumata
            Instantiate(target,
                        new Vector3(this.transform.position.x + Mathf.Cos(rot)*3,
                                    this.transform.position.y + Mathf.Sin(rot)*3,
                                    this.transform.position.z),
                        Quaternion.identity);
            /////////////////////////////////////////////////////////////////////////@notsumata

            animator.SetTrigger("PlayerFeed");

            isPressed2 = false;
        }
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
            //�̗͂��񕜂�other�I�u�W�F�N�g���폜
            other.gameObject.SetActive(false);
            Debug.Log("����H�ׂ�");
        }
        else if (other.tag == "Food")
        {
            //�̗͂��񕜂�other�I�u�W�F�N�g���폜
            foodCount++;
            other.gameObject.SetActive(false);
            Debug.Log("�����ɐڐG");
        }
        else if (other.tag == "Animal_niku")
        {
            life--;
        }
    }
}
