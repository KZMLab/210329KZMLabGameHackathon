using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameScene
    {
        TITLE,
        HOWTOPLAY,
        GAME,
        GAMEOVER,
    }
    public int SceneCount = 4;

    /*UI*/
    GameObject Title;
    GameObject HowToPlay;
    GameObject Game;
    GameObject GameOver;
    /*--*/

    public GameScene scene; //�Q�[���V�[���Ǘ��ϐ�

    bool enableControll; //���[�U�̑�����󂯕t���邩�ǂ���

    public bool sceneChange; //�V�[�����ω��������ǂ���

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
                scene = GameScene.GAMEOVER; //���͂Ƃ肠�����Q�[���I�[�o�[
                sceneChange = true;
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
}
