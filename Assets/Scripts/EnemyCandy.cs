using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCandy : MonoBehaviour
{
    public int maxMoviment = 5;
    protected float rightLimit; 
    protected float leftLimit; 
    protected int direction = 1;
    protected bool changeDirection = false;
    private bool facingLeft = false;
    protected SpriteRenderer rendererRef; 
    protected Rigidbody2D rb;

    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start() {
 
        rendererRef = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        rightLimit = transform.position.x + maxMoviment;
        leftLimit = transform.position.x - maxMoviment;

    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    private void Move(){
Debug.Log("rb.angularVelocity " + rb.angularVelocity);
        if(hasToChangeDirection()) {
            direction *= -1;
            Flip();
        }

        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(direction * 3f, rb.velocity.y);
        // And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    private bool hasToChangeDirection() {
        if(changeDirection) {
            if((int) transform.position.x > leftLimit && transform.position.x < (int) rightLimit){
                changeDirection = false;
            }
            return false;
        }

        if((int) transform.position.x == (int) leftLimit || (int) transform.position.x == (int) rightLimit) {
            changeDirection = true;
            return true;
        }

        return false;

    }

    private void Flip(){
		// Switch the way the player is labelled as facing.
		facingLeft = !facingLeft;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
