using System;
using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Bat_Swing : MonoBehaviour
{

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

    private IEnumerator Bat_Swing_On_Click()
    {

        isSwinging = true;

        // Smooth bating animation math 

        // Maybe try Lerp or Slerp

        Debug.Log("Swing");


        // Gives the animation 3 second cooldown before going to next interation
        yield return new WaitForSeconds(3f);

        isSwinging = false;
    }

    void FixedUpdate()
    {
        
    }
}
