using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public enum GameScene
    {
        TITLE,
        HOWTOPLAY,
        GAME,
        GAMEOVER,
    }
    [HideInInspector] public int SceneCount = 4;

    /*UI*/
    private GameObject Title;
    private GameObject HowToPlay;
    private GameObject Game;
    private GameObject GameOver;
    /*--*/

    /*マップ*/
    public GameObject Map;
    /*------*/

    /*プレイヤー NPC*/
    public GameObject Player;
    public GameObject Animal_kusa;
    public GameObject Animal_niku;
    private ArrayList Animals_kusa = new ArrayList();
    private ArrayList Animals_niku = new ArrayList();
    /*--------------*/

    bool unko = true;

    [HideInInspector] public GameScene scene; //ゲームシーン管理変数

    [HideInInspector] public bool enableControll; //ユーザの操作を受け付けるかどうか

    [HideInInspector] public bool sceneChange; //シーンが変化したかどうか

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("スタート\n");
        scene = GameScene.TITLE;

        Title = GameObject.Find("TitleScreen");
        Title.SetActive(true);

        HowToPlay = GameObject.Find("HowToPlayScreen");
        HowToPlay.SetActive(false);

        Game = GameObject.Find("GameUI");
        Game.SetActive(false);

        GameOver = GameObject.Find("GameOverScreen");
        GameOver.SetActive(false);

        enableControll = true; //操作可能

        sceneChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (scene)
        {
            case GameScene.TITLE:
                SetScene(scene);
                /*タイトル処理*/

                /*------------*/
                Debug.Log("タイトル処理\n");
                break;
            case GameScene.HOWTOPLAY:
                SetScene(scene);
                /*操作説明処理*/

                /*------------*/
                Debug.Log("操作説明処理\n");
                break;
            case GameScene.GAME:
                SetScene(scene);
                /*ゲーム処理*/
                updateGame();
                /*----------*/
                Debug.Log("ゲーム処理\n");
                break; 
            case GameScene.GAMEOVER:
                SetScene(scene);
                /*ゲームオーバー処理*/

                /*------------------*/
                Debug.Log("ゲームオーバー処理\n");
                break;
        }
    }

    //ボタン関数で呼び出す
    void SetScene(GameScene tmpScene)
    {
        if (sceneChange) //シーン変更フラグが立っているか
        {
            for (int i = 0; i < SceneCount; i++)
            {
                switch (tmpScene)
                {
                    case GameScene.TITLE:
                        Title.SetActive(true);
                        HowToPlay.SetActive(false);
                        Game.SetActive(false);
                        GameOver.SetActive(false);
                        break;
                    case GameScene.HOWTOPLAY:
                        Title.SetActive(false);
                        HowToPlay.SetActive(true);
                        Game.SetActive(false);
                        GameOver.SetActive(false);
                        break;
                    case GameScene.GAME:
                        Title.SetActive(false);
                        HowToPlay.SetActive(false);
                        Game.SetActive(true);
                        GameOver.SetActive(false);
                        break;
                    case GameScene.GAMEOVER:
                        Title.SetActive(false);
                        HowToPlay.SetActive(false);
                        Game.SetActive(false);
                        GameOver.SetActive(true);
                        break;
                }
            }
            //シーン変更終了
            sceneChange = false;
        }
    }

    //ゲーム初期化
    public void InitGame()
    {
        //プレイヤーの配置
        Player = Instantiate(Player, new Vector3(15.0f, 15.0f, -1.0f), Quaternion.identity);
        //動物の配置
        for (int i = 0; i < 10; i++)
        {
            Animals_kusa.Add(Instantiate(Animal_kusa, new Vector3(Random.Range(2, 29), Random.Range(2, 29), -1.0f), Quaternion.identity));
            Animals_niku.Add(Instantiate(Animal_niku, new Vector3(Random.Range(2, 29), Random.Range(2, 29), -1.0f), Quaternion.identity));
        }
    }

    //ゲーム更新
    void updateGame()
    {

    }

    public void terminateGame()
    {
        //プレイヤーの削除
        Destroy(Player);
        //動物の削除
        for(int i = 0;i < Animals_kusa.Count; i++)
        {
            Destroy((Object)Animals_kusa[i]);
        }
        for(int i = 0;i < Animals_niku.Count; i++)
        {
            Destroy((Object)Animals_niku[i]);
        }

    }
}
