using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    [SerializeField] private int terrainCounterNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        terrainCounterNum = ProceduralGenerator.TerrainCounter;
    }

    public void Update()
    {
        if (terrainCounterNum + ProceduralGenerator.TerrainLimitStatic == ProceduralGenerator.TerrainCounter - 1)
        {
            Destroy(gameObject);
        }
    }
}
