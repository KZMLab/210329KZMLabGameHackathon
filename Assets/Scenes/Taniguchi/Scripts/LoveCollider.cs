using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Animal_kusa")
        {
            //otherオブジェクトを削除
            other.gameObject.SetActive(false);
            Debug.Log("草に接触");
            this.gameObject.SetActive(false);
        }
        else if (other.tag == "Animal_niku")
        {
            //otherオブジェクトを削除
            other.gameObject.SetActive(false);
            Debug.Log("動物に接触");
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
