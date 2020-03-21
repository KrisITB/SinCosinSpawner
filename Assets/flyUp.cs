using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyUp : MonoBehaviour {
    public bool move;
    public float scale = 0.01f;
    public bool cameraRoll;
    private float speedConst;
    // Use this for initialization
    void Start () {
        speedConst = 0f;

    }
    int i = 0;

    public float SpeedConst
    {
        get
        {
            return speedConst;
        }

        set
        {
            speedConst = value;
        }
    }

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
                float y = gameObject.transform.position.y + Mathf.Pow(speedConst, 3) ;//scale*2.5f;// + Mathf.Pow(scale, 2);
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
