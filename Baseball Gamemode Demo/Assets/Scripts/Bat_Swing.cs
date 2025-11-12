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

    [SerializeField] public bool Coroutine_Running = false;

    [SerializeField] private bool isSwinging = false;

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
        if (batSwingAction.IsPressed() && !isSwinging && !Coroutine_Running)
        {
            StartCoroutine(Bat_Swing_On_Click());
        }
    }

    // Add something for the bat breaking if miss sweat spot and contact and distant caluation is different
    // Maybe add in other types of bats the do not break like metal (bbcore)

   private IEnumerator Bat_Swing_On_Click()
    {

        Coroutine_Running = true;

        isSwinging = true;

        animator.SetBool("isSwinging", isSwinging);

        Debug.Log("Swing Complete");

        // Have the full animation play
        yield return new WaitForSeconds(3f);

        Debug.Log("Resetting");

        // Return to ready position
        isSwinging = false;

        animator.SetBool("isSwinging", isSwinging);

        Coroutine_Running = false;
    }

    void FixedUpdate()
    {
        
    }
}
