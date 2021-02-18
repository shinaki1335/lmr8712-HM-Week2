using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //create variables
    public static GameManager instance;             //static variable that will hold Singleton
    public int score = 0;                           //variable to keep score
    public int targetScore = 3;                     //variable that set target score
    public int currentLevel;                        //variable for the current level of the game
    
    // Called when script instance is being loaded
    void Awake() {   
        // Make a Singleton to prevent more than one instance of an object
        if (instance == null) {                 //if instance hasn't been set
            DontDestroyOnLoad(gameObject);      //don't destroy object when loading new scene
            instance = this;                    //set instance to this object 
        }
        
        else {                                  //if instance is set to an object
            Destroy(gameObject);                //destroy this object
        }
    }

    // Update is called once per frame
    void Update() {
        // Check score to change level
        if (score == targetScore) {                                     //if score equals target score
            currentLevel++;                                             //change the level
            SceneManager.LoadScene(sceneBuildIndex: currentLevel);      //load the scene corresponding to the level
            targetScore += targetScore + targetScore/2;                 //set a new target score
        }
    }
}
