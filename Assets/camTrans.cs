using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camTrans : MonoBehaviour {
    public Texture2D photo;
    public GameObject BuildingBlock;
    private Vector3 newTargetSpawn;
    public GameObject tata2;
    public int total;
    public int currentOn;
    int row;
    int col;
    float scale = 1f;

    void Start()
    {
        Debug.Log(photo.width);
        Debug.Log(photo.height);

        currentOn = 0;
        total = photo.width * photo.height;

        Debug.Log(photo.GetPixel(1, 1));
        newTargetSpawn = new Vector3(0, 0, 100);

        BuildingBlock.transform.localScale = new Vector3(scale, scale, scale);
    }

    private void spawnuj()
    {   
        if(row < photo.height)
        {
            if(col < photo.width)
            {
                newTargetSpawn = new Vector3(col, row, 100);
                var r = photo.GetPixel(col, row).r;
                var g = photo.GetPixel(col, row).g;
                var b = photo.GetPixel(col, row).b;
                GameObject newCube = Instantiate(BuildingBlock, newTargetSpawn, Quaternion.identity, tata2.transform);
                var cubeRenderer = newCube.GetComponent<Renderer>();
                Color cToSet = new Color(r, g, b);
                cubeRenderer.material.SetColor("_Color", cToSet); //c1);
                //Debug.Log(photo.GetPixel(j, i));
                col++;
            }
            else
            {
                row++;
                col=0;
            }
        }
        else
        {
            row++;
            col++;
        }
        currentOn++;
        /*
        for (int i = 0; i < photo.width; i++)
        {// columns
            for (int j = 0; j < photo.height; j++)
            {
                
            }
            currentOn++;
        }
        
        //newTargetSpawn = new Vector3(xSin * xAxisShift, lastSpawn.y + floor * scale * spawnhight * 0.001f, dim2 * zAxisShift);
        */
    }

        // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 10000; i++)
        {
            if(currentOn < total)
            {
                spawnuj();
            }
        }
    }
}
