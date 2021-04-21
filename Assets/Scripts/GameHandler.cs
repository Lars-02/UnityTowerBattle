using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public int gold;
    public GameObject victory;
    public GameObject defeat;
    private Text goldText;

    void Start()
    {
        Debug.Log("GameHandler.Start");
        goldText = GetComponentInChildren<Text>();
        InvokeRepeating("GenerateGold", 2f, 2f);
        InvokeRepeating("GenerateGold", 32f, 2f);
        InvokeRepeating("GenerateGold", 62f, 2f);
        InvokeRepeating("GenerateGold", 122f, 2f);
        InvokeRepeating("GenerateGold", 242f, 2f);
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
        CancelInvoke("GenerateGold");
        GetComponentInChildren<ShopController>().CloseShop();

        if (tag == "PlayerBase")
            defeat.SetActive(true);
        else
            victory.SetActive(true);
    }
}
