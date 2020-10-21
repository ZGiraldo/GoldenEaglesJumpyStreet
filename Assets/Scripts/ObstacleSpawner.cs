using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();

    [SerializeField] int spawnerRotation = 0; //should be either 90 or 270
    [SerializeField] float spawnDelay1 = .5f;
    [SerializeField] float spawnDelay2 = 2;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCar();
    }

    private void SpawnCar()
    {
        int num = Random.Range(0, obstacles.Count);

        Instantiate(obstacles[num], transform.position, Quaternion.Euler(-90, 0, spawnerRotation), gameObject.transform);
        SpawnDelay();
    }
        

    public void SpawnDelay()
    {
        float num = Random.Range(spawnDelay1, spawnDelay2);

        StartCoroutine(Delay(num));
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        SpawnCar();
    }
}
