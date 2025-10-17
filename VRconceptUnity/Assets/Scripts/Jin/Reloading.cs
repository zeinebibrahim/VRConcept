using System;
using System.Collections;
using UnityEngine;

public class Reloading : MonoBehaviour
{
    // Time it takes to reload the weapon (in seconds)
    [SerializeField] private float reloadTime;

    // Maximum amount of ammo the gun can hold
    [SerializeField] private int maxAmmo;

    // Current ammo available before reloading
    private int currentAmmo;

    // Flag to check if the gun is currently reloading
    private bool reloading = false;

    // Returns true if the gun is reloading, false otherwise
    public bool GetReloadStatus()
    {
        return reloading;
    }

    // Sets the current ammo count
    public void SetCurrentAmmo(int pCurrentAmmo)
    {
        currentAmmo = pCurrentAmmo;
    }

    // Returns the current ammo count
    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }

    void Start()
    {
        // Initialize the gun with full ammo when the game starts
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        Debug.Log($"Ammo: {currentAmmo} | Reloading: {reloading}");
        // If ammo is empty and the gun is not already reloading, start reload coroutine
        if (currentAmmo == 0 && !reloading)
        {
            StartCoroutine(ReloadGun());
        }
    }

    // Coroutine that handles reloading over time
    IEnumerator ReloadGun()
    {
        reloading = true; // Set reloading state to true
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime); // Wait for reload time to finish
        reloading = false; // Done reloading
        currentAmmo = maxAmmo; // Reset ammo to full
        Debug.Log("Reload complete!");
    }
}
