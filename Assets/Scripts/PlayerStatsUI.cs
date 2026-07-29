using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsUI : MonoBehaviour 
{
    [SerializeField] private Image healthSprite;
    [SerializeField] private TMP_Text healthText;

    [SerializeField] private Image staminaSprite;
    [SerializeField] private TMP_Text staminaText;

    [SerializeField] private Image hungerSprite;
    [SerializeField] private TMP_Text hungerText;

    [SerializeField] private Image thirstSprite;
    [SerializeField] private TMP_Text thirstText;

    [SerializeField] private PlayerStats playerStats;
    private void Update()
    {
        healthSprite.fillAmount = (float)playerStats.health / (float)playerStats.maxHealth;
        healthText.text =
              $"{Mathf.RoundToInt(playerStats.health)}/{Mathf.RoundToInt(playerStats.maxHealth)}";


        staminaSprite.fillAmount = (float)playerStats.stamina / (float)playerStats.maxStamina;
        staminaText.text =
              $"{Mathf.RoundToInt(playerStats.stamina)}/{Mathf.RoundToInt(playerStats.maxStamina)}";


        hungerSprite.fillAmount = (float)playerStats.hunger / (float)playerStats.maxHunger;
        hungerText.text =
              $"{Mathf.RoundToInt(playerStats.hunger)}/{Mathf.RoundToInt(playerStats.maxHunger)}";


        thirstSprite.fillAmount = (float)playerStats.thirst / (float)playerStats.maxThirst;
        thirstText.text =
              $"{Mathf.RoundToInt(playerStats.thirst)}/{Mathf.RoundToInt(playerStats.maxThirst)}";

    }
}
