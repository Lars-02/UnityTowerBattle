using UnityEngine;
using UnityEngine.UI;

public class UnitInstancer : MonoBehaviour
{
    public GameObject unit;
    private ShopController shopController;

    void Start()
    {
        shopController = GetComponentInParent<ShopController>();
        GetComponentInChildren<Text>().text = unit.GetComponent<UnitController>().cost.ToString();
    }

    public void OnMouseDown()
    {
        shopController.AddUnitToQueue(unit);
    }
}
