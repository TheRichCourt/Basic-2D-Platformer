using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource jump;
    public AudioSource hit;
    public AudioSource unlock;
    public AudioSource win;

    public void Jump()
    {
        this.jump.Play();
    }

    public void Hit()
    {
        this.hit.Play();
    }

    public void Unlock()
    {
        this.unlock.Play();
    }

    public void Win()
    {
        this.win.Play();
    }
}
