using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacleVariations = new List<GameObject>();
    [SerializeField] private List<bool> ocuppiedPos = new List<bool>();

    private int randomAmount = 0;


    void Start()
    {
        randomAmount = Random.Range(7, 11); //Amount of obstacles per Terrain

        for(int i = 0; i < randomAmount; i++)
        {
            int randomXPos = Random.Range(0, 20); //the max for randomXPos should be the X scale of the terrains

            if (!ocuppiedPos[randomXPos])
            {
                ocuppiedPos[randomXPos] = true;
                Instantiate(obstacleVariations[Random.Range(0, obstacleVariations.Count)], new Vector3(randomXPos - 9.5f, 1, transform.position.z), Quaternion.Euler(-90,0,0), transform); // subtract (randomXPos/2 - .5) from randomXPos
            }
            else
            {
                i--;
            }
        }

    }

    void Update()
    {
        
    }
}
