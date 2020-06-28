using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 100;
    public float speed = 5f;
    public Animator anime;
    public Vector2 jumpHeight = new Vector2(0,8);
    public Rigidbody2D rb;
    protected SpriteRenderer rendererRef;
    private bool facingLeft = true;  // For determining which way the player is currently facing.
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;
    // Animator
    private bool isRunning = false;
    private bool isDead = false;
    private bool isJumping = false;
    private bool isAttacking = false;
    private bool isGettingHit = false;

    // Start is called before the first frame update
    void Start() {
        rendererRef = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 actualPosition = transform.position;

        isRunning = false;
        isAttacking = false;
        isGettingHit = false;

        // Verifica se está pulando ou caindo
        if(rb.velocity.y == 0) {
            isJumping = false;
        }

        // Death
        if(health <= 0 || isDead) {
            isDead = true;
            anime.SetBool("isDead", isDead);
            return;
        }

        // Jump
        if(Input.GetKey(KeyCode.UpArrow) && rb.velocity.y == 0){
            rb.AddForce(jumpHeight, ForceMode2D.Impulse);
            isJumping = true;
        }
        

        // Attacking
        if(Input.GetKey(KeyCode.LeftControl)){
            isAttacking = true;
        }

        // Running
        if(Input.GetKey(KeyCode.RightArrow)) {
            Move(1);
            if(facingLeft) Flip();
        } else if(Input.GetKey(KeyCode.LeftArrow)) {
            Move(-1);
            if(!facingLeft) Flip();
        }

        // Setting Animator
        anime.SetBool("isRunning", isRunning);
        anime.SetBool("isJumping", isJumping);
        anime.SetBool("isAttacking", isAttacking);
        anime.SetBool("isGettingHit", isGettingHit);

        transform.position = actualPosition;  
    }

    private void Move(int direction){
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(direction * speed, rb.velocity.y);
        // And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        isRunning = true;
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
