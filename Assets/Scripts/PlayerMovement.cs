using UnityEngine;

//https://www.youtube.com/watch?v=f473C43s8nE

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    //drag
    public float groundDrag;
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update() {

        //check for ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        KeyboardInput();
        SpeedControl();

        //if drag
        if (grounded) {
            rb.linearDamping = groundDrag;
        } else {
            rb.linearDamping = 0;
        }
    }

    private void FixedUpdate() {
        //fixed for physics
        MovePlayer();
    }

    private void KeyboardInput() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer() {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //no delta time with fixed update
        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
    }

    private void SpeedControl() {
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        //limit
        if(flatVelocity.magnitude > moveSpeed) {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }
    }
}
