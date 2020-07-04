using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    protected string curSceneName;
    
    // Start is called before the first frame update
    void Start(){
        curSceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void EndSceneQuiz(){

        if(curSceneName == "Forest"){
            SceneManager.LoadScene("Winter");
        } else if(curSceneName == "Winter") {
            SceneManager.LoadScene("Cave");
        }
    }

    
}
