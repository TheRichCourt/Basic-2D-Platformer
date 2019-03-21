using UnityEngine;
using InControl;

public class PlayerRun : MonoBehaviour
{
    public float airModifier = 2;
    public float runSpeed = 2f;
    public float walkSpeed = 1f;

    private Rigidbody2D rigidBody;
    private PlayerGroundChecker groundChecker;

    private void Start()
    {
        this.rigidBody = gameObject.GetComponent<Rigidbody2D>();
        this.groundChecker = gameObject.GetComponent<PlayerGroundChecker>();
    }

    private void Update()
    {
        this.rigidBody.velocity = new Vector2(
            this.GetDirectionInput() * this.GetMoveSpeed(),
            this.rigidBody.velocity.y
        );
    }

    private float GetMoveSpeed()
    {
        float modifier = this.groundChecker.IsGrounded()
            ? 1
            : this.airModifier
        ;

        float speed = this.IsRunning()
            ? this.runSpeed
            : this.walkSpeed
        ;

        return speed * modifier;
    }

    private bool IsRunning()
    {
        return
            InputManager.ActiveDevice.Action3.IsPressed
            || Input.GetKey(KeyCode.LeftShift)
            || Input.GetKey(KeyCode.RightShift)
        ;
    }

    private float GetDirectionInput()
    {
        if (InputManager.ActiveDevice.LeftStick.X != 0) {
            return InputManager.ActiveDevice.LeftStick.X;
        }

        if (InputManager.ActiveDevice.DPadX != 0) {
            return InputManager.ActiveDevice.DPadX;
        }

        if (Input.GetKey("w") || Input.GetKey(KeyCode.LeftArrow)) {
            return -1;
        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) {
            return 1;
        }

        return 0;
    }
}
