using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collisions : MonoBehaviour
{
    public int maxHealth = 3;
    public static int lives = 3;

    GameManager gameManager;

    public int currentHealth;
    private Animator animator;
    private bool canInteract = true;

    public TextMeshProUGUI cooldownText;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        cooldownText.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Damage();
            cooldownText.enabled = true;

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
        StartCoroutine(BlinkCooldownText());


        yield return new WaitForSeconds(2f);
        cooldownText.enabled = false;

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

    IEnumerator BlinkCooldownText()
    {
        while (!canInteract)
        {
            cooldownText.enabled = !cooldownText.enabled;
            yield return new WaitForSeconds(0.5f);
        }
    }

}
