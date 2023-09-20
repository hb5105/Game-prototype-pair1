using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using UnityEngine.UI;
public class GameModeText : MonoBehaviour
{
    public TextMeshProUGUI gameModeText; // Reference to your TextMeshPro component
    public GameObject gamePanel;

    private float timer = 0f;
    private float changeInterval = 5f;

    void Start()
    {
        // Initialize the text
        gameModeText.text = "Game Mode: ";
        UpdateGameMode(RandomBool()); // Set an initial random value
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeInterval)
        {
            timer = 0f;
            UpdateGameMode(RandomBool()); // Change the text to a random value
        }
    }

    // You can update the text using a method like this
    public void UpdateGameMode(bool mode)
    {
        gameModeText.text = mode.ToString().ToLower();
        if (mode)
        {
            gameModeText.color = Color.green;
        }
        else
        {
            gameModeText.color = Color.red;
        }

        UpdateImageColor();
    }

    // Helper function to generate a random boolean value
    private bool RandomBool()
    {
        return Random.Range(0, 2) == 0;
    }

    private void UpdateImageColor()
    {
        Image gamePanelImg = gamePanel.GetComponent<Image>();
        bool gameMode = bool.Parse(gameModeText.text);
        if (gameMode)
        {
            gamePanelImg.color = new Color(0f, 1f, 0f, 0.5f);  // Green with 50% transparency
        }
        else
        {
            gamePanelImg.color = new Color(1f, 0f, 0f, 0.5f);  // Red with 50% transparency
        }
    }


}
