using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketSpawnerScript : MonoBehaviour
{
    private float currentTime;
    public float spawnFrequence;
    public Transform borneGauche;
    public Transform borneDroite;
    public GameObject rocket;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = spawnFrequence;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime  -= 1 * Time.deltaTime;
        if(currentTime <= 0f){
            spawnRocket();
            currentTime = spawnFrequence;
        }
    }

    void spawnRocket(){
        Instantiate(rocket, new Vector3(Random.Range(borneGauche.position.x, borneDroite.position.x), transform.position.y, transform.position.z), Quaternion.identity);
    }
}
