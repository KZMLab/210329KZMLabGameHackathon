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
            //other�I�u�W�F�N�g���폜
            other.gameObject.SetActive(false);
            Debug.Log("���ɐڐG");
            this.gameObject.SetActive(false);
        }
        else if (other.tag == "Animal_niku")
        {
            //other�I�u�W�F�N�g���폜
            other.gameObject.SetActive(false);
            Debug.Log("�����ɐڐG");
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
