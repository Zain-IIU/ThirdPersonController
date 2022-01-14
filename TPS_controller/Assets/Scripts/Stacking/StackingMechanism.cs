using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


//we will be moving stall items from banana Pos to delivery Pos upon stacking and unstacking respectively

public class StackingMechanism : MonoBehaviour
{
    //would change when there's trigger implementation
    [SerializeField]
    Stall stall;
    [SerializeField]
    DeliveryPoint deliverPoint;         
    //````````````````````````````````````````````````

    [SerializeField]
    float lerpingTime;
    [SerializeField]
    Ease easeType;


    [SerializeField] 
    int height, columns, row;              //size of Grid
    [SerializeField]
    Vector3 MaxGrid = new Vector3();          //maxCapacity of grid
    List<bool> flagList = new List<bool>();   //for dynamically alocating isFilled flags

    [SerializeField]
    bool[] isFilled;      //indicating which of the positions are filled

    int curItems = 0;    //indicating curNumberofItem  use to place item when one stall has less items than our capacity

    bool hasStacked = false;   //can't deliver when there is not stacked-up items 

    bool isFull = false;

    private void Start()
    {
        PopulateFillingFlags();
    }

    private void Update()
    {
        //testing prupose
        //if(Input.GetMouseButtonDown(0))
        //{
        //    StackGeneric();
        //}
        //if(Input.GetMouseButtonDown(1) && hasStacked)
        //{
        //    UnStackGeneric();
        //    hasStacked = false;
        //}
        //```````````````

    }

    public void StackGeneric()
    {
        if(CheckCapacity())
        {
            for (int h = 0; h < row; h++)
            {
                for (int r = 0; r < height; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        if (!isFilled[curItems] && stall.GetStallItem(curItems) != null)
                        {
                          
                            stall.GetStallItem(curItems).DOMove(new Vector3(h, r, c), 0.5f).SetEase(easeType);
                            isFilled[curItems] = true;
                            curItems++;
                        }

                    }

                }
            }
            hasStacked = true;
        }
        else
        {
            Debug.Log("No Capacity");
        }
       
        
    }

    public void UnStackGeneric()
    {
        int index = 0;
        for (int h = 0; h < row; h++)
        {
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (stall.GetStallItem(index) != null)
                    {
                        stall.GetStallItem(index).DOMove(deliverPoint.GetItem(index).position, 0.5f).SetEase(easeType);
                        isFilled[index] = false;
                        index++;
                    }

                }

            }
        }
        stall.RemoveItemAt(curItems);
        curItems = 0;
    }

   

    
    private void PopulateFillingFlags()
    {
        for (int i = 0; i < MaxGrid.x * MaxGrid.y * MaxGrid.z; i++)
        {
            flagList.Add(false);
        }
        isFilled = flagList.ToArray();
    }
    private bool CheckCapacity()
    {
        int counter = 0;
        for (int i = 0; i < curItems; i++)
        {
            if (isFilled[i] == true)
                counter++;
        }

        if (counter == row*columns*height)
            return false;
        else
            return true;
    }
}

