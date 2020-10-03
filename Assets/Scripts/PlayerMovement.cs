using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private float movementSpeed = 0f;
    private float horDirection = 0f;

    private Rigidbody2D rb;

    // EXECUTION FUNCTIONS
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        GetInput();
    }

    private void FixedUpdate() {
        MovementHandle();
    }

    // METHODS
    private void GetInput() {
        horDirection = Input.GetAxisRaw("Horizontal") * movementSpeed;
    }

    private void MovementHandle() {
        rb.velocity = new Vector2(horDirection * Time.fixedDeltaTime, rb.velocity.y);
    }
}
