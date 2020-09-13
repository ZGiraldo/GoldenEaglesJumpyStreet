using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> terrains = new List<GameObject>();

    [SerializeField] private int terrainLimit = 0;
    private static int terrainLimitStatic = 0;

    private int terrainSpawned = 0;
    private float zPosition = 1;


    private static int terrainCounter = 0;
    // Start is called before the first frame update

    public static int TerrainCounter
    {
        get
        {
            return terrainCounter;
        }

        set
        {
            terrainCounter = value;
        }
    }

    public static int TerrainLimitStatic
    {
        get
        {
            return terrainLimitStatic;
        }

        set
        {
            terrainCounter = value;
        }
    }


    void Start()
    {
        terrainLimitStatic = terrainLimit;
        Instantiate(terrains[0], new Vector3(0,0,.5f), Quaternion.identity);
        GenerateTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            terrainSpawned--;
            GenerateTerrain();
        }
    }

    private void GenerateTerrain()
    {
        while(terrainSpawned < terrainLimit)
        {
            int randomTerrain = Random.Range(1, 3);

            if(randomTerrain == 1)
            {
                GenerateRiver();
            }
            
            if(randomTerrain == 2)
            {
                GenerateStreet();
            }

            GenerateDivider();
            

            terrainCounter++;
            terrainSpawned++;
        }
    }

    private void GenerateStreet() //for now the addition to zPosition will be hard coded, make it for flexible later*****
    {
        zPosition++;
        Instantiate(terrains[1], new Vector3(0, 0, zPosition), Quaternion.identity);
        zPosition++;
    }

    private void GenerateDivider()
    {
        zPosition += .5f;
        Instantiate(terrains[0], new Vector3(0, 0, zPosition), Quaternion.identity);
        zPosition += .5f;
    }

    private void GenerateRiver()
    {
        zPosition += 1.5f;
        Instantiate(terrains[2], new Vector3(0, 0, zPosition), Quaternion.identity);
        zPosition += 1.5f;
    }
}
