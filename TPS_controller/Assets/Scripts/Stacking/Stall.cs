using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stall : MonoBehaviour
{

    [SerializeField] Transform[] stallItems;

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
    public Transform GetStallItem(int index)
    {
        return stallItems[index];
    }
}
