using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reward : MonoBehaviour
{
    public static Reward instance;

    public static int TotalRewardCount = 149;
    [SerializeField]
    TMP_Text rewardText;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        ShowReward();
    }

    public void ShowReward()
    {
        rewardText.text = TotalRewardCount.ToString();
    }



}
