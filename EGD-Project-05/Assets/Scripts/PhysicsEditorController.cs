using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEditorController : MonoBehaviour
{
    Camera mainCamera;
    public GameObject selectedObject;

    public EditorWindow editorWindow;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Right click
        // Get first object with a Collider2D that was right clicked on
        if (Input.GetMouseButtonDown(1))
        {
            selectedObject = null;
            // Close editor menu

            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector2(mousePos.x, mousePos.y), Vector2.zero, 0f);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.gameObject.GetComponent<Collider2D>())
                {
                    selectedObject = hit.collider.gameObject;
                    break;
                }
            }

            if (selectedObject != null)
            {
                Debug.Log("Target Object: " + selectedObject.name);
                editorWindow.SetTargetObject(selectedObject);
                /*PhysicsMaterial2D currentMaterial = selectedObject.GetComponent<Collider2D>().sharedMaterial;
                if (currentMaterial != null)
                {
                    // Get current material's properties
                }
                // Open editor menu
                selectedObject.GetComponent<Collider2D>().sharedMaterial = editorWindow.GetPhysicsMaterial();*/
            }
        }
    }

    /*public enum PhysicsProperty
    {
        Gravity
    }*/
}
