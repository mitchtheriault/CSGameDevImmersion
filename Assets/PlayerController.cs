using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

    public Rigidbody2D rigidbody;
    public float jumpStrength;
    [SerializeField] private bool isGrounded;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0, jumpStrength));
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            if (gameManager.gameStarted == true)
            {
                rigidbody.AddForce(new Vector2(0, jumpStrength));
                animator.SetTrigger("Jump");
            }
            else if (gameManager.gameStarted == false)
            {
                gameManager.gameStarted = true;
                animator.SetBool("isRunning", true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {

            var collectable = collision.gameObject.GetComponent<Collectable>();
            if (collectable != null)
            {
                gameManager.score += collectable.value;
            }

            Destroy(collision.gameObject);

        }
    }

}
