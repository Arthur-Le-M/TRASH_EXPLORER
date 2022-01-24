using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class affichageJoursScript : MonoBehaviour
{
    private Text affichageJours;
    private Text affichageVousAvezSurvecus;
    
    // Start is called before the first frame update
    void Start()
    {
        affichageJours = GameObject.Find("textJours").GetComponent<Text>();
        affichageVousAvezSurvecus = GameObject.Find("textVousAvezSurvecus").GetComponent<Text>();
        print("Chargement jours");
    }

    // Update is called once per frame
    void Update()
    {
        affichageJours.text = "JOURS " + UIScript.joursSurvecus;
        if(UIScript.joursSurvecus > 1){
            affichageVousAvezSurvecus.text = "Vous avez survecus un jours de plus !";
        }
        else{
            affichageVousAvezSurvecus.text = "Essayez de ne pas mourir !";
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene("SampleScene");
        }
    }
}
