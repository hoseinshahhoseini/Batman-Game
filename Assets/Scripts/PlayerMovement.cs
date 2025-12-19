using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 1f;
    public float runSpeed = 2f;
    public float slowSpeed = 0.5f;
    public float rotationSpeed = 100f;
    
    private float movingSpeed;
    private Rigidbody rb;

    void Start()
    {
        movingSpeed = walkSpeed;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // جلوگیری از چرخش ناخواسته
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        movingSpeed = Input.GetKeyDown(KeyCode.LeftShift) ? runSpeed : movingSpeed;
        movingSpeed = Input.GetKeyUp(KeyCode.LeftShift) ? walkSpeed : movingSpeed;

        // حرکت جلو/عقب
        Vector3 movement = transform.forward * move * movingSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // چرخش
        float turnAmount = turn * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turnAmount, 0f));
    }

    public void SetNormalSpeed()
    {
        movingSpeed = walkSpeed;
    }
    public void SetSlowSpeed()
    {
        movingSpeed = slowSpeed;
    }
}
