using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventsManager : MonoBehaviour
{
    public static EventsManager instance;

    public event Action<string> onRecoil;
    private void Awake()
    {
        instance = this;
    }

    public void RecoilEvent(string weoponName)
    {
        onRecoil?.Invoke(weoponName);
    }

}
