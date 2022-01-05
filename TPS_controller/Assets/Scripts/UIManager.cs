using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("UI Stuff")]

    [SerializeField]
    RectTransform BG_Panel;
    [SerializeField]
    RectTransform loadingBar;
    [SerializeField]
    float tweeningTime;
    [SerializeField]
    Ease easeType;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }
   
    private void Start()
    {
        Invoke(nameof(PlayMainAnimation), 2f);
    }

    public void PlayMainAnimation()
    {
        loadingBar.DOScale(0, tweeningTime/2).OnComplete(() =>
         { 
            BG_Panel.DOScaleY(0, tweeningTime).SetEase(easeType);
         });
        
    }
}
