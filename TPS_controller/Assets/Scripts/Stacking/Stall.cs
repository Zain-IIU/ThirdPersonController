using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stall : MonoBehaviour
{

    [SerializeField] List<Transform> stallItems = new List<Transform>();
    //positions from which we will be stealing the items

    int curItem; //how much items have we stolen or how much a specific stall has left


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
        if (index < stallItems.Count )
            return stallItems[index];
        else
            return null; 
    }
    public void RemoveItemAt(int removeTill)
    {
        
            stallItems.RemoveRange(0, removeTill);
       
    }
}
