using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEraser : MonoBehaviour {

    //Camera    
    private GameObject camera;

    // Use this for initialization
    void Start()
    {
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update () {
        if (this.camera.transform.position.z >this.gameObject.transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }
}
