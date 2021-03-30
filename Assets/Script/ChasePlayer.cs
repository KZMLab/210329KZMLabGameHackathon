using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player)
        {
            Player = GameObject.Find("Player(Clone)");
        }
        if (Player)
        {
            if(Player.transform.position.x > 8.5 && Player.transform.position.x < 20.5){
                transform.position = new Vector3(Player.transform.position.x, transform.position.y, -8.0f);
            }

            if (Player.transform.position.y > 3 && Player.transform.position.y < 25.5)
            {
                transform.position = new Vector3(transform.position.x, Player.transform.position.y, -8.0f);
            }
        }
    }
}
