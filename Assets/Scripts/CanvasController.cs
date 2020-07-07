using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour{
    protected bool objCreated = false;

    void Awake(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
        if(!objCreated){
            DontDestroyOnLoad(this.gameObject);
            objCreated = true;
        } else {
            if(SceneManager.GetActiveScene().name == "Winter"){
                Vector3 newPosition = this.gameObject.transform.position;
                newPosition.x = 474.44f;
                newPosition.y = 1.8f;
                newPosition.z = 0f;
                this.gameObject.transform.position = newPosition;
            } else if(SceneManager.GetActiveScene().name == "Cave"){
                Vector3 newPosition = this.gameObject.transform.position;
                newPosition.x = 203.09f;
                newPosition.y = 9.68f;
                newPosition.z = 0f;
                this.gameObject.transform.position = newPosition;
            }
        }
    }

}
