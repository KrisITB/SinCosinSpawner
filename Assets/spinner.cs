using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinner : MonoBehaviour {
    float rotationX = 0f;
    float rotationY = 0f;
    float rotationZ = 0f;
    Quaternion toBeAdded;
    Vector3 roller;
    // Use this for initialization
    void Start()
    {
        float gate = Random.Range(0, 3);

        if (gate < 1)
        {
            rotationX = 1;//Random.Range(0, 2) * Mathf.PI; //2 * 6.9f;//Debug.Log(rotationY);
        }
        else if (gate < 2)
        {
            rotationY = 1;// Random.Range(0, 2) * Mathf.PI; // * Mathf.PI;
        }
        else
        {
            rotationZ = 1;//Random.Range(0, 2) * Mathf.PI; //* Mathf.PI;
        }
        roller = new Vector3(rotationX, rotationY, rotationZ);
    }
	
	// Update is called once per frame
	void Update () {
        //this.gameObject.transform.rotation = Quaternion.Euler(this.gameObject.transform.rotation.eulerAngles + roller);
    }
}
