using UnityEngine;

public class UnitInstancer : MonoBehaviour
{
    public GameObject unit;
    private ShopController shopController;

    void Start()
    {
        shopController = GetComponentInParent<ShopController>();
    }

    public void OnMouseDown()
    {
        shopController.AddUnitToQueue(unit);
    }
}
