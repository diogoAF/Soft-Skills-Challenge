using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    protected string curSceneName;
    protected bool objCreated = false;

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if(!objCreated){
            DontDestroyOnLoad(this.gameObject);
            objCreated = true;
        }

        curSceneName = scene.name;
    }

    void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void EndSceneQuiz(){

        if(curSceneName == "Forest"){
            SceneManager.LoadScene("Winter");
        } else if(curSceneName == "Winter") {
            SceneManager.LoadScene("Cave");
        }
    }

    
}
