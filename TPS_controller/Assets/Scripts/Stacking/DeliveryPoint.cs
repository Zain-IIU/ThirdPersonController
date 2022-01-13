using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPoint : MonoBehaviour
{
    [SerializeField] Transform[] deliveryPos;

    int curItem;

    // Start is called before the first frame update
    void Start()
    {
        curItem = 0;
    }

    public void IncrementItemValue()
    {
        curItem++;
    }
    public Transform GetItem(int index)
    {
        return deliveryPos[index];
    }
}
