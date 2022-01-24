using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class explosionScript : MonoBehaviour
{
    public GameObject bloodExplosion;
    private GameObject UI;

    private bool isGameOver;
    private float currentTime;
    public float timeBeforeDestroy;
    // Start is called before the first frame update
    void Start()

    {
        isGameOver = false;
        
        UI = GameObject.Find("UI");
        currentTime = timeBeforeDestroy;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        if(currentTime <+ 0){
            if(isGameOver == false){
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player"){
            Destroy(other.gameObject);
            Instantiate(bloodExplosion, other.transform.position, other.transform.rotation);
            isGameOver = true;
            StartCoroutine(gameOver());
            
        }
    }
    IEnumerator gameOver(){
        yield return new WaitForSeconds(1f);
        UI.GetComponent<UIScript>().gameOver();
    }
}