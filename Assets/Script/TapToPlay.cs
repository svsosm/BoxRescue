using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlay : MonoBehaviour
{
    public static TapToPlay instance;

    [SerializeField]
    Animator turnCamera;
    [SerializeField]
    Canvas firstCanvas;
    [SerializeField]
    Canvas secondCanvas;
    [SerializeField]
    GameObject player;

    public bool isPlay;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        turnCamera.speed = 0;
        isPlay = false;
    }

    public void TapToPlayGame()
    {
        StartCoroutine(WaitForAnimationCompleted(turnCamera));
    }

    //if player click tap to player, turn camera and show information.
    IEnumerator WaitForAnimationCompleted(Animator animator)
    {
        animator.speed = 1;
        firstCanvas.gameObject.SetActive(false);
        gameObject.GetComponent<TapToPlay>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        DrawLine.instance.isMovePlayer = false;
        player.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(.2f);
        secondCanvas.gameObject.SetActive(true);
        isPlay = true;
    }

}
