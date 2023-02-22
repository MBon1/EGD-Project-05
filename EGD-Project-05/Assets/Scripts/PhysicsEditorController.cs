using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEditorController : MonoBehaviour
{
    Camera mainCamera;
    public GameObject selectedObject;

    public PhysicsSettingsEditorWindow physSettingsEditor;
    public PhysicsMaterialEditorWindow physMatEditor;

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

            physMatEditor.SetTargetObject(selectedObject);
        }
    }

    /*public enum PhysicsProperty
    {
        Gravity
    }*/
}
