using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public float jumpforce = 5f;
    public Sprite idleSprite;
    public Sprite runSprite1;
    public Sprite runSprite2;
    public Sprite airSprite;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private bool isGrounded = true;
    private float animationTimer = 0f;
    private float animationInterval = 0.1f;
    private bool isRunningSprite1 = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idleSprite;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Animate();
    }
    private void Move(){
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if(moveInput > 0){
            transform.localScale = new Vector3(1,1,1);
        } else if(moveInput < 0){
            transform.localScale = new Vector3(-1,1,1);
        }  
    }
    private void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            isGrounded = false;
        }
    }

    private void Animate(){
        float moveInput = Input.GetAxis("Horizontal");
        if(!isGrounded){
            spriteRenderer.sprite = airSprite;
        } else {
            if(Mathf.Approximately(moveInput, 0)){
                spriteRenderer.sprite = idleSprite;
            } else {
               // animationTimer += deltaTime;
                if(animationTimer >= animationInterval){
                    animationTimer = 0f;
                    if(isRunningSprite1){
                        spriteRenderer.sprite = runSprite1;
                    } else {
                        spriteRenderer.sprite = runSprite2;

                    }
                    isRunningSprite1 = !isRunningSprite1;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }
    }
}
