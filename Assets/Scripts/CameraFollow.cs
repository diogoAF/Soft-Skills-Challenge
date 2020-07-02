using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{
    public Transform followTransform; // Player's transform
    public float maxBottomY = -3.5f;
    protected float fixedX;
    
    void FixedUpdate(){
        if(followTransform.position.y > maxBottomY){
            // We put the player's transform into the camera's transform
            this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y + 3, this.transform.position.z);
        } else {
            if (Object.Equals(fixedX, default(float))){
                fixedX = followTransform.position.x;
            }
            
            this.transform.position = new Vector3(fixedX, maxBottomY, this.transform.position.z);
        }
        
    }
}
