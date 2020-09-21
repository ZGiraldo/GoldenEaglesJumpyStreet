using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;

    // Start is called before the first frame update
    void Start()
    {
        SpawnDelay();
    }

    private void SpawnCar()
    {
        int num = Random.Range(1, 5);
        switch(num)
        {
            case 1:
                Instantiate(car1, transform.position, Quaternion.Euler(-90, 0, 90));
                SpawnDelay();
                break;
            case 2:
                Instantiate(car2, transform.position, Quaternion.Euler(-90, 0, 90));
                SpawnDelay();
                break;
            case 3:
                Instantiate(car3, transform.position, Quaternion.Euler(-90, 0, 90));
                SpawnDelay();
                break;
            case 4:
                Instantiate(car4, transform.position, Quaternion.Euler(-90, 0, 90));
                SpawnDelay();
                break;
            case 5:
                Instantiate(car5, transform.position, Quaternion.Euler(-90, 0, 90));
                SpawnDelay();
                break;
        }
    }
        

    public void SpawnDelay()
    {
        int num = Random.Range(1, 4);
       
        switch(num)
        {
            case 1:
                StartCoroutine(Delay1());
                break;
            case 2:
                StartCoroutine(Delay2());
                break;
            case 3:
                StartCoroutine(Delay3());
                break;
            default:
                Debug.Log("error");
                break;
        }
    }

    IEnumerator Delay1()
    {
        yield return new WaitForSeconds(1.0f);
        SpawnCar();
    }

    IEnumerator Delay2()
    {
        yield return new WaitForSeconds(2.0f);
        SpawnCar();
    }

    IEnumerator Delay3()
    {
        yield return new WaitForSeconds(3.0f);
        SpawnCar();
    }
}
