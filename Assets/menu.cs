using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {

    public GameObject camera1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void MoveSwitch()
    {
        camera1.GetComponent<flyUp>().move = !camera1.GetComponent<flyUp>().move;
    }

    public void RollSwitch()
    {
        camera1.GetComponent<flyUp>().cameraRoll = !camera1.GetComponent<flyUp>().cameraRoll;
    }
}
