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
        
    }

    public void onClick()
    {
        switch (myText)
        {
            case "始める":
                return;
            case "やめる":
                return;
            case "ゲーム開始":
                return;
            case "戻る":
                return;
            case "再挑戦":
                return;
            case "タイトル":
                return;
        }
    }
}
