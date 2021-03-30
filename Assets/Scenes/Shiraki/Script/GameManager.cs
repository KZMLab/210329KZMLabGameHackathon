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

    /*�}�b�v*/
    public GameObject Map;
    /*------*/

    /*�v���C���[ NPC*/
    public GameObject Player;
    public GameObject Animal_kusa;
    public GameObject Animal_niku;
    private ArrayList Animals_kusa = new ArrayList();
    private ArrayList Animals_niku = new ArrayList();
    /*--------------*/

    bool unko = true;

    [HideInInspector] public GameScene scene; //�Q�[���V�[���Ǘ��ϐ�

    [HideInInspector] public bool enableControll; //���[�U�̑�����󂯕t���邩�ǂ���

    [HideInInspector] public bool sceneChange; //�V�[�����ω��������ǂ���

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�X�^�[�g\n");
        scene = GameScene.TITLE;

        Title = GameObject.Find("TitleScreen");
        Title.SetActive(true);

        HowToPlay = GameObject.Find("HowToPlayScreen");
        HowToPlay.SetActive(false);

        GameOver = GameObject.Find("GameOverScreen");
        GameOver.SetActive(false);

        enableControll = true; //����\

        sceneChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (scene)
        {
            case GameScene.TITLE:
                SetScene(scene);
                /*�^�C�g������*/

                /*------------*/
                Debug.Log("�^�C�g������\n");
                break;
            case GameScene.HOWTOPLAY:
                SetScene(scene);
                /*�����������*/

                /*------------*/
                Debug.Log("�����������\n");
                break;
            case GameScene.GAME:
                SetScene(scene);
                /*�Q�[������*/
                if (unko) InitGame();
                unko = false;
                updateGame();
                /*----------*/
                Debug.Log("�Q�[������\n");
                break; 
            case GameScene.GAMEOVER:
                SetScene(scene);
                /*�Q�[���I�[�o�[����*/

                /*------------------*/
                Debug.Log("�Q�[���I�[�o�[����\n");
                break;
        }
    }

    //�{�^���֐��ŌĂяo��
    void SetScene(GameScene tmpScene)
    {
        if (sceneChange) //�V�[���ύX�t���O�������Ă��邩
        {
            for (int i = 0; i < SceneCount; i++)
            {
                switch (tmpScene)
                {
                    case GameScene.TITLE:
                        Title.SetActive(true);
                        HowToPlay.SetActive(false);
                        GameOver.SetActive(false);
                        break;
                    case GameScene.HOWTOPLAY:
                        Title.SetActive(false);
                        HowToPlay.SetActive(true);
                        GameOver.SetActive(false);
                        break;
                    case GameScene.GAME:
                        Title.SetActive(false);
                        HowToPlay.SetActive(false);
                        GameOver.SetActive(false);
                        break;
                    case GameScene.GAMEOVER:
                        Title.SetActive(false);
                        HowToPlay.SetActive(false);
                        GameOver.SetActive(true);
                        break;
                }
            }
            //�V�[���ύX�I��
            sceneChange = false;
        }
    }

    //�Q�[��������
    void InitGame()
    {
        //�����̔z�u
        positionAnimals();
    }

    void positionAnimals()
    {
            Instantiate(Animal_kusa, new Vector3(15.0f, 15.0f, -1.0f), Quaternion.identity);
            Instantiate(Animal_niku, new Vector3(18.0f, 15.0f, -1.0f), Quaternion.identity);
    }

    //�Q�[���X�V
    void updateGame()
    {

    }
}
