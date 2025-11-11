using System;
using System.Collections;
using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Bat_Swing : MonoBehaviour
{
    [SerializeField] private Animator animator;
    InputAction batSwingAction;

    private bool isSwinging = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the references to the "batSwing"
        batSwingAction = InputSystem.actions.FindAction("batSwing");
        batSwingAction.Enable();
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

        animator.SetBool("isSwinging", isSwinging);

        Debug.Log("Swing Complete");

        yield return new WaitForSeconds(2f);

        Debug.Log("Resetting");

        // Return to ready position
        isSwinging = false;

        animator.SetBool("isSwinging", isSwinging);
        
    }

    void FixedUpdate()
    {
        
    }
}
