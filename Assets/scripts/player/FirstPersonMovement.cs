using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    // animator
    Animator animator;


    private bool walking = false;
    
    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);
        Vector3 newPosition = transform.position + transform.rotation * new Vector3(targetVelocity.x, 0, targetVelocity.y) * Time.fixedDeltaTime;

        // use interpolation to smooth out movement
        rigidbody.MovePosition(Vector3.Lerp(transform.position, newPosition, 0.5f));

        // Apply movement.
        //rigidbody.MovePosition(newPosition);
        walking = targetVelocity.magnitude > 0.1f;

        // Update animator.
        animator.SetBool("walking", walking );
    }
}