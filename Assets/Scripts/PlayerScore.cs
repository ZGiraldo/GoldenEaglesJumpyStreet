using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] ProceduralGenerator procedGenerator = null;
    [SerializeField] Text playerScoreText = null;

    private int playerScoreCounter = -1;
    private int dividerCounter = -3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Terrain" || other.tag == "Divider")
        {
            playerScoreCounter++;
            playerScoreText.text = playerScoreCounter.ToString();
            other.enabled = false;
        }

        if(other.tag == "Divider")
        {
            if (dividerCounter > 0)
            {
                procedGenerator.TrackTerrain();
            }
            else
            {
                dividerCounter++;
            }

        }

        if(other.tag == "Death")
        {
            Destroy(gameObject);
        }
    }
}
