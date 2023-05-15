/* this script will be used to toggle the alpha property of the ExitImageBackground 
 * when the player passes through the GameEndingTrigger.
 * 
 * This script is a component of the GameEndingTrigger.
 * 
 * Bruce Gustin
 * May 11, 2023
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField] private CanvasGroup caughtBackgroundImageCanvasGroup;

    private float fadeDuration;            // How long the image is visible.
    private float displayImageDuration;    // How long after the image is invisible before the application quits.
    private float timer;                   // Real time.
    private bool isPlayerAtExit;           // True when player collides with trigger.
    private bool isPlayerCaught;           // True when player collides with enemy.

    // Initialized game design fields
    private void Start()
    {
        fadeDuration = 1f;
        displayImageDuration = 1f;
    }

    // Checks if player has triggered caught or exit, then restarts or ends game.
    void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if(isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    public void CaughtPlayer()
    {
        isPlayerCaught = true;
    }

    // Begins unfading action of ending image
    void EndLevel(CanvasGroup image, bool restartGame)
    {
        timer += Time.deltaTime;

        image.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            if (restartGame)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    // Check is player collides with trigger.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }
}

