using System;
using System.Collections;
using UnityEngine;

public class Reloading : MonoBehaviour
{
    [SerializeField] private float reloadTime;
    [SerializeField] private int maxAmmo;
    private int currentAmmo;
    private bool reloading = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool GetReloadStatus()
    {
        return reloading;
    }
    public void SetCurrentAmmo(int pCurrentAmmo)
    {
        currentAmmo = pCurrentAmmo;
    }
    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentAmmo == 0 || !reloading)
        {
            StartCoroutine(ReloadGun());
        }

    }

    IEnumerator ReloadGun()
    { 
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
        currentAmmo = maxAmmo;
    }
  
}
