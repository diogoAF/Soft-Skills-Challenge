using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    protected string curSceneName = SceneManager.GetActiveScene().name;
    
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void EndSceneQuiz(){
        curSceneName = SceneManager.GetActiveScene().name;

        if(curSceneName == "Forest"){
            SceneManager.LoadScene("Winter");
        } else if(curSceneName == "Winter") {
            SceneManager.LoadScene("Cave");
        }
    }

    
}
