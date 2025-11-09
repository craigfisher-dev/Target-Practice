using System;
using System.Collections;
using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Bat_Swing : MonoBehaviour
{
    [SerializeField] private Transform bat;
    InputAction batSwingAction;


    private Vector3 startSwing = new Vector3(-45, -45, 0);   // Bat cocked back (ready position)
    private Vector3 contactSwing = new Vector3(0, -90, 0); // Contact point
    private Vector3 endSwing = new Vector3(-45, -175, 0);    // Follow through

    private bool isSwinging = false;

    Quaternion startingRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the references to the "batSwing"
        batSwingAction = InputSystem.actions.FindAction("batSwing");
        batSwingAction.Enable();

        startingRotation = Quaternion.Euler(startSwing);
        bat.localRotation = startingRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Left mouse button
        if (batSwingAction.IsPressed() && !isSwinging)
        {
            StartCoroutine(Bat_Swing_On_Click());
        }
    }

    // Add something for the bat breaking if miss sweat spot and contact and distant caluation is different
    // Maybe add in other types of bats the do not break like metal (bbcore)

   private IEnumerator Bat_Swing_On_Click()
    {
        isSwinging = true;

        float swingDuration = 0.4f;
        float elapsed = 0f;

        Quaternion startRot = Quaternion.Euler(startSwing);
        Quaternion contactRot = Quaternion.Euler(contactSwing);
        Quaternion endRot = Quaternion.Euler(endSwing);

        // Full swing arc: start -> contact -> follow through
        while (elapsed < swingDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / swingDuration;
            
            if (t < 0.5f)
            {
                // First half: windup to contact
                float halfT = t * 2f;
                bat.localRotation = Quaternion.Slerp(startRot, contactRot, halfT);
            }
            else
            {
                // Second half: contact to follow through
                float halfT = (t - 0.5f) * 2f;
                bat.localRotation = Quaternion.Slerp(contactRot, endRot, halfT);
            }
            
            yield return null;
        }

        bat.localRotation = endRot;

        Debug.Log("Swing Complete");

        // Return to ready position
        yield return new WaitForSeconds(0.5f);
        
        elapsed = 0f;
        while (elapsed < 0.5f)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / 0.5f;
            bat.localRotation = Quaternion.Slerp(endRot, startRot, t);
            yield return null;
        }

        bat.localRotation = startRot;
        isSwinging = false;
    }

    void FixedUpdate()
    {
        
    }
}
