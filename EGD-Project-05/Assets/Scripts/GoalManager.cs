using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] string nextScene = "";
    [SerializeField] AudioSource source;
    bool goalReached = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if collision is the ball
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball") && !goalReached)
            StartCoroutine(GoalReached());
    }

    IEnumerator GoalReached()
    {
        goalReached = true;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        SceneLoader.LoadScene(nextScene);
    }
}
