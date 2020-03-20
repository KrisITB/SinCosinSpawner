using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyUp : MonoBehaviour {
    public bool move;
    public float scale = 0.01f;
    public bool cameraRoll;
	// Use this for initialization
	void Start () {
		
	}
    int i = 0;
	// Update is called once per frame
	void Update () {
        if (i < 0)
        {
            i++;
        }
        else
        {
            i = 0;
            if (move)
            {
                //Debug.Log("WOW");
                float y = gameObject.transform.position.y + scale*2.5f;// + Mathf.Pow(scale, 2);
                this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, y, gameObject.transform.position.z);
            }
            if (cameraRoll)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(
                    this.gameObject.transform.rotation.eulerAngles.x,
                    this.gameObject.transform.rotation.eulerAngles.y-scale*100,
                    this.gameObject.transform.rotation.eulerAngles.z
                    );
            }
        }
	}
}
