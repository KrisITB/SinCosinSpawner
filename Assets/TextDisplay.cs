using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour {
    public GameObject manager;
    private spawner managerScript;

	// Use this for initialization
	void Start () {
        managerScript = manager.GetComponent<spawner>();

        this.GetComponent<Text>().text = managerScript.scale.ToString();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
