using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 3;
    public float speed = 5f;
    public Animator anime;
    public Vector2 jumpHeight = new Vector2(0,8);
    public Rigidbody2D rb;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject health_1, health_2, health_3;
    protected int playerLayer, enemyLayer;
    protected bool coroutineAllowed = true;
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

        // Game Over
        gameOverText.SetActive(false);
        restartButton.SetActive(false);

        // Health
        playerLayer = this.gameObject.layer;
        //enemyLayer = LayerMask.NameToLayer("Enemy");
        //Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
        health_1 = GameObject.Find("Health_1");
        health_2 = GameObject.Find("Health_2");
        health_3 = GameObject.Find("Health_3");
        health_1.SetActive(true);
        health_2.SetActive(true);
        health_3.SetActive(true);

    }

    // Update is called once per frame
    void Update() {
        Vector3 actualPosition = transform.position;

        isRunning = false;
        isAttacking = false;

        // Verifica se está pulando ou caindo
        if(rb.velocity.y == 0) {
            isJumping = false;
        }

        // Death
        if(health <= 0 || isDead) {
            isDead = true;
            anime.Play("die");
            return;
        }

        // Jump
        if(Input.GetKey(KeyCode.UpArrow) && rb.velocity.y == 0){
            anime.Play("jump");
            rb.AddForce(jumpHeight, ForceMode2D.Impulse);
        }
        

        // Attacking
        if(Input.GetKey(KeyCode.LeftControl)){
            isAttacking = true;
            //anime.Play("attack");
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
        anime.SetBool("isAttacking", isAttacking);

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

    void OnCollisionEnter2D(Collision2D col){
        if(!isDead){
            if(col.gameObject.tag == "Enemy"){
                
                if(!isAttacking){
                   health -= 1;
                    enemyLayer = col.gameObject.layer;
                    anime.Play("get_hit");
                } 
                
                switch(health) {
                    case 2:
                        health_3.gameObject.SetActive(false);
                        if(coroutineAllowed) StartCoroutine("Immortal");
                        break;
                    case 1:
                        health_2.gameObject.SetActive(false);
                        if(coroutineAllowed) StartCoroutine("Immortal");
                        break;
                    case 0:
                        health_1.gameObject.SetActive(false);
                        if(coroutineAllowed) StartCoroutine("Immortal");
                        isDead = true;
                        gameOverText.SetActive(true);
                        restartButton.SetActive(true);
                        break;
                }
            }
            
        }
    }

    IEnumerator Immortal(){
        coroutineAllowed = false;
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, true);
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
        coroutineAllowed = true;
    }

    public bool isPlayerAttacking() {
        return isAttacking;
    }
}
