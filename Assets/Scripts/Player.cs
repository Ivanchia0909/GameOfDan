using UnityEngine;
using UnityEngine.UI;

/*
    Script: Player
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script for the Player object.
*/

public class Player : MonoBehaviour
{
    // Properties
    public float health = 10f;                      // Total amount of health the player has.
    public int score;
    public int maxScore = 5;
    // This player's score.
    public ExpBar expBar;
    int level;
    public Text currentLevel;
    
   



    void Start()
    {
        score = 0;
        expBar.SetZeroExp(score);
        level = 0;
        currentLevel.text = "Level : 0";
        
    }
    // Methods
    public void TakeDamage( float amountOfDamage )
    {
        // Don't take damage if health already zero.
        if( this.health == 0f ) { return; }

        // Apply damage.
        this.health -= amountOfDamage;
        if( this.health < 0f ) { this.health = 0f; }

        // Check if health just became zero.
        if( this.health == 0f )
        {
            Debug.Log( "Player killed." );

            // Disable PlayerController input.
            PlayerController[] playerControllers = GameObject.FindObjectsOfType<PlayerController>();
            foreach( PlayerController pController in playerControllers ){ pController.enabled = false; }
        }
    }

    private void OnTriggerEnter( Collider collider ) // This method automatically gets called when the object it is on enters a collider (Set to trigger)
    {
        // Sanity check.
        if( collider == null ){ return; }

        // Check to see if the collider game object has a Pickup component.
        Pickup pickup = collider.gameObject.GetComponent<Pickup>();
        if( pickup != null )
        {
            this.score += pickup.scoreValue;
            expBar.SetExp(score);
            if (score >= maxScore)
            {
                level += 1;
                currentLevel.text = "Level : " + level.ToString();
                score = 0;
                expBar.SetZeroExp(score);
               
            }

            // Destroy the pickup.
            Destroy( collider.gameObject );
        }
    }
    
    
}
