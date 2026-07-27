using UnityEngine;

public class PlayerStats : MonoBehaviour 
{
    public int health;
    public int maxHealth;
    public float stamina;
    public float maxStamina;
    public float movementSpeed;
    public float sprintSpeed;

    private void Start()
    {
        health = 100;
        maxHealth = 100;
        sprintSpeed = 2.5f;
        movementSpeed = 5f;

        if(health>maxHealth)
        {
            health = maxHealth;
        }
        else if(health<=0)
        {
            Debug.Log("gameover");
        }

        stamina = 100;
        maxStamina = 100;

    }
}
