using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    string myText;
    GameObject gameManager;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        //���g�̃{�^���e�L�X�g�擾
        myText = GetComponentInChildren<Text>().text;
        
    }

    public void onClick()
    {
        switch (myText)
        {
            case "�n�߂�":
                return;
            case "��߂�":
                return;
            case "�Q�[���J�n":
                return;
            case "�߂�":
                return;
            case "�Ē���":
                return;
            case "�^�C�g��":
                return;
        }
    }
}
