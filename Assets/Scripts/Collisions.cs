using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public int maxHealth = 3;
    public static int lives = 3;

    GameManager gameManager;

    public int currentHealth;
    private Animator animator;
    private bool canInteract = true;

    

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Damage();
        }
    }

    void Damage()
    {
        if (canInteract)
        {
            animator.Play("Stumble");
            currentHealth--;
            lives--;

            if (currentHealth <= 0)
            {
                Die();
            }
            StartCoroutine(Cooldown());
        }
    }
    IEnumerator Cooldown()
    {
        StartCoroutine(DieAnimation());
        canInteract = false;

        yield return new WaitForSeconds(2f);

        canInteract = true;
    }

    void Die()
    {
        animator.Play("Stumble");
        gameManager.GameOver();
    }
    IEnumerator DieAnimation()
    {
        yield return new WaitForSeconds(3); 
    }

}
