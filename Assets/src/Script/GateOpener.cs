using UnityEngine;

public class GateOpener : MonoBehaviour
{
    public ParticleSystem openParticles;
    public SpriteRenderer sprite;
    public BoxCollider2D gateCollider;
    public AudioController audioController;

    private GameObject gate;

    private void Start()
    {
        this.gate = transform.parent.gameObject;
    }

    public void Open()
    {
        this.sprite.enabled = false;
        this.gateCollider.enabled = false;
        this.openParticles.Play();
        this.audioController.Unlock();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            this.Open();
        }
    }
}
