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
        //自身のボタンテキスト取得
        myText = GetComponentInChildren<Text>().text;
        //ゲームマネージャーのスクリプト取得(scene変数を変更する)
        gameManager = GameObject.Find("GameManager");
        gm = gameManager.GetComponent<GameManager>();
    }

    public void OnClick()
    {
        Debug.Log("Clicked");
        gm.sceneChange = true;
        switch (myText)
        {
            case "始める":
                gm.scene = GameManager.GameScene.HOWTOPLAY;
                break;
            case "やめる":
                gm.scene = GameManager.GameScene.GAMEOVER;
                break;
            case "ゲーム開始":
                gm.scene = GameManager.GameScene.GAME;
                break;
            case "戻る":
                gm.scene = GameManager.GameScene.TITLE;
                break;
            case "再挑戦":
                gm.scene = GameManager.GameScene.GAME;
                break;
            case "タイトル":
                gm.scene = GameManager.GameScene.TITLE;
                break;
        }
    }
}
