using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    string myText;
    GameObject gameManager;
    GameManager gm;
    GameObject bgmSe;
    SoundEffect se;

    // Start is called before the first frame update
    void Start()
    {
        bgmSe = GameObject.Find("BGMandSE");
        se = bgmSe.GetComponent<SoundEffect>();
        //???g???{?^???e?L?X?g????
        myText = GetComponentInChildren<Text>().text;
        //?Q?[???}?l?[?W???[???X?N???v?g????(scene?????????X????)
        gameManager = GameObject.Find("GameManager");
        gm = gameManager.GetComponent<GameManager>();
    }

    public void OnClick()
    {
        se.ButtonPush();
        Debug.Log("Clicked");
        gm.sceneChange = true;
        switch (myText)
        {
            case "Start":
                gm.scene = GameManager.GameScene.HOWTOPLAY;
                break;
            case "Exit":
                UnityEngine.Application.Quit();
                break;
            case "GameStart":
                gm.scene = GameManager.GameScene.GAME;
                gm.InitGame();
                break;
            case "Return":
                gm.scene = GameManager.GameScene.TITLE;
                break;
            case "Retry":
                gm.scene = GameManager.GameScene.GAME;
                gm.terminateGame();
                gm.InitGame();
                break;
            case "Title":
                gm.terminateGame();
                gm.scene = GameManager.GameScene.TITLE;
                break;
        }
    }
}
