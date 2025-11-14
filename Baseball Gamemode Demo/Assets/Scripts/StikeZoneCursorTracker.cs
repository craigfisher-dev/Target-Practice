using UnityEngine;
using UnityEngine.InputSystem;

public class StikeZoneCursorTracker : MonoBehaviour
{
    [SerializeField] private BoxCollider visualStrikeZone;  // Your actual strike zone (what player sees)
    
    private Plane strikeZonePlane;
    private Vector3 worldPosition;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; // Keep mouse in game window
        
        strikeZonePlane = new Plane(-Camera.main.transform.forward, visualStrikeZone.transform.position);
    }

    void Update()
    {
        Vector2 screenPosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        
        if (strikeZonePlane.Raycast(ray, out float enter))
        {
            Vector3 targetPosition = ray.GetPoint(enter);
            
            // Clamp to the visualStrikeZone bounds
            worldPosition = visualStrikeZone.ClosestPoint(targetPosition);
        }
        
        transform.position = worldPosition;
    }
}