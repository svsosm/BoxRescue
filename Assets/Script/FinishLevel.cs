using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishLevel : MonoBehaviour
{
    public static FinishLevel instance;

    [SerializeField]
    GameObject finishArea;
    [SerializeField]
    GameObject gameAreaCanvas;
    [SerializeField]
    GameObject finishGameCanvas;
    [SerializeField]
    Animator finishGameAnim;
    [SerializeField]
    Animator rewardCountAnim;

    bool isFinish;
    int targetScore;



    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rewardCountAnim.speed = 0;
    }


    private void Update()
    {
        if(isFinish)
        {
            StartCoroutine(IncrementReward());
        }
    }


    //level pass method
    public void FinishLevelGame()
    {
        Debug.Log("Finish Level " + finishArea.GetComponent<Transform>().parent.gameObject.name);
        gameAreaCanvas.gameObject.SetActive(false);
        finishGameAnim.SetBool("FinishGame", true);
        finishGameCanvas.SetActive(true);
        isFinish = true;
        targetScore = Reward.TotalRewardCount + PlayerPrefs.GetInt("RewardCount");
    }


    //increment total reward
    IEnumerator IncrementReward()
    {
        yield return new WaitForSeconds(1);
        rewardCountAnim.speed = 1;
        yield return new WaitForSeconds(1.5f);
        for (int i = Reward.TotalRewardCount; Reward.TotalRewardCount < targetScore; i++)
        {
            Reward.TotalRewardCount++;
            Reward.instance.ShowReward();
        }

    }

}
