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
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -8.0f);
        }
    }
}
