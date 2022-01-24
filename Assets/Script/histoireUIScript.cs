using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class histoireUIScript : MonoBehaviour
{
    public GameObject panelHistoire;
    public GameObject panelTuto;
    private bool gameReady;
    // Start is called before the first frame update
    void Start()
    {
        gameReady = false;
        panelTuto.SetActive(false);
        panelHistoire.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(gameReady == false){
                panelHistoire.SetActive(false);
                panelTuto.SetActive(true);
                gameReady = true;
            }
            else{
                SceneManager.LoadScene("sceneAffichageJours");
            }
        }
    }
}
