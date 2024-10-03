using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hud : MonoBehaviour
{
    public GameObject hud;
    public bool hudOpen;
    public TextMeshProUGUI hudText;
    public GameManager gameManager;
    public GameObject gameManagerObject;
    public int coins, rubies;

    // Start is called before the first frame update
    void Start()
    {
        hud.SetActive(false);
        gameManagerObject = GameObject.FindWithTag("GameController");
        if(gameManagerObject != null){
            gameManager = gameManagerObject.GetComponent<gameManager>();
        } else {
            Debug.Log("uh oh! Game Manager not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //checks if user hit tab. will pause if not yet, or resume if paused
        if(Input.GetKeyDown(KeyCode.Tab)){
            Debug.Log("Escape pressed");
            if(hudOpen){
                closeHud();
            } else{
                openHud();
            }
    }
    }

    //pauses the game, pulls up hud
    public void openHud(){
        hud.SetActive(true);
        Time.timeScale = 0f;
        hudOpen = true;
        //get the number of coins and rubies
        coins = gameManager.GetCoins();
        rubies = gameManager.GetRubies();
        hudText.SetText("Welcome to your hud!\n\n Coins: {0}   Rubies: {1}", coins, rubies);
    }
     //resumes it, closes hud
    public void closeHud(){
        hud.SetActive(false);
        Time.timeScale = 1f;
        hudOpen = false;
    }
}   
