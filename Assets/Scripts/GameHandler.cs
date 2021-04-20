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
        InvokeRepeating("GenerateGold", 2f, 2f);
    }

    void Update()
    {
        goldText.text = gold.ToString();
    }

    private void GenerateGold()
    {
        gold += 1;
    }

    public void EndGame(string tag)
    {
        Debug.Log("Game has ended");

        if (tag == "PlayerBase")
        {

        }
    }
}
