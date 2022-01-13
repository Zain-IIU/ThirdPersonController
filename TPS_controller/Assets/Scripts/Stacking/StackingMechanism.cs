using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;


//we will be moving stall items from banana Pos to delivery Pos upon stacking and unstacking respectively

public class StackingMechanism : MonoBehaviour
{
    [SerializeField]
    int curPos;  //this is where we will start stacking after we have emptied one stall or have delivered

    [SerializeField]
    Pos[] bananaPoses;

    [SerializeField]
    Stall stall;
    [SerializeField]
    DeliveryPoint deliverPoint;

    

    [SerializeField]
    float lerpingTime;
    [SerializeField]
    Ease easeType;

    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartStacking();
        }
        if(Input.GetMouseButtonDown(1))
        {
            UnStack();
        }


    }
    public void StartStacking()
    {
       for(int i=0;i<bananaPoses.Length;i++)
        {
            if(!bananaPoses[i].isFilled && stall.GetStallItem(i) != null)
            {
                Debug.Log(curPos);
                stall.GetStallItem(i).parent = bananaPoses[i].pos;
                stall.GetStallItem(i).DOLocalMove(Vector3.zero, 0.5f).SetEase(easeType);
                bananaPoses[i].isFilled = true;
                curPos++;
            }
           
        }
       
    }

    public void UnStack()
    {
        
        for (int i = 0; i < bananaPoses.Length; i++)
        {
            if (stall.GetStallItem(i) != null)
            {
                Debug.Log(curPos);
                stall.GetStallItem(i).parent = deliverPoint.GetItem(i);
                stall.GetStallItem(i).DOLocalMove(Vector3.zero, 0.5f).SetEase(easeType);
                bananaPoses[i].isFilled = false;
            }
          
        }
        stall.RemoveItemAt(curPos);
        curPos = 0;

    }
}
