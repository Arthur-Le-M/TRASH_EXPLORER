using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    public Transform borneDroite;
    public Transform borneGauche;
    public List<GameObject> listeItems;
    private int itemAuHasard;
    private float currentTime;
    public float spawnRate;
    private GameObject itemInstancied;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1*Time.deltaTime;
        if(currentTime <= 0){
            itemAuHasard = Random.Range(0, listeItems.Count);
            itemInstancied = Instantiate(listeItems[itemAuHasard], new Vector3(Random.Range(borneGauche.position.x, borneDroite.position.x), transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(itemInstancied, 3f);
            currentTime = spawnRate;
        }
    }
}
