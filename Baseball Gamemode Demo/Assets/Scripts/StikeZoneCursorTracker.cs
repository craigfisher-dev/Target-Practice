using UnityEngine;
using UnityEngine.InputSystem;

public class StikeZoneCursorTracker : MonoBehaviour
{

    [SerializeField] public BoxCollider swingZoneColider;

    [SerializeField] public Vector3 worldPosition;
    [SerializeField] public Vector2 screenPosition;

    [SerializeField] public LayerMask layerToHit;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mouses x,y position in vector2
        screenPosition = Mouse.current.position.ReadValue();

        // Ray from main camera to mouse position
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        // Cast the ray and check if it hits anything on the specified layer
        if (Physics.Raycast(ray, out RaycastHit hitData, 100, layerToHit))
        {
            // If the raycast hits something, get the 3D world position of the hit point
            worldPosition = hitData.point;
        }

        // Move this object to the world position where the ray hit
        transform.position = worldPosition;
    }
}
