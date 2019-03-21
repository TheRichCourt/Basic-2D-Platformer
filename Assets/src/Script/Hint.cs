using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    public Text hintText;
    public string message;

    private float displayStartTime = 0;
    private readonly float displayFor = 2;
    private bool isDisplayed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player") {
            this.ShowHint();
        }
    }

    private void ShowHint()
    {
        this.hintText.text = "Hint: " + this.message;
        this.isDisplayed = true;
        this.displayStartTime = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        if (this.isDisplayed && Time.timeSinceLevelLoad > this.displayStartTime + this.displayFor) {
            hintText.text = "";
            this.isDisplayed = false;
        }
    }
}
