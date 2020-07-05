using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public QuizController quizController;
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

        if(curSceneName == "TheEnd"){
            ShowFinalResult();
        }
    }

    void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void EndSceneQuiz(){

        if(curSceneName == "Forest"){
            SceneManager.LoadScene("Winter");
        } else if(curSceneName == "Winter") {
            SceneManager.LoadScene("TheEnd");
        }
    }

    protected void ShowFinalResult(){
        int finalScore = quizController.GetFinalScore();

        if(finalScore < 54){
            EventManager.TriggerEvent("result_analista_planejador");
        } else {
            EventManager.TriggerEvent("result_comunicador_executor");
        }
    }

    
}
