using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public GameObject itemSpawner;
    public GameObject panelPause;
    public GameObject panelGameOver;
    private Image imageObjetRecherche;
    private bool isPaused;
    public static int joursSurvecus;
    public Text textJoursSurvecus;
    
    // Start is called before the first frame update
    void Start()
    {
        imageObjetRecherche = GameObject.Find("imageObjetRechercher").GetComponent<Image>();
        isPaused = false;
        panelGameOver.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        imageObjetRecherche.sprite = itemSpawner.GetComponent<itemSpawnerScript>().itemRecherche.GetComponent<SpriteRenderer>().sprite;
        imageObjetRecherche.color = itemSpawner.GetComponent<itemSpawnerScript>().itemRecherche.GetComponent<SpriteRenderer>().color;
        textJoursSurvecus.text = "Jours survecus : " + (joursSurvecus-1).ToString(); 
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused == false){
                panelPause.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            }
            else{
                panelPause.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
            }
        }
    }

    public void gameOver(){
        panelGameOver.SetActive(true);
        Time.timeScale = 0;
    }
    public void retry(){
        SceneManager.LoadScene("sceneAffichageJours");
        UIScript.joursSurvecus = 1;
    }

    public void leave(){
        SceneManager.LoadScene("mainMenu");
    }
}
