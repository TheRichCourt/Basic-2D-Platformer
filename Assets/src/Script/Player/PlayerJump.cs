using UnityEngine;
using InControl;

public class PlayerJump : MonoBehaviour
{
    public float rememberJumpTime = .2f;
    public float rememberGroundTime = .2f;
    public float jumpVelocity = 5;
    public AudioController audioController;

    private Rigidbody2D rigidBody;
    private PlayerGroundChecker groundChecker;
    private float jumpPressTime = -1;
    private float jumpStartTime = -1;
    private float lastGroundedTime = -1;
    private bool isGrounded = false;
    private bool isJumping = false;

    private void Start()
    {
        this.rigidBody = gameObject.GetComponent<Rigidbody2D>();
        this.groundChecker = gameObject.GetComponent<PlayerGroundChecker>();
    }

    private void Update()
    {
        if (this.JumpWasPressed()) {
            this.jumpPressTime = Time.timeSinceLevelLoad;
        }

        if (this.JumpWasReleased()) {
            this.EndJump();
        }

        if (this.groundChecker.IsGrounded()) {
            this.isJumping = false;
            this.lastGroundedTime = Time.timeSinceLevelLoad;
        }

        this.Jump();
    }

    private bool JumpWasPressed()
    {
        return
            InputManager.ActiveDevice.Action1.WasPressed
            || Input.GetKeyDown(KeyCode.Space)
        ;
    }

    private bool JumpWasReleased()
    {
        return
            InputManager.ActiveDevice.Action1.WasReleased
            || Input.GetKeyUp(KeyCode.Space)
        ;
    }

    private void Jump()
    {
        if (this.ShouldJump()) {
            this.rigidBody.velocity = new Vector2(this.rigidBody.velocity.x, this.jumpVelocity);
            this.isJumping = true;
            this.audioController.Jump();
        }
    }

    private void EndJump()
    {
        // N.B. this.isJumping remains true until we hit the ground
        if (this.rigidBody.velocity.y > 0) {
            this.rigidBody.velocity = new Vector2(this.rigidBody.velocity.x, (this.rigidBody.velocity.x * .5f));
        }
    }

    private bool ShouldJump()
    {
        return
            !this.isJumping
            && (Time.timeSinceLevelLoad <= this.lastGroundedTime + this.rememberGroundTime || this.groundChecker.IsGrounded())
            && Time.timeSinceLevelLoad <= this.jumpPressTime + this.rememberJumpTime
        ;
    }
}
