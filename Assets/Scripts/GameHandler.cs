using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public int gold;
    private Text goldText;

    void Start()
    {
        Debug.Log("GameHandler.Start");
        goldText = GetComponentInChildren<Text>();
        Debug.Log(goldText);
    }

    void Update()
    {
        goldText.text = gold.ToString();
    }
}
