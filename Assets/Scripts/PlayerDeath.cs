using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] GameObject waterDeathEffect;
    [SerializeField] GameObject carDeathEffectOne;
    [SerializeField] GameObject carDeathEffectTwo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")//destroy player and end game, play a sound
        {
            FindObjectOfType<AudioManager>().Play("Death");
        }

        if (other.tag == "Water")//play a sound and trigger particle effect
        {
            GenerateDeathEffect(waterDeathEffect, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z));
            FindObjectOfType<AudioManager>().Play("Water");
        }

        if (other.tag == "Car")//kill player, play sound effect, trigger particle affect
        {
            GenerateDeathEffect(carDeathEffectOne, transform.position);
            GenerateDeathEffect(carDeathEffectTwo, transform.position);
            FindObjectOfType<AudioManager>().Play("Pop");
        }

        void GenerateDeathEffect(GameObject deathEffect, Vector3 location)
        {
            GameObject tempEffect = (GameObject)Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(tempEffect, 10f);
        }
    }
}
