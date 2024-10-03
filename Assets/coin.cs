using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public GameObject gameManagerObject;
    public GameManager gameManager;
    public AudioManager audioManager;

    //private void Awake(){
    // audioManager = GameObject.FindGameObjectWithTag("Audiotag");
    //}


    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = gameManagerObject.FindWithTag("GameController");
        if(gameManagerObject != null){
            gameManager = gameManagerObject.GetComponent<gameManager>();
        } else {
            Debug.LogError("Game Manager not found");
        }        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            if(gameManager != null){
                gameManager.AddScore(coinValue);
                gameObject.SetActive(false);
                //add coin sound effect
                //audioManager.PlaySFX(audioManager.coinSFX)
            }
        } else {

        }
    }   
}
