using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefab
    public GameObject coinPrefab;
    //cornPrefab
    public GameObject conePrefab;
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //アイテム出現位置記録
    private float itempoint = 0;
	// Use this for initialization
	void Start () {
        //Unityちゃんのオブジェクト取得
        this.unitychan = GameObject.Find("unitychan");
        itempoint = unitychan.transform.position.z+15;
    }
	
	// Update is called once per frame
	void Update () {

        //50mでとっているので、ゴール地点-50にしています。
        if(unitychan.transform.position.z>=itempoint && unitychan.transform.position.z<130-50)
        {
            
            int num = Random.Range(0, 10);
            if (num <= 1)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, itempoint+50);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j < 2; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置：30％車配置:10％なにもなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, itempoint+50 + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, itempoint+50 + offsetZ);
                    }

                }
            }
            itempoint += 15;
            Debug.Log(itempoint);

        }

    }
}
