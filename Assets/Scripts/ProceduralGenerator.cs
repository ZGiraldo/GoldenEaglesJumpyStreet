using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> dividerVariations = new List<GameObject>();
    [SerializeField] List<GameObject> riverVariations = new List<GameObject>();
    [SerializeField] List<GameObject> roadVariations = new List<GameObject>();

    [SerializeField] private int terrainLimit = 0;
    private static int terrainLimitStatic = 0;

    private int terrainSpawned = 0;
    private float zPosition = 4;


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
        Instantiate(dividerVariations[1], new Vector3(0,0,1), Quaternion.identity, gameObject.transform);
        GenerateTerrain();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TrackTerrain()
    {
        terrainSpawned--;
        GenerateTerrain();
    }

    private void GenerateTerrain()
    {
        while(terrainSpawned < terrainLimit)
        {
            int randomTerrain = Random.Range(0, 2);

            GenerateRiverOrRoad(randomTerrain);
            GenerateDivider();

            terrainCounter++;
            terrainSpawned++;
        }
    }

    private void GenerateDivider()
    {
        zPosition += .5f;
        Instantiate(dividerVariations[0], new Vector3(0, 0, zPosition), Quaternion.identity, gameObject.transform);
        zPosition += .5f;
    }

    private void GenerateRiverOrRoad(int random)
    {

        if(random == 0)
        {
            int randomVariation = Random.Range(0, roadVariations.Count);
            zPosition += randomVariation + 1f;
            Instantiate(roadVariations[randomVariation], new Vector3(0, 0, zPosition), Quaternion.identity, gameObject.transform);
            zPosition += randomVariation + 1f;
        }
        else
        {
            zPosition += 1.5f;
            Instantiate(riverVariations[Random.Range(0,riverVariations.Count)], new Vector3(0, 0, zPosition), Quaternion.identity, gameObject.transform);
            zPosition += 1.5f;
        }
    }
}
