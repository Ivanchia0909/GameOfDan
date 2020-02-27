using UnityEngine;

/*
    Script: MovingPlatform
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple moving platform script.
                    Moves using Mathf.Sin. Can control movemant speed and axis direction.
                    When an object enters this game object's collider it will be made a child of this transform.
*/

[ RequireComponent( typeof( Collider ) ) ]
public class MovingPlatform : MonoBehaviour
{
    // Enumerators
    public enum Axis { _xAxis, _yAxis, _zAxis}

    // Properties
    public Axis axis;                           // Local axis this platform moves in.
    public float moveSpeed = 2f;                // Speed at which this platform moves.
    public float distance = 3f;                 // Distance (amplitude) of movement.

    private Vector3 startPosition;              // Starting position to move from.

    // Methods
    private void Start()
    {
        // Make sure the collider is a trigger.
        this.gameObject.GetComponent<Collider>().isTrigger = true;

        // Record the start position.
        this.startPosition = this.transform.position;
    }

    private void Update()
    {
        // Move this object along the assigned axis using Mathf.Sin
        switch( this.axis )
        {
            case Axis._xAxis:
                this.transform.position = startPosition +( this.transform.right * Mathf.Sin( Time.time * this.moveSpeed ) * this.distance );
                break;

            case Axis._yAxis:
                this.transform.position = startPosition + ( this.transform.up * Mathf.Sin( Time.time * this.moveSpeed ) * this.distance );
                break;

            case Axis._zAxis:
                this.transform.position = startPosition + ( this.transform.forward * Mathf.Sin( Time.time * this.moveSpeed ) * this.distance );
                break;
        }        
    }

    private void OnTriggerEnter( Collider collider )
    {
        collider.gameObject.transform.SetParent( this.transform, true );
    }

    private void OnTriggerExit( Collider collider )
    {
        collider.gameObject.transform.SetParent( null, true );
    }
}
