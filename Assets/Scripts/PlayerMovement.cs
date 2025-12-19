using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float rotationSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // جلوگیری از چرخش ناخواسته
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        // حرکت جلو/عقب
        Vector3 movement = transform.forward * move * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // چرخش
        float turnAmount = turn * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turnAmount, 0f));
    }
}
