using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    public Text statsText;

    private int deaths = 0;

    private void Start()
    {
        this.statsText.text = "";
    }

    public void AddDeath()
    {
        this.deaths++;
        this.statsText.text = "Deaths: " + this.deaths.ToString();
    }
}
