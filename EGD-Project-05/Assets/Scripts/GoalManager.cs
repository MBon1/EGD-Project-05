using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] string nextScene = "";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if collision is the ball
        SceneLoader.LoadScene(nextScene);
    }
}
