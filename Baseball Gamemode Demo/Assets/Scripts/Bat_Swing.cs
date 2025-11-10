using System;
using System.Collections;
using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

// public class Bat_Swing : MonoBehaviour
// {
//     [SerializeField] private Transform bat;
//     InputAction batSwingAction;


//     private Vector3 startSwing = new Vector3(-45, -45, 0);   // Bat cocked back (ready position)
//     private Vector3 contactSwing = new Vector3(0, -90, 0); // Contact point
//     private Vector3 endSwing = new Vector3(-25, -165, 0);    // Follow through

//     private Vector3 startPos = new Vector3(0, 0, -0.4f);    // Back and to the side
//     private Vector3 contactPos = new Vector3(0, 0, 0);          // Center (original position)
//     private Vector3 endPos = new Vector3(-0.6f, 0, 0.2f);       // Forward and across

//     private bool isSwinging = false;

//     Quaternion startingRotation;

//     Vector3 startingPosition;

//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         // Find the references to the "batSwing"
//         batSwingAction = InputSystem.actions.FindAction("batSwing");
//         batSwingAction.Enable();

//         startingRotation = Quaternion.Euler(startSwing);
//         startingPosition = bat.localPosition;
        
//         bat.localRotation = startingRotation;
//         bat.localPosition = startingPosition + startPos;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // Left mouse button
//         if (batSwingAction.IsPressed() && !isSwinging)
//         {
//             StartCoroutine(Bat_Swing_On_Click());
//         }
//     }

//     // Add something for the bat breaking if miss sweat spot and contact and distant caluation is different
//     // Maybe add in other types of bats the do not break like metal (bbcore)

//    private IEnumerator Bat_Swing_On_Click()
//     {
//         isSwinging = true;

//         float swingDuration = 0.4f;
//         float elapsed = 0f;

//         Quaternion startRot = Quaternion.Euler(startSwing);
//         Quaternion contactRot = Quaternion.Euler(contactSwing);
//         Quaternion endRot = Quaternion.Euler(endSwing);

//         while (elapsed < swingDuration)
//         {
//             elapsed += Time.deltaTime;
//             float t = elapsed / swingDuration;
            
//             if (t < 0.6f)
//             {
//                 float halfT = t / 0.6f;
//                 halfT = halfT * halfT;
                
//                 bat.localRotation = Quaternion.Slerp(startRot, contactRot, halfT);
//                 // Add position animation
//                 bat.localPosition = Vector3.Lerp(startingPosition + startPos, startingPosition + contactPos, halfT);
//             }
//             else
//             {
//                 float halfT = (t - 0.6f) / 0.4f;
//                 halfT = 1 - (1 - halfT) * (1 - halfT);
                
//                 bat.localRotation = Quaternion.Slerp(contactRot, endRot, halfT);
//                 // Add position animation
//                 bat.localPosition = Vector3.Lerp(startingPosition + contactPos, startingPosition + endPos, halfT);
//             }
            
//             yield return null;
//         }

//         bat.localRotation = endRot;
//         bat.localPosition = startingPosition + endPos;
//         Debug.Log("Swing Complete");

//         yield return new WaitForSeconds(0.5f);
        
//         // Return to ready position
//         elapsed = 0f;
//         while (elapsed < 0.5f)
//         {
//             elapsed += Time.deltaTime;
//             float t = elapsed / 0.5f;
//             bat.localRotation = Quaternion.Slerp(endRot, startRot, t);
//             bat.localPosition = Vector3.Lerp(startingPosition + endPos, startingPosition + startPos, t);
//             yield return null;
//         }

//         bat.localRotation = startRot;
//         bat.localPosition = startingPosition + startPos;
//         isSwinging = false;
//     }

//     void FixedUpdate()
//     {
        
//     }
// }
