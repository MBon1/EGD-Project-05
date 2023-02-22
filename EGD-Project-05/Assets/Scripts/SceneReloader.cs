using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneReloader : MonoBehaviour
{
    AudioSource source;
    bool replaying = false;

    [SerializeField] PhysicsEditorController editor;

    private void Awake()
    {
        source = this.GetComponent<AudioSource>();
    }

    public void ReloadScene()
    {
        if (editor.disablePlayerControls)
        {
            replaying = true;
        }

        if (!replaying)
            StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        editor.DisablePlayerControls();
        replaying = true;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        SceneLoader.ReloadScene();
    }
}
