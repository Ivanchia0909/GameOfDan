using UnityEngine;

/*
    Script: Pickup
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script to apply to any pickup objects (Coins etc)
                    Note: Make sure to add a collider that is a trigger to the object also.
*/

[ RequireComponent( typeof( Collider ) ) ]
public class Pickup : MonoBehaviour
{
    // Properties
    public int scoreValue = 1;                  // How much to add to a Player's score when picked up.

    // Methods
    private void Start()
    {
        // Make sure the first collider is a trigger.
        this.gameObject.GetComponent<Collider>().isTrigger = true;
    }
}
