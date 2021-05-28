using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public int gold;
    public GameObject victory;
    public GameObject defeat;
    private Text goldText;
    private bool ended;

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
        if (Input.GetKeyDown(KeyCode.Alpha1))
            gold += 100;
        if (Input.GetKeyDown(KeyCode.Alpha2) && !ended)
            EndGame("EnemyBase");
        if (Input.GetKeyDown(KeyCode.Alpha3) && !ended)
            EndGame("PlayerBase");
    }

    private void GenerateGold()
    {
        gold += 1;
    }

    public void EndGame(string tag)
    {
        if (ended)
            return;
        Debug.Log("Game has ended");
        CancelInvoke("GenerateGold");
        GetComponentInChildren<ShopController>().CloseShop();
        GetComponentsInChildren<BaseController>()[0].MakeInvulnerable();
        GetComponentsInChildren<BaseController>()[1].MakeInvulnerable();

        if (tag == "PlayerBase")
            defeat.SetActive(true);
        else
            victory.SetActive(true);

        ended = true;
    }
}
