using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{

    public void PlayAgain()
    {
        /*TO DO:
         * if player want to play again, this method works.
         */
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Play again!");
    }

    public void NextLevel()
    {
        Level.NextLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Player Pass Next Level");
    }
}
