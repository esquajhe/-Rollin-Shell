using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float SprintSpeed;
    public float JumpForce;

    public Transform GroundCheck;
    public Vector3 GroundCheckSize;
    public LayerMask GroundMask;

    float x, y;
    bool sprint = false;
    bool jump = false;
    Rigidbody rb;

    const int MAX_NB_JUMP = 2;
    int current_nb_jump = 0;

    bool IsGrounded()
    {
        float GroundedDistance = 0.5f;
        rb = GetComponent<Rigidbody>();
        if (rb.velocity.y == 0)
        {
            return Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, GroundedDistance);
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        sprint = Input.GetKeyDown(KeyCode.LeftShift);

        if (Input.GetButton("Sprint"))
        {
            sprint = true;
        }

        if (Input.GetButtonDown("Jump"))
            jump = true;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(x * (sprint ? SprintSpeed : Speed), rb.velocity.y, y * (sprint ? SprintSpeed : Speed));
        if (IsGrounded())
        {
            current_nb_jump = 0;
        }

        if (jump && current_nb_jump < MAX_NB_JUMP)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            jump = false;
            current_nb_jump++;
        }
        else if (current_nb_jump == MAX_NB_JUMP){ jump = false; }
    }
}
