using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeWeopon : MonoBehaviour
{
    public static ChangeWeopon singleton;
    [SerializeField]
    Transform[] weoponsList;

    public bool hasWeopon;

    public int curWeoponIndex = 0;

    int totalGun;

    private void Awake()
    {
        singleton = this;
    }
    void Start()
    {
        totalGun = 0;
    }
    private void Update()
    {
        ChangeWeapons();
    }

    private void ChangeWeapons()
    {
        if (weoponsList != null && hasWeopon && totalGun > 1)
        {

            int previousWeopon = curWeoponIndex;

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (curWeoponIndex > totalGun - 2)
                    curWeoponIndex = 0;
                else
                {
                    curWeoponIndex++;

                }

            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (curWeoponIndex <= 0)
                    curWeoponIndex = totalGun - 1;
                else
                {
                    curWeoponIndex--;

                }


            }

            if (curWeoponIndex != previousWeopon)
            {
                SelectWeopon();

            }

        }
    }


    public void SelectWeopon()
    {
        int i = 0;

       
            foreach (Transform child in transform)
            {
                if (i == curWeoponIndex && child.childCount > 0)
                {
                    child.gameObject.SetActive(true);
                    ActiveWeopon.instance.EquipWeopon(child.GetChild(0).GetComponent<RayCastWeopon>());
                }

                else
                    child.gameObject.SetActive(false);

                i++;
            }
        
       
    }
    public void IncrementWeopons()
    {
        totalGun++;
    }

}

