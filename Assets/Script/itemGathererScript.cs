using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class itemGathererScript : MonoBehaviour
{
    public GameObject itemSpawner;
    private int IDItemsRecherche;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        IDItemsRecherche = itemSpawner.GetComponent<itemSpawnerScript>().idItemArechercher;
        if(other.tag == "item"){
            if(other.GetComponent<itemScript>().ID == IDItemsRecherche){
                if(other.GetComponent<itemScript>().loaded == false){
                    Destroy(other.gameObject);
                    UIScript.joursSurvecus ++;
                    SceneManager.LoadScene("sceneAffichageJours");
                    
                }
                
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        IDItemsRecherche = itemSpawner.GetComponent<itemSpawnerScript>().idItemArechercher;
        if(other.tag == "item"){
            if(other.GetComponent<itemScript>().ID == IDItemsRecherche){
                if(other.GetComponent<itemScript>().loaded == false){
                    Destroy(other.gameObject);
                    UIScript.joursSurvecus ++;
                    SceneManager.LoadScene("sceneAffichageJours");
                }
                
            }
        }
    }
}
