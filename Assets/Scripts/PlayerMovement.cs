using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private float movementSpeed = 0f;
    private float horDirection = 0f;

    private Rigidbody2D rb;
    private bool lookingLeft = true;

    // EXECUTION FUNCTIONS
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        PlayerManager.instance.animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        GetInput();
    }

    private void FixedUpdate() {
        MovementHandle();
    }

    // METHODS
    private void GetInput() {
        horDirection = Input.GetAxisRaw("Horizontal") * movementSpeed * (Input.GetKey(KeyCode.LeftShift) ? 3 : 1);

        if (lookingLeft && horDirection > 0)
            Flip();
        else if (!lookingLeft && horDirection < 0)
            Flip();
    }

    private void MovementHandle() {
        rb.velocity = new Vector2(horDirection * Time.fixedDeltaTime, rb.velocity.y);
    }

    private void Flip() {
        var newScale = PlayerManager.instance.animator.gameObject.transform.localScale;
        newScale.x *= -1f;
        PlayerManager.instance.animator.gameObject.transform.localScale = newScale;

        lookingLeft = !lookingLeft;
    }
}
