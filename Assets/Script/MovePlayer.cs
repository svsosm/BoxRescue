using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    TMP_Text swipeText;
    [SerializeField]
    TMP_Text moveText;
    [SerializeField]
    GameObject finishArea;
    float speed;
    int i;
    // Update is called once per frame


    void FixedUpdate()
    {
        //if player drew line, move.
        if(DrawLine.instance.isMovePlayer)
        {
            finishArea.transform.GetChild(1).gameObject.SetActive(false);
            swipeText.gameObject.SetActive(false);
            moveText.gameObject.SetActive(true);
            if(Input.GetMouseButton(0))
            {
                moveText.gameObject.SetActive(false);
                StartCoroutine(MovePlayerOnLine());
            }
        }
    }


    IEnumerator MovePlayerOnLine()
    {
        speed = 20 * Time.fixedDeltaTime;
        Vector3 startPos = transform.position;
        Vector3 endPos = DrawLine.instance.pointsList[i];
        if (startPos != endPos)
        {
            transform.position = Vector3.Lerp(startPos, endPos, speed); //change player position
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(endPos - startPos), speed); //change player rotation
            i++;
        }
        yield return new WaitUntil(() => i == DrawLine.instance.pointsList.Count);

        DrawLine.instance.isMovePlayer = false;
    }
}
