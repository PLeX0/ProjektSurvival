using UnityEngine;

public class PlayerStats : MonoBehaviour 
{
    private PlayerMovement playerMovement;
    public float health = 100;
    public float maxHealth = 100;
    public float hunger = 100;
    public float maxHunger = 100;
    public float thirst = 100;
    public float maxThirst = 100;
    public float stamina = 100f;
    public float maxStamina = 100f;
    public float movementSpeed = 5f;
    public float sprintSpeed = 2.5f;

    private void Awake()
    {
        if(playerMovement == null)
            playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {

        health = Mathf.Clamp(
           health,
           0f,
           maxHealth
       );

        if (health <= 0)
       {
            Debug.Log("gameover");
       }
    }

    public void Damage(int damage)
    {
        health -= damage;
    }
}
