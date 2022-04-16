using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSkin : MonoBehaviour
{
    public enum ItemType { None, Axe, Baton, Bit, Dagger, Sword }

    [SerializeField] private ItemType _itemType;

    [SerializeField] private List<GameObject> _items = new List<GameObject>();

    private void Start()
    {
        _items[(int)_itemType].SetActive(true);
    }

}
