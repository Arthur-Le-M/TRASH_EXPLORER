using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawnerScript : MonoBehaviour
{
    public List<GameObject> listeItems;
    public GameObject itemRecherche;
    public int nbRecherche;
    public int nbItemsASpawn;

    public int idItemArechercher;
    private int itemAuHasard;
    private bool isSpawn;
    // Start is called before the first frame update
    void Start()
    {
        //Choix des items à rechercher
        idItemArechercher = Random.Range(0, listeItems.Count);
        itemRecherche = listeItems[idItemArechercher];
        isSpawn = false;

        //Spawn des objets
        for(int i=0; i < nbItemsASpawn; i++){
            while(true){
                itemAuHasard = Random.Range(0, listeItems.Count);
                if(itemAuHasard == idItemArechercher){
                    if(isSpawn == false){
                        isSpawn = true;
                        break;
                    }
                }
                else{
                    break;
                }
            }
            Instantiate(listeItems[itemAuHasard], transform.position, Quaternion.identity);
        }
        if(isSpawn == false){
            Instantiate(listeItems[idItemArechercher], transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
