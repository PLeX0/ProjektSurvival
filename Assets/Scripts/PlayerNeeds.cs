using UnityEngine;

public class PlayerNeeds : MonoBehaviour
{
    private PlayerStats playerStats;


    [Header("Needs drain")]
    [SerializeField] private float hungerDrainPerSec = 0.05f;
    [SerializeField] private float hungerDrainPerSecWhenStaminaRegen = 0.1f;
    [SerializeField] private float thirstDrainPerSec = 0.07f;
    [SerializeField] private float thirstDrainPerSecWhenStaminaRegen = 0.15f;
    private float a, b;

    [SerializeField] private float damagePerSec = 5f;

    private void Awake()
    {
        if(playerStats == null)
            playerStats = GetComponent<PlayerStats>();
        a = hungerDrainPerSec;
        b = thirstDrainPerSec;
    }
    private void Update()
    {
        if(playerStats.stamina != playerStats.maxStamina)
        {
            hungerDrainPerSec = hungerDrainPerSecWhenStaminaRegen;
            thirstDrainPerSec = thirstDrainPerSecWhenStaminaRegen;
        }
        else if (playerStats.stamina == playerStats.maxStamina)
        {
            hungerDrainPerSec = a;
            thirstDrainPerSec = b;
        }

        playerStats.hunger -= hungerDrainPerSec * Time.deltaTime;
        playerStats.thirst -= thirstDrainPerSec * Time.deltaTime;

        playerStats.hunger = Mathf.Clamp(
           playerStats.hunger,
           0f,
           playerStats.maxHunger
       );

        playerStats.thirst = Mathf.Clamp(
            playerStats.thirst,
            0f,
            playerStats.maxThirst
        );


        if (playerStats.hunger <= 0f )
        {
            playerStats.health -= damagePerSec * Time.deltaTime;
            Debug.Log("I'm hungry");
        }

        if(playerStats.thirst <= 0f )
        {
            playerStats.health -= damagePerSec * Time.deltaTime;
            Debug.Log("I'm thirst");
        }
    }
}
