using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public Vector2 respawnPosition;
    public GameObject deathParticlesObject;
    public StatsController stats;
    public AudioController audioController;

    private ParticleSystem deathParticles;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        this.rigidBody = gameObject.GetComponent<Rigidbody2D>();
        this.deathParticles = deathParticlesObject.GetComponent<ParticleSystem>();
    }

    public void End()
    {
        this.deathParticlesObject.transform.position = this.rigidBody.position;
        this.deathParticles.Play();

        this.rigidBody.position = this.respawnPosition;
        this.stats.AddDeath();

        this.audioController.Hit();
    }
}
