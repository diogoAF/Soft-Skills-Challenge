using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraFollow : MonoBehaviour{
    public Transform followTransform; // Player's transform
    public float maxBottomY = -3.5f;
    public int ajustX = 5;
    public int ajustY = 3;
    public int fixedAjustX = 7;
    public int fixedAjustY = 5;
    protected float fixedX;
    protected bool cameraCanMove = true;

    void Start(){
        EventManager.StartListening("zoom_out_camera", ZoomOut);
    }
    
    void FixedUpdate(){
        if(cameraCanMove){
            if(followTransform.position.y > maxBottomY){
                // We put the player's transform into the camera's transform
                this.transform.position = new Vector3(followTransform.position.x + ajustX, followTransform.position.y + ajustY, this.transform.position.z);
            } else {
                if (Object.Equals(fixedX, default(float))){
                    fixedX = followTransform.position.x;
                }
                
                this.transform.position = new Vector3(fixedX, maxBottomY, this.transform.position.z);
            }
        } else {
            this.transform.position = new Vector3(followTransform.position.x + fixedAjustX, followTransform.position.y + fixedAjustY, this.transform.position.z);
        }
        
        
    }

    void ZoomOut(){
        cameraCanMove = false;
    }
}
