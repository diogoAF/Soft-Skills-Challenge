using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySaw : MonoBehaviour
{
    public float topLimit; 
    public float bottomLimit; 
    public float step = 0.1f; 
    protected SpriteRenderer rendererRef; 
    public float speed = 2;

    // Start is called before the first frame update
    void Start() {
        rendererRef = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 actualPosition = transform.position;

        if(actualPosition.y <= bottomLimit || actualPosition.y >= topLimit) {
            step *= -1f;
        }

        actualPosition.y += step * speed;

        transform.position = actualPosition;  
    }
}
