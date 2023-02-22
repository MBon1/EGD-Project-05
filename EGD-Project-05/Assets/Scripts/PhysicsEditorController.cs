using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEditorController : MonoBehaviour
{
    Camera mainCamera;
    public GameObject selectedObject;

    public PhysicsEditorWindow editorWindow;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip selectSFX;
    [SerializeField] AudioClip deselectSFX;

    private void Awake()
    {
        mainCamera = Camera.main;
        audioSource = this.GetComponent<AudioSource>();
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

            /*Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector2(mousePos.x, mousePos.y), Vector2.zero, 0f);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.gameObject.GetComponent<Collider2D>())
                {
                    selectedObject = hit.collider.gameObject;
                    break;
                }
            }*/

            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(mousePos.x, mousePos.y), Vector2.zero, 0f);

            if (hit)
            {
                selectedObject = hit.collider.gameObject;
                editorWindow.EnablePhysMatWindow(true);
                editorWindow.physMatEditor.SetTargetObject(selectedObject);
                PlaySFX(true);
            }
            else
            {
                editorWindow.EnablePhysMatWindow(false);
                editorWindow.physMatEditor.SetTargetObject(selectedObject);
                PlaySFX(false);
            }            
        }

        /*if (Input.GetKeyDown(KeyCode.R))
        {
            SceneLoader.ReloadScene();
        }*/
    }

    void PlaySFX(bool success)
    {
        AudioClip clip;
        if (success)
        {
            clip = selectSFX;
        }
        else
        {
            clip = deselectSFX;
        }

        audioSource.clip = clip;
        audioSource.Play();
    }
}
