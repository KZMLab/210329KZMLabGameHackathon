using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    // カウント用クラスを設定
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    };

    // 縦の列、横の列のタイル数を設定
    public int columns = 20;
    public int rows = 20;

    // grassは3個出る
    public int grassCount = 3;
    // foodは3個出る
    public int foodCount = 3;

    public GameObject[] floorTiles;
    public GameObject[] outerWallTiles;
    public GameObject foodTile;
    public GameObject grassTile;

		// 今存在するgrassをカウントするための変数
		private int existGrass = 0;
		// 今存在するfoodをカウントするための変数
		private int existFood = 0;

    // オブジェクトの位置情報を保存する変数
	private Transform boardHolder;

    //オブジェクトを配置できる範囲を表すリスト
	private List <Vector3> gridPositions = new List<Vector3>();

    // 配置できる範囲を決定
	void InitialiseList ()
	{
		//gridPositionをクリア
		gridPositions.Clear ();
		//gridPositionにオブジェクト配置可能範囲を指定
		//x = 1〜10をループ
		for (int x = 1; x < columns - 1; x++) {
			//y = 1〜10をループ
			for (int y = 1; y < rows - 1; y++) {
				//10*10の範囲をgridPositionsに指定
				gridPositions.Add(new Vector3(x, y, 0f));
			}
		}
	}

    //外壁、床を配置
	void BoardSetup ()
    {
		//Boardというオブジェクトを作成し、transform情報をboardHolderに保存
		boardHolder = new GameObject ("Board").transform;
		//x = -1〜11をループ
		for (float x = -1; x < columns + 1; x++) 
        {
			//y = -1〜11をループ
			for (float y = -1; y < rows + 1; y++) 
            {
				//床をランダムで選択
				GameObject toInstantiate = floorTiles [Random.Range (0, floorTiles.Length)];
				//左端or右端or最低部or最上部の時＝外壁を作る時
				if (x == -1 || x == columns || y == -1 || y == rows) {
					//floorTileの時と同じように外壁をランダムで選択し、上書きする
					toInstantiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];
				}
				//床or外壁を生成し、instance変数に格納
				GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f),
					Quaternion.identity) as GameObject;
				//生成したinstanceをBoardオブジェクトの子オブジェクトとする
				instance.transform.SetParent(boardHolder);
			}
		}
	}

    Vector3 RandomPosition () 
    {
		//ランダムで1つ決定し、位置情報を確定
		int randomIndex = Random.Range(0, gridPositions.Count);
		Vector3 randomPosition = gridPositions[randomIndex];
		//ランダムで決定した数値は削除
		gridPositions.RemoveAt(randomIndex);
		//確定した位置情報を返す
		return randomPosition;
	}

	void LayoutObjectAtRandom (GameObject tile, int count)
	{
		for (int i = 0; i < count; i++) {
			//gridPositionから位置情報を１つ取得
			Vector3 randomPosition = RandomPosition();
			//引数tileArrayからランダムで1つ選択
			// GameObject tileChoise = tileArray[Random.Range(0, tileArray.Length)];
			GameObject tileChoise = tile;
			//ランダムで決定した位置でオブジェクトを生成
			Instantiate (tileChoise, randomPosition, Quaternion.identity);

			if(tileChoise == foodTile)existFood++;
			else if(tileChoise == grassTile)existGrass++;
		}
	}

    //オブジェクトを配置していくメソッド
	// 床を生成するタイミングでGameManagerから呼ばれる
	public void SetupScene (int level)
	{
		//床と外壁を配置し、
		BoardSetup();
		//配置できる位置を決定し、
		InitialiseList();
		//内壁・アイテム・敵キャラをランダムで配置し、
		LayoutObjectAtRandom(foodTile, foodCount);
		LayoutObjectAtRandom(grassTile, grassCount);
		//Mathf.Log : 対数で計算。level=2なら4、level=3なら8
		// int enemyCount = (int)Mathf.Log(level, 2f);
		// LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);
		//Exitを7, 7の位置に配置する。
		// Instantiate(exit, new Vector3(columns - 1, rows - 1, 0F), Quaternion.identity);
	}

    void Awake()
    {
        SetupScene(0);
				// Debug.Log(existFood + " , " +existGrass);
    }

		void Update()
		{
			// if()
		}
}
