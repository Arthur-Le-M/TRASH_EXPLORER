using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float dropForce;
    private Rigidbody2D rb;


    private bool isLoaded;
    private GameObject itemLoaded;
    private float direction;
    public GameObject hand;


    private float currentTime;
    private float timeAfterDeath;

    private Animator animPlayer;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = timeAfterDeath;
        isLoaded = false;
        rb = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Mouvement Horizontal
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0,0) *speed * Time.deltaTime;
        
        //animation
        if(movement != 0){
            animPlayer.SetBool("isRunning", true);
        }
        else{
            animPlayer.SetBool("isRunning", false);
        }

        //Rotation
        if(movement < -0.1){
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            direction = -1f;
        }
        else if(movement > 0.1){
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            direction = 1f;
        }

        //Saut
        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.1f){
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
            //Gestion d'item
        if(isLoaded == true && itemLoaded.GetComponent<itemScript>().loaded == true){
            itemLoaded.GetComponent<Transform>().transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y, hand.transform.position.z);
        }
        
        if(isLoaded && Input.GetMouseButton(1)){
            dropItem();
        }
        
    }


private void OnTriggerStay2D(Collider2D other) {
    if(other.tag == "item" && Input.GetMouseButton(0) && isLoaded == false){
        isLoaded = true;
        itemLoaded = other.gameObject;
        itemLoaded.GetComponent<Rigidbody2D>().freezeRotation = true;
        itemLoaded.GetComponent<Collider2D>().isTrigger = true;
        itemLoaded.GetComponent<itemScript>().loaded = true;
    }
    
}

void dropItem(){
    itemLoaded.GetComponent<itemScript>().loaded = false;
    itemLoaded.GetComponent<Collider2D>().isTrigger = false;
    itemLoaded.GetComponent<Rigidbody2D>().freezeRotation = false;
    if(Input.GetKey(KeyCode.LeftShift)){
        itemLoaded.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction*dropForce, 10), ForceMode2D.Impulse);
        }
    isLoaded = false;
}
}
