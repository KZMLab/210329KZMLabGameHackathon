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
        //�Q�[���}�l�[�W���[�̃X�N���v�g�擾(scene�ϐ���ύX����)
        gameManager = GameObject.Find("GameManager");
        gm = gameManager.GetComponent<GameManager>();
    }

    public void OnClick()
    {
        Debug.Log("Clicked");
        gm.sceneChange = true;
        switch (myText)
        {
            case "Start":
                gm.scene = GameManager.GameScene.HOWTOPLAY;
                break;
            case "Exit":
                gm.scene = GameManager.GameScene.GAMEOVER;
                break;
            case "GameStart":
                gm.scene = GameManager.GameScene.GAME;
                break;
            case "Return":
                gm.scene = GameManager.GameScene.TITLE;
                break;
            case "Retry":
                gm.scene = GameManager.GameScene.GAME;
                break;
            case "Title":
                gm.scene = GameManager.GameScene.TITLE;
                break;
        }
    }
}
