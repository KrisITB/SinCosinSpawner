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
    private int spawnSpeed;
    private float condensation;


    // Use this for initialization
    void Start() {
        spawnhight = 0.2f;
        lastSpawn = new Vector3(0, 0, 0);
        xAxisShift = 1;
        zAxisShift = 1;
        scale = 0.1f;
        spawnSpeed = 1;
        condensation = 1;
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
                for (int j = 0; j < 2*SpawnSpeed; j++)
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

    public int SpawnSpeed
    {
        get
        {
            return spawnSpeed;
        }

        set
        {
            spawnSpeed = value;
        }
    }

    public float Condensation
    {
        get
        {
            return condensation;
        }

        set
        {
            condensation = value;
        }
    }

    private void spawnuj(int c)
    {
        scale2 = scale;
        floor++;
        xSin = Mathf.Sin(floor * scale2 * Condensation);
        dim2 = Mathf.Cos(floor * scale2 * Condensation);
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
            scale = Mathf.Lerp(scale, newScale, .1f);
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
        if (xAxisShift != xShifter)
        {
            xAxisShift = Mathf.Lerp(xShifter, xAxisShift, 0.01f);
        }
    }

    public float XaxisDisplay()
    {
        return xAxisShift;
    }

    public void ZaxisShifter(float zShifter)
    {
        if (zAxisShift != zShifter)
        {
            zAxisShift = Mathf.Lerp(zShifter, zAxisShift, 0.01f);
        }
    }

    public float ZaxisDisplay()
    {
        return zAxisShift;
    }

    public void SpawnerShifter(float spawnShifter)
    {
        spawnShifter = Mathf.Pow(spawnShifter, 2);
        if (spawnSpeed != spawnShifter)
        {
            spawnSpeed = Mathf.CeilToInt(Mathf.Lerp(spawnSpeed, spawnShifter, .1f));
            //return answer;
        }
        else
        {
            //return !answer;
        }
    }

    public void CondensationShifter(float condensatorShifter)
    {
        //condensatorShifter = Mathf.Pow(condensatorShifter, 2);
        if (condensation != condensatorShifter)
        {
            condensation = Mathf.Lerp(condensatorShifter, condensatorShifter, .01f);
            //return answer;
        }
    }
}
