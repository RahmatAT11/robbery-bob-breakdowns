using UnityEngine;

public class ItemController : MonoBehaviour
{
    private string _itemName = "Default";
    private float _itemValue = 5f;

    public string ItemName
    {
        get
        {
            return _itemName;
        }
    }

    public float ItemValue
    {
        get
        {
            return _itemValue;
        }
    }
}
