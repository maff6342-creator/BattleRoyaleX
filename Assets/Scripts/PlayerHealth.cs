
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 200f;

    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Player Health: " + currentHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        currentHealth = Mathf.Clamp(
            currentHealth, 0, maxHealth
        );

        Debug.Log("Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Eliminated!");
        gameObject.SetActive(false);
    }
}
