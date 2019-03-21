using UnityEngine;
using UnityEngine.UI;
using InControl;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public Text winText;
    public AudioController audioController;

    private bool hasBeenWon = false;
    private float winTime = 0;
    private float waitTimeAfterWin = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player") {
            this.Trigger();
        }
    }

    private void Trigger()
    {
        this.winText.text = "You win!";
        this.audioController.Win();
        this.hasBeenWon = true;
        this.winTime = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        if (this.hasBeenWon && InputManager.ActiveDevice.AnyButton.IsPressed && Time.timeSinceLevelLoad > this.winTime + this.waitTimeAfterWin) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
