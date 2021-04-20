using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    GameHandler gameHandler;
    Text goldText;

    private void Start()
    {
        gameHandler = GetComponentInParent<GameHandler>();
        goldText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        goldText.text = gameHandler.gold.ToString();
    }
}
