using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
		GameObject[] grassObjects;
		GameObject[] foodObjects;

    private float foodTimer = 0.0f;
    public float foodInterval = 3.0f;
		private float grassTimer = 0.0f;
		public float grassInterval = 3.0f;

    // // カウント用クラスを設定
    // public class Count
    // {
    //     public int minimum;
    //     public int maximum;

    //     public Count(int min, int max)
    //     {
    //         minimum = min;
    //         maximum = max;
    //     }
    // };

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
		}
	}

    //オブジェクトを配置していくメソッド
	// 床を生成するタイミングでGameManagerから呼ばれる
	public void SetupScene (int level)
	{
		//床と外壁を配置
		BoardSetup();
		// リストの初期化
		InitialiseList();
		//アイテムをランダムで配置
		LayoutObjectAtRandom(foodTile, foodCount);
		LayoutObjectAtRandom(grassTile, grassCount);
	}

    void Awake()
    {
        SetupScene(0);
    }

		void Update()
		{
			if(gridPositions.Count <= grassCount + foodCount)
			{
				InitialiseList();
				for(int i=0; i < grassObjects.Length; i++)
				{
					Debug.Log(grassObjects[0].transform.position.x);
					gridPositions.Remove(new Vector3(grassObjects[i].transform.position.x,
																						grassObjects[i].transform.position.y,
																						grassObjects[i].transform.position.z));
				}
				for(int j=0; j < foodObjects.Length; j++)
				{
					Debug.Log(foodObjects[0].transform.position.x);
					gridPositions.Remove(new Vector3(foodObjects[j].transform.position.x,
																						foodObjects[j].transform.position.y,
																						foodObjects[j].transform.position.z));
				}
			}


			// grassの数が設定数より少なければ増やす処理
			if(CheckGrass())
			{
				grassTimer += Time.deltaTime;
				// Debug.Log("grass: " + grassTimer);
				if(grassTimer > grassInterval)
				{
					LayoutObjectAtRandom(grassTile, 1);
					grassTimer = 0;
				}
			}

			// foodの数が設定数より少なければ増やす処理
			if(CheckFood())
			{
				foodTimer += Time.deltaTime;
				// Debug.Log("food: " + foodTimer);
				if(foodTimer > foodInterval)
				{
					LayoutObjectAtRandom(foodTile, 1);
					foodTimer = 0;
				}
			}
		}

		private bool CheckGrass()
		{
			grassObjects = GameObject.FindGameObjectsWithTag("grass");
			// Debug.Log(tagObjects.Length);
			if(grassObjects.Length < grassCount)
			{
				return true;
			}
			return false;
		}

		private bool CheckFood()
		{
			foodObjects = GameObject.FindGameObjectsWithTag("Food");
			// Debug.Log(tagObjects.Length);
			if(foodObjects.Length < foodCount)
			{
				return true;
			}
			return false;
		}
}
