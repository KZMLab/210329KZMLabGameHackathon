using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//この関数を呼び出すだけで音がなるようにしている．
//そのため，なにかトリガーがあればそこで呼び出してください
public class SoundEffect : MonoBehaviour
{
    public AudioClip ClickSound;
    public AudioClip GetItemSound;
    public AudioClip AnimalKusaSound;
    public AudioClip AnimalNikuSound;

    AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    

    //ボタンを押したとき用
    void ButtonPush()
    {
        audioSource.PlayOneShot(ClickSound);
    }

    void GetItem()
    {
        audioSource.PlayOneShot(GetItemSound);
    }

    void AnimalKusa()
    {
        audioSource.PlayOneShot(AnimalKusaSound);
    }

    void AnimalNiku()
    {
        audioSource.PlayOneShot(AnimalNikuSound);
    }
}
