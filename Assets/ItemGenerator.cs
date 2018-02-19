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
    private int itempoint = 0;
    //i
    private int count = 0;
    //unitychanの絶対値
    private int unitychandefault = 0;
	// Use this for initialization
	void Start () {
        //Unityちゃんのオブジェクト取得
        this.unitychan = GameObject.Find("unitychan");
        count = startPos;
        unitychandefault = System.Math.Abs((int)unitychan.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {

        itempoint = (int)unitychan.transform.position.z+unitychandefault;
        //Debug.Log(itempoint);
        if(itempoint%15 == 0 &&itempoint < goalPos-15)
        {
            
            int num = Random.Range(0, 10);
            if (num <= 1)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, count);
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
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, count + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, count + offsetZ);
                    }

                }
            }
            count += 15;

        }
        Debug.Log(count);

    }
}
