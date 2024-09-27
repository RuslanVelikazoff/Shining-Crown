using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] 
    private Slider healthBar;
    
    private int maxHealth;
    private int currentHealth;

    private void Start()
    {
        SetHealthBar();
    }

    private void SetHealthBar()
    {
        switch (PlayerPrefs.GetInt("SelectedKnight"))
        {
            case 0:
                if (PlayerPrefs.GetInt("PurchasedShield") == 0)
                {
                    maxHealth = 50;
                    currentHealth = maxHealth;
                    healthBar.maxValue = maxHealth;
                    healthBar.value = currentHealth;
                }
                else
                {
                    maxHealth = 60;
                    currentHealth = maxHealth;
                    healthBar.maxValue = maxHealth;
                    healthBar.value = currentHealth;
                }
                break;
            case 1:
                if (PlayerPrefs.GetInt("PurchasedShield") == 0)
                {
                    maxHealth = 70;
                    currentHealth = maxHealth;
                    healthBar.maxValue = maxHealth;
                    healthBar.value = currentHealth;
                }
                else
                {
                    maxHealth = 80;
                    currentHealth = maxHealth;
                    healthBar.maxValue = maxHealth;
                    healthBar.value = currentHealth;
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("PurchasedShield") == 0)
                {
                    maxHealth = 90;
                    currentHealth = maxHealth;
                    healthBar.maxValue = maxHealth;
                    healthBar.value = currentHealth;
                }
                else
                {
                    maxHealth = 100;
                    currentHealth = maxHealth;
                    healthBar.maxValue = maxHealth;
                    healthBar.value = currentHealth;
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("PurchasedShield") == 0)
                {
                    maxHealth = 110;
                    currentHealth = maxHealth;
                    healthBar.maxValue = maxHealth;
                    healthBar.value = currentHealth;
                }
                else
                {
                    maxHealth = 120;
                    currentHealth = maxHealth;
                    healthBar.maxValue = maxHealth;
                    healthBar.value = currentHealth;
                }
                break;
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.value = currentHealth;
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        
        UpdateHealthBar();
        
        if (currentHealth <= 0)
        {
            GameManager.Instance.LoseGame();
        }
    }
}
