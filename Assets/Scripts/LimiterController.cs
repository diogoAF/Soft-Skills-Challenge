using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LimiterController : MonoBehaviour{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

     void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            EventManager.TriggerEvent("stop_player");
            EventManager.TriggerEvent("zoom_out_camera");
        }
    }
}
