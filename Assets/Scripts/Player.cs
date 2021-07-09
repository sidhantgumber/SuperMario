using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    public float  speed = 10f;
    public float jumpSpeed = 2f;
    private Rigidbody2D rigidBody2D;
    public Animator animator;
    public Text scoreText;
    public int score = 0;
    public AnimationClip dead;
   

    private SpriteRenderer spriterenderer;

    void Start()
    {

        rigidBody2D = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        // var v = Input.GetAxis("Vertical");

        

            rigidBody2D.velocity = new Vector2(h * speed, rigidBody2D.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(rigidBody2D.velocity.x));


            // code to make the character face left on moving left
            if (h < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z); // isme absolute value lo -1 se multiply karenge nahi to neg ko -1 se multiply karega aur ghoomta hi rahega

            }

            // code to make the character go back to facing right when moving right
            else if (h > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            }
        

        

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpSpeed);
            animator.SetBool("isJumping", true);

        }
        if (IsGrounded() == true) {

            animator.SetBool("isJumping", false);

        }



    }
  


    private bool IsGrounded()
    {  
        return rigidBody2D.velocity.y == 0.0f;
        

    }

    public void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(2);
        // animator.SetBool("isDead", true);
      

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {

            Debug.Log("Collided with plant");
        }


        if (collision.gameObject.tag == "Collectible" )
        {

            score += 100;

        }

        scoreText.text = score.ToString();
        
    }


}
