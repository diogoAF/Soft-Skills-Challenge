using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LimiterController : MonoBehaviour{
    protected bool objCreated = false;

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if(!objCreated){
            DontDestroyOnLoad(this.gameObject);
            objCreated = true;
        } else {
            if(SceneManager.GetActiveScene().name == "Winter"){
                Vector3 newPosition = this.gameObject.transform.position;
                newPosition.x = 462.98f;
                newPosition.y = -2.39f;
                newPosition.z = -81.115f;
                this.gameObject.transform.position = newPosition;
            }
        }
    }

    void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

     void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            EventManager.TriggerEvent("stop_player");
            EventManager.TriggerEvent("zoom_out_camera");
            EventManager.TriggerEvent("start_quiz");
        }
    }
}
