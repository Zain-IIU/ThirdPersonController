using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeoponPickup : MonoBehaviour
{
    [SerializeField]
    GameObject weoponPrefab;
    [SerializeField]
    WeoponType pickUpType;

    [Header("Weopon Positions")]
    [SerializeField]
    Transform AssualtPos;
    [SerializeField]
    Transform SmokePos;
    [SerializeField]
    Transform GunPos;
    [SerializeField]
    Transform RocketPos;
    [SerializeField]
    Transform SniperPos;
    [SerializeField]
    Transform ShotGunPos;

    RayCastWeopon Newweopon;

    GameObject weoponParent;
    ChangeWeopon playerWeopon;

    public static int childCounter = 0;

    private void Awake()
    {
        weoponParent = GameObject.FindObjectOfType<ChangeWeopon>().gameObject;
        playerWeopon = weoponParent.GetComponent<ChangeWeopon>();
    }
    private void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerWeopon.hasWeopon = true;
            Newweopon = Instantiate(weoponPrefab).GetComponent<RayCastWeopon>();
            
            switch (pickUpType)
            {
                case WeoponType.RPG:

                    if (RocketPos.childCount > 0)
                        Destroy(RocketPos.GetChild(0).gameObject);
                    else
                        RocketPos.SetSiblingIndex(childCounter);

                    playerWeopon.curWeoponIndex = childCounter;
                    Newweopon.transform.parent = RocketPos;
                    RocketPos.gameObject.SetActive(true);
                    ShotGunPos.gameObject.SetActive(false);
                    GunPos.gameObject.SetActive(false);
                    SniperPos.gameObject.SetActive(false);
                    AssualtPos.gameObject.SetActive(false);
                    
                    break;
                case WeoponType.ShotGun:
                    if (ShotGunPos.childCount > 0)
                        Destroy(ShotGunPos.GetChild(0).gameObject);
                    else
                        ShotGunPos.SetSiblingIndex(childCounter);

                    playerWeopon.curWeoponIndex = childCounter;
                    Newweopon.transform.parent = ShotGunPos;
                    RocketPos.gameObject.SetActive(false);
                    ShotGunPos.gameObject.SetActive(true);
                    GunPos.gameObject.SetActive(false);
                    SniperPos.gameObject.SetActive(false);
                    AssualtPos.gameObject.SetActive(false);
                  
                    break;
                case WeoponType.Gun:
                    if (GunPos.childCount > 0)
                        Destroy(GunPos.GetChild(0).gameObject);
                    else
                        GunPos.SetSiblingIndex(childCounter);

                    playerWeopon.curWeoponIndex = childCounter;
                    Newweopon.transform.parent = GunPos;
                    RocketPos.gameObject.SetActive(false);
                    ShotGunPos.gameObject.SetActive(false);
                    GunPos.gameObject.SetActive(true);
                    SniperPos.gameObject.SetActive(false);
                    AssualtPos.gameObject.SetActive(false);
                    

                    break;
                case WeoponType.Sniper:
                    if (SniperPos.childCount > 0)
                        Destroy(SniperPos.GetChild(0).gameObject);
                    else
                        SniperPos.SetSiblingIndex(childCounter);

                    playerWeopon.curWeoponIndex = childCounter;
                    Newweopon.transform.parent = SniperPos;
                    RocketPos.gameObject.SetActive(false);
                    ShotGunPos.gameObject.SetActive(false);
                    GunPos.gameObject.SetActive(false);
                    SniperPos.gameObject.SetActive(true);
                    AssualtPos.gameObject.SetActive(false);
                   

                    break;
                case WeoponType.Rifle:
                    if (AssualtPos.childCount > 0)
                        Destroy(AssualtPos.GetChild(0).gameObject);
                    else
                        AssualtPos.SetSiblingIndex(childCounter);
                    playerWeopon.curWeoponIndex = childCounter;
                    Newweopon.transform.parent = AssualtPos;
                    RocketPos.gameObject.SetActive(false);
                    ShotGunPos.gameObject.SetActive(false);
                    GunPos.gameObject.SetActive(false);
                    SniperPos.gameObject.SetActive(false);
                    AssualtPos.gameObject.SetActive(true);
                    
                    break;
                case WeoponType.Smoke:
                    if (SmokePos.childCount > 0)
                        Destroy(SmokePos.GetChild(0).gameObject);
                    else
                        SmokePos.SetSiblingIndex(childCounter);
                    playerWeopon.curWeoponIndex = childCounter;
                    Newweopon.transform.parent = SmokePos;
                    RocketPos.gameObject.SetActive(false);
                    ShotGunPos.gameObject.SetActive(false);
                    GunPos.gameObject.SetActive(false);
                    SniperPos.gameObject.SetActive(false);
                    AssualtPos.gameObject.SetActive(false);
                    SmokePos.gameObject.SetActive(true);

                    break;
            }
            childCounter++;
            ChangeWeopon.singleton.IncrementWeopons();
            Newweopon.transform.localPosition = Vector3.zero;
            Newweopon.transform.localRotation = Quaternion.identity;
            ActiveWeopon.instance.EquipWeopon(Newweopon);

            Destroy(gameObject);
        }
    }
}
