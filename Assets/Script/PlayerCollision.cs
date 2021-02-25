using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerCollision : MonoBehaviour
{
    public int rewardCount = 0;
    [SerializeField]
    TMP_Text rewardCountText;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player collide: " + collision.collider.name);

        if (collision.collider.tag == "Reward")
        {
            //if player collide reward object, reward object is added to the parent object and set position, rotation and size.
            collision.transform.GetChild(0).gameObject.SetActive(false);
            collision.transform.GetChild(1).gameObject.SetActive(false);
            collision.transform.SetParent(this.transform);
            collision.transform.localPosition = new Vector3(0, 0, -1 - rewardCount);
            collision.transform.localRotation = Quaternion.Euler(0, 0, 0);
            collision.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            rewardCount++;
            rewardCountText.text = "X" +  rewardCount.ToString();
            Debug.Log("Reward Count: " + rewardCount);
        }

        //Level pass
        if(collision.collider.tag == "FinishArea")
        {
            Debug.Log("Level Pass");
            PlayerPrefs.SetInt("RewardCount", rewardCount);
            rewardCount = 0;
            FinishLevel.instance.FinishLevelGame();
        }
    }
}
