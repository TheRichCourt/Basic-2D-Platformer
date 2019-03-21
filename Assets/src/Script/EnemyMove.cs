using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float rightLimit;
    public float leftLimit;
    public float topLimit;
    public float bottomLimit;
    public float moveSpeedX;
    public float moveSpeedY;
    public float dontUpdateLimitsThreshold;

    private Rigidbody2D rigidBody;
    private bool movingRight = true;
    private bool movingUp = true;
    private float lastDirectionChangeTime = -1;

    private void Start()
    {
        this.rigidBody = gameObject.GetComponent<Rigidbody2D>();

        if (this.leftLimit > this.rightLimit) {
            throw new System.Exception("Left limit shouldn't be greater than right limit");
        }

        if (this.bottomLimit > this.topLimit) {
            throw new System.Exception("Left limit shouldn't be greater than right limit");
        }

        if (this.moveSpeedX != 0 && this.moveSpeedY != 0) {
            throw new System.Exception("X and Y speeds shouldn't both be set");
        }
    }

    private void FixedUpdate()
    {
        this.CheckLimits();

        float xVelocity = 0;
        float yVelocity = 0;

        if (this.moveSpeedX > 0) {
            xVelocity = this.movingRight
                ? this.moveSpeedX
                : -this.moveSpeedX
            ;
        }

        if (this.moveSpeedY > 0) {
            yVelocity = this.movingUp
                ? this.moveSpeedY
                : -this.moveSpeedY
            ;
        }

        this.rigidBody.velocity = new Vector2(
            xVelocity,
            yVelocity
        );
    }

    private void CheckLimits()
    {
        if (Time.timeSinceLevelLoad < this.lastDirectionChangeTime + this.dontUpdateLimitsThreshold) {
            return;
        }

        if (this.moveSpeedX > 0) {
            if (this.rigidBody.position.x >= rightLimit) {
                this.movingRight = false;
                this.lastDirectionChangeTime = Time.timeSinceLevelLoad;
            }

            if (this.rigidBody.position.x <= leftLimit) {
                this.movingRight = true;
                this.lastDirectionChangeTime = Time.timeSinceLevelLoad;
            }
        }

        if (this.moveSpeedY > 0) {
            if (this.rigidBody.position.y >= this.topLimit) {
                this.movingUp = false;
                this.lastDirectionChangeTime = Time.timeSinceLevelLoad;
            }

            if (this.rigidBody.position.y <= this.bottomLimit) {
                this.movingUp = true;
                this.lastDirectionChangeTime = Time.timeSinceLevelLoad;
            }
        }
    }
}
