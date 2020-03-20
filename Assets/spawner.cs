using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawner : MonoBehaviour {

    public GameObject cubeInst;
    public GameObject tata;
    private int floor;
    public float scale;
    private float spawnhight;
    private Vector3 lastSpawn;
    public Color c1;
    private float xAxisShift;
    private float zAxisShift;


    // Use this for initialization
    void Start() {
        spawnhight = 0.2f;
        lastSpawn = new Vector3(0, 0, 0);
        xAxisShift = 1;
        zAxisShift = 1;
    }

    // Update is called once per frame
    private int endLine = 1000;
    private int current = 0;
    private int i = 0;
    void Update() {
        if (i < 10) //100*scale)
        {
            i++;

        } else {
            i = 1;
            if (current < endLine * (1 / Mathf.Pow(scale, 2)))
            {
                cubeInst.transform.localScale = new Vector3(scale, scale, scale);
                for (int j = 0; j < 5; j++)
                {
                    spawnuj(current);
                    current++;
                }
            }
        }
    }

    private Vector3 newTargetSpawn;
    private float xSin;
    private float dim2;
    private float rotationY;
    private float scale2 = 0.2f;
    private void spawnuj(int c)
    {
        scale2 = scale;
        floor++;
        xSin = Mathf.Sin(floor * scale2);
        dim2 = Mathf.Cos(floor * scale2);
        //newTargetSpawn = new Vector3(xSin*scale, floor*scale, dim2*scale);
        newTargetSpawn = new Vector3(xSin * xAxisShift, lastSpawn.y + floor * scale * spawnhight * 0.001f, dim2 * zAxisShift);
        //Debug.Log(spawnhight); // floor * scale * 
        lastSpawn = newTargetSpawn;
        /*
        rotationY += Random.Range(0, 2) * Mathf.PI; //2 * 6.9f;//Debug.Log(rotationY);
        Quaternion roll = Quaternion.Euler(0, rotationY, 0);
        */
        Quaternion roll = Quaternion.Euler(0, 0, 0);
        //GameObject newCube = Instantiate(cubeInst, newTargetSpawn, Quaternion.identity, tata.transform);
        GameObject newCube = Instantiate(cubeInst, newTargetSpawn, roll, tata.transform);
        var cubeRenderer = newCube.GetComponent<Renderer>();
        //Debug.Log(xSin);
        //Debug.Log(dim2);
        /*
        float r = Random.Range(0.01f, 0.99f);//255 *; // (255 / 2) * (xSin + 1);
        float g = Random.Range(0.01f, 0.99f);
        float b = Random.Range(0.01f, 0.99f); //(255 / 2) * (xSin + 1);
        */

        /*
        float r = 255f;
        float g = 255f;
        float b = floor;
        */

        float r = (xSin + 1) / 2;
        float g = (dim2 + 1) / 2;
        float b = (1 - ((xSin + 1) / 2));// * 0.007f / c; //Random.Range(0.01f, 0.99f); //Mathf.Pow((xSin + dim2) / 2,2);

        //Color cToSet = new Color(Mathf.CeilToInt(r), Mathf.CeilToInt(g), Mathf.CeilToInt(b));
        Color cToSet = new Color(r, g, b);
        //Debug.Log("rgb : " + cToSet);
        //Debug.LogWarning("rgb c : " + c1);
        cubeRenderer.material.SetColor("_Color", cToSet); //c1);
    }

    public void ScaleSetter(float newScale)
    {
        bool answer = true;
        if (newScale != scale)
        {
            scale = newScale;
            //return answer;
        }
        else
        {
            //return !answer;
        }
    }
    public void HeightSetter(float newH)
    {
        spawnhight = newH;
    }

    public void XaxisShifter(float xShifter)
    {
        xAxisShift = xShifter;
    }

    public float XaxisDisplay()
    {
        return xAxisShift;
    }

    public void ZaxisShifter(float zShifter)
    {
        zAxisShift = zShifter;
    }

    public float ZaxisDisplay()
    {
        return zAxisShift;
    }
}
