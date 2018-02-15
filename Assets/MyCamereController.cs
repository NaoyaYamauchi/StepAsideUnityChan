using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamereController : MonoBehaviour {
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityちゃんとのカメラ距離
    private float difference;
    
    //carPrefab(Clone)を入れる
    public GameObject carPrefabClone;
    //coinPrefab(Clone)
    public GameObject coinPrefabClone;
    //cornPrefab(Clone)
    public GameObject conePrefabClone;

    // Use this for initialization
    void Start () {
        //Unityちゃんのオブジェクト取得
        this.unitychan = GameObject.Find("unitychan");
        //Unityちゃんとカメラの位置（z座標）の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        this.carPrefabClone = GameObject.Find("CarPrefab(Clone)");
        this.coinPrefabClone = GameObject.Find("CoinPrefab(Clone)");
        this.conePrefabClone = GameObject.Find("TrafficConePrefab(Clone)");
        //Unityちゃんの位置に合わせてカメラの位置を移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z-difference);
        Debug.Log(carPrefabClone.transform.position.z);
        if (this.transform.position.z > carPrefabClone.transform.position.z)
        {
            Destroy(this.carPrefabClone);
        }
        if (this.transform.position.z > coinPrefabClone.transform.position.z)
        {
            Destroy(this.coinPrefabClone);
        }
        if (this.transform.position.z > conePrefabClone.transform.position.z)
        {
            Destroy(this.conePrefabClone);
        }

    }
}
