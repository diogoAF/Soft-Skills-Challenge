using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{
    public Transform followTransform; // Player's transform
    
    void FixedUpdate(){
        // We put the player's transform into the camera's transform
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
        
    }
}
