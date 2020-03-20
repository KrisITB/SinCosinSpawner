using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class math : MonoBehaviour {
    private Vector3 vec1;

    public Transform target1;
    private Vector3 newTarget;

    public GameObject target;
    private Quaternion target4;

    private Vector4 vec4;
    public Quaternion rotationTarget;
    public Quaternion changingTarget;
    private int i;

    void Start () {
        vec1 = new Vector3(0, 1, 1);
        vec4 = new Vector4(1, 0, 0, 0.001f);
        target4 = target.GetComponent<Transform>().rotation;
        rotationTarget = new Quaternion(vec4.x, vec4.y, vec4.z, vec4.w);
        //newTarget = target1.position + vec1;
    }
	
	// Update is called once per frame
	void Update () {
        //newTarget = newTarget + vec1;
        if (i < 1000)
            i++;
        else
            i=0;
            //target4 = target4 * rotationTarget;
            target.GetComponent<Transform>().rotation = sinusoidaln(rotationTarget); //target.GetComponent<Transform>().rotation +
            Debug.Log(target.GetComponent<Transform>().rotation);    
        //Debug.Log(target4);
        //target.GetComponent<Transform>().position = newTarget;
    }


    Quaternion sinusoidaln(Quaternion input)
    {
        Vector4 vec4v2 = new Vector4(input.x,input.y,input.z,input.w);
        float x = vec4v2.x;
        float y = vec4v2.y;
        float z = vec4v2.z;
        float w = vec4v2.w;
        // x = Mathf.Sin(x);
        // x = Mathf.Pow(x, 2);
        // y = Mathf.Sin(y);
        vec4v2 = new Vector4( x, y, z, w);
        //return new Quaternion(vec4v2.x, vec4v2.y, vec4v2.z, vec4v2.w);
        return rotationTarget;
        //changingTarget + target4
        //return 
    }

}
