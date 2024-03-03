using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float runningSpeed;
    float maxSpeed = 22f;
    [SerializeField] float accelerationRate;
    float rightPos = 2f;
    float leftPos = -2f;
    [SerializeField] float jumpForce;
    bool isJumping = false;

    CapsuleCollider capsuleCollider;
    Rigidbody rb;
    Animator animator;

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Running();
        MoveLeft();
        MoveRight();
        MoveUp();
        MoveDown();
    }

    void Running()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;

        runningSpeed += accelerationRate * Time.deltaTime;
        if (runningSpeed > maxSpeed)
        {
            runningSpeed = maxSpeed;
        }

        float xPosition = transform.position.x;

        if (xPosition < 0 && xPosition > -1f)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        else if (xPosition < -1f && xPosition > -2f)
        {
            transform.position = new Vector3(leftPos, transform.position.y, transform.position.z);
        }
        else if (xPosition > 0 && xPosition <= 1f)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        else if (xPosition > 1f && xPosition < 2f)
        {
            transform.position = new Vector3(rightPos, transform.position.y, transform.position.z);
        }
    }

    void MoveLeft()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(leftPos, 0f, 0f);
            animator.Play("MoveLeft");

        }
    }

    void MoveRight()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.Play("MoveRight");

            transform.position += new Vector3(rightPos, 0f, 0f);
        }
    }

    void MoveUp()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && !isJumping)
        {
            isJumping = true;
            animator.Play("Jump");
            rb.AddForce(Vector3.up * jumpForce);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    void MoveDown()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.Play("Slide");
            StartCoroutine(MoveDownAndUp());
        }
    }
    IEnumerator MoveDownAndUp()
    {
        capsuleCollider.height /= 2;
        capsuleCollider.center /= 2;

        yield return new WaitForSeconds(1f);

        capsuleCollider.height *= 2;
        capsuleCollider.center *= 2;
    }
    
    
}
