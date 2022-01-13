using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class StackingMechanism : MonoBehaviour
{

    [SerializeField]
    Pos[] bananaPoses;

    [SerializeField]
    Stall stall;
    [SerializeField]
    DeliveryPoint deliverPoint;
    int curPos;

    [SerializeField]
    float lerpingTime;
    [SerializeField]
    Ease easeType;

    bool isClicked;
    // Start is called before the first frame update
    void Start()
    {
        curPos = 0;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isClicked)
        {
            StartStacking();
            isClicked = true;
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
            stall.GetStallItem(i).parent = bananaPoses[i].pos;
            stall.GetStallItem(i).DOLocalMove(Vector3.zero, 0.5f).SetEase(easeType);
            stall.IncrementItemValue();
            bananaPoses[i].isFilled = true;
            curPos++;
        }
    }
    public void UnStack()
    {
        for (int i = 0; i < bananaPoses.Length; i++)
        {
            bananaPoses[i].pos.DOMove(deliverPoint.GetItem(i).position, lerpingTime).SetEase(easeType);
            deliverPoint.IncrementItemValue();
            bananaPoses[i].isDelivered = true;
            curPos--;
        }
    }
}
