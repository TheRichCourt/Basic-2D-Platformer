using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player") {
            PlayerLife playerLife = collision.gameObject.GetComponent<PlayerLife>();
            playerLife.End();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player") {
            PlayerLife playerLife = collision.gameObject.GetComponent<PlayerLife>();
            playerLife.End();
        }
    }
}
