using UnityEngine;

/*
    Script: PlayerController
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script for moving, rotating, and jumping.
*/

[RequireComponent( typeof( Rigidbody ) ) ]
public class PlayerController : MonoBehaviour
{
    // Properties
    public float moveSpeed = 5f;            // Speed at which the game object will move (in meters per second)
    public float turnSpeed = 45f;           // Speed at which the game object will rotate (in degrees per second)
    public float jumpAmount = 5f;           // Force applied to the Rigidbody when jump key pressed.

    public string walkableTag = "walkable"; // 

    private bool isJumping;                 // Track if jumping.
    private Rigidbody rb;                   // Reference to the Rigidbody component on this game object. Used for jumping.

    // Methods
    private void Start()
    {
        // Cache a refernce to the Rigidbody component.
        this.rb = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Key input forward/backward.
        if( Input.GetKey( KeyCode.UpArrow ) == true ) { this.transform.position += this.transform.forward * Time.deltaTime * this.moveSpeed; }
        if( Input.GetKey( KeyCode.DownArrow ) == true) { this.transform.position -= this.transform.forward * Time.deltaTime * this.moveSpeed; }

        // Key input rotate left/right.
        if( Input.GetKey( KeyCode.LeftArrow ) == true ) { this.transform.Rotate( this.transform.up, Time.deltaTime * -this.turnSpeed ); }
        if( Input.GetKey( KeyCode.RightArrow ) == true ) { this.transform.Rotate( this.transform.up, Time.deltaTime * this.turnSpeed ); }

        // Key input jump force.
        if( this.isJumping == false && Input.GetKeyDown( KeyCode.Space ) == true )//{ this.rb.AddForce( Vector3.up *this.jumpAmount, ForceMode.Impulse ); }
        {
            // Do a raycast to see if there is something (eg ground) directly underneath this game object.
            if( Physics.Raycast( this.transform.position, -Vector3.up, out RaycastHit hit, 1f ) == true )
            {
                // Check the hit point surface normal is facing upward.
                if( Vector3.Angle( hit.normal, Vector3.up ) < 5f )
                {
                    // Apply an upward force.
                    this.rb.AddForce( Vector3.up * this.jumpAmount, ForceMode.Impulse );
                }
            }
        }
    }

    private void OnCollisionStay( Collision collision )
    {
        this.isJumping = false;
    }

    private void OnCollisionExit( Collision collision )
    {
        this.isJumping = true;
        //Debug.Log( "Jump" );
    }
}
