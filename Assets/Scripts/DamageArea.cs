using UnityEngine;

/*
    Script: DamageArea
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script for damaging a Player if they are within this game object's collider.
*/

public class DamageArea : MonoBehaviour
{
    // Properties
    public float amountOfDamage = 1f;               // Amount of damage to do to the Player (per second) while they are within the collider.

    // Methods
    private void OnTriggerStay( Collider collider )
    {
        // Sanity check.
        if( collider == null ){ return; }

        // Get the Player.
        Player player = collider.gameObject.GetComponent<Player>();
        if( player == null ){ return; }

        // Damage the player.
        player.TakeDamage( this.amountOfDamage *Time.deltaTime );
    }
}
