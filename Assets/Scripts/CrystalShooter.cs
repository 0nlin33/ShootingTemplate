using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrystalShooter : MonoBehaviour
{
    public GameObject[] crystalPrefab;      // Prefab for the crystal
    public Transform shootingPoint;      // Point from where the crystals are shot
    public float shootingForce = 40f;    // Force applied to shoot the crystal
    public int nextCrystal;
    public int currentCrystal;


    public SpawnGrid gridInfo;
    private Camera mainCamera;


    private void Start()
    {
        currentCrystal = GenerateNumber();
        nextCrystal= GenerateNumber();
        // Get a reference to the main camera
        mainCamera = Camera.main;
    }

    private void Update()
    {
/*#if UNITY_EDITOR
        // Check for input to shoot the crystal using the new Input System

        if (Input.GetMouseButtonDown(0))
        {
            Shootcrystal();
            currentCrystal = nextCrystal;

            nextCrystal = GenerateNumber();
        }*/
//#else
        if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Shootcrystal();
            currentCrystal = nextCrystal;

            nextCrystal = GenerateNumber();
        }

//#endif
    }

    private void Shootcrystal()
    {
        GameObject shootingPrefab = crystalPrefab[currentCrystal];

        // Calculate the direction from the shooting point to the mouse position
        Vector3 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 worldTouchPosition = mainCamera.ScreenToWorldPoint(touchPosition);
        Vector2 direction = (worldTouchPosition - shootingPoint.position).normalized;

        // Instantiate a new crystal at the shooting point
        GameObject newCrystal = Instantiate(shootingPrefab, shootingPoint.position, Quaternion.identity);

        newCrystal.AddComponent<Rigidbody2D>();

        // Apply shooting force to the crystal in the calculated direction
        Rigidbody2D crystalRigidbody = newCrystal.GetComponent<Rigidbody2D>();
        crystalRigidbody.AddForce(direction * shootingForce, ForceMode2D.Impulse);
    }

    public int GenerateNumber()
    {
        return Random.Range(0, crystalPrefab.Length);
    }

    
}