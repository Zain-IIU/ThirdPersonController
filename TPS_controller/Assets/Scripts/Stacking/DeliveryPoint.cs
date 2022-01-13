using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPoint : MonoBehaviour
{
    [SerializeField] List<Transform> deliveryPos = new List<Transform>();
   
    int curItems;   //to keep track of how  items have been delivered

    // Start is called before the first frame update
    void Start()
    {
        curItems = 0;
    }

    
    //getting the item to be delivered at
    public Transform GetItem(int index)
    {
        return deliveryPos[index];
    }
   
}
