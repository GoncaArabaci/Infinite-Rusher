using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateHealth : MonoBehaviour
{
    public RawImage[] healthIcons;

    Collisions playerCollisions;

    void Start()
    {
        playerCollisions = FindObjectOfType<Collisions>();
    }
    private void Update()
    {
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        for (int i = 0; i < healthIcons.Length; i++)
        {
            if (i < playerCollisions.currentHealth)
            {
                healthIcons[i].enabled = true; // Display the health icon if the player's health is greater than or equal to its index.
            }
            else
            {
                healthIcons[i].enabled = false; // Hide the health icon if the player's health is less than its index.
            }
        }
    }
}
