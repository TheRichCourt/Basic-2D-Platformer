using UnityEngine;

public class PlayerGroundChecker : MonoBehaviour
{
    public LayerMask groundLayers;
    public float detectionRadius = .1f;

    private Vector2[] groundCheckRelativePositions;

    private void Start()
    {
        this.groundCheckRelativePositions = new Vector2[] {
            new Vector2(-.5f, -.5f),
            new Vector2(.5f, -.5f)
        };
    }

    public bool IsGrounded()
    {
        foreach (Vector2 groundCheckRelativePosition in this.groundCheckRelativePositions) {
            Vector2 groundCheckPosition = (Vector2)transform.position + groundCheckRelativePosition;

            if (Physics2D.OverlapCircle(groundCheckPosition, this.detectionRadius, groundLayers)) {
                return true;     
            }
        }

        return false;
    }
}
