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
    bool sprint;
    bool jump;
    Rigidbody rb;

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

        sprint = Input.GetButton("Sprint");
        if (Input.GetButtonDown("Jump"))
            jump = true;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(x * (sprint ? SprintSpeed : Speed), rb.velocity.y, y * (sprint ? SprintSpeed : Speed));
    
        bool isGrounded = true;//Physics.OverlapBox(GroundCheck.position, GroundCheckSize, Quaternion.identity, GroundMask).Length != 0;
        if (jump && isGrounded)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            jump = false;
        }
    }
}
