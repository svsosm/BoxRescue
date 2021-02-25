using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{

    float angle = 75f; //soldier rotate angle
    int count; //rotate count
    Vector3 targetRotation;


    private void Start()
    {
        CheckSoldierPosition(angle);
        StartCoroutine(RotateSoldierClockwise(Quaternion.Euler(targetRotation), 2));
    }


    IEnumerator RotateSoldierClockwise(Quaternion target, float duration)
    {
        Debug.Log("Soldier rotate clockwise");
        float time = 0;
        Quaternion startValue = Quaternion.Euler(transform.eulerAngles);
       
        while(time < duration)
        {
            transform.rotation = Quaternion.Lerp(startValue, target, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = target;
        CheckSoldierPosition(-angle);
        StartCoroutine(RotateSoldierCounterClockWise(Quaternion.Euler(targetRotation), 2));

    }

    IEnumerator RotateSoldierCounterClockWise(Quaternion target, float duration)
    {
        Debug.Log("Soldier rotate counter clockwise");
        float time = 0;
        Quaternion startValue = Quaternion.Euler(transform.eulerAngles);

        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startValue, target, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = target;

        CheckSoldierPosition(angle);
        StartCoroutine(RotateSoldierOneTime(Quaternion.Euler(targetRotation)));
    }


    IEnumerator RotateSoldierOneTime(Quaternion target)
    {
        Debug.Log("Soldier rotate one time!");
        Quaternion startValue = Quaternion.Euler(transform.eulerAngles);
        transform.rotation = Quaternion.Lerp(startValue, target, 0);
        yield return null;
        transform.rotation = target;
        count++;
        CheckSoldierPosition(angle);
        if(count == 3)
        {
            StartCoroutine(RotateSoldierStarterPosition(Quaternion.Euler(targetRotation)));
        }
        else
        {
            StartCoroutine(RotateSoldierClockwise(Quaternion.Euler(targetRotation), 2));
        }
    }
    //if soldier on right or left of the screen, dont turning around and get back to the beginning.
    IEnumerator RotateSoldierStarterPosition(Quaternion target)
    {
        Debug.Log("Soldier rotate starter position!");
        count = 0;
        Quaternion startValue = Quaternion.Euler(transform.eulerAngles);
        transform.rotation = Quaternion.Lerp(startValue, target, 1);
        yield return null;
        transform.rotation = target;
        CheckSoldierPosition(angle);
        StartCoroutine(RotateSoldierClockwise(Quaternion.Euler(targetRotation), 2));

    }

    void CheckSoldierPosition(float angle)
    {
        //while soldier on the right of screen, just rotate 225 degrees. but clockwise
        if (transform.position.x > 1)
        {
            if(count == 3)
            {
                targetRotation = new Vector3(0, 180, 0);
            }
            else
            {
                targetRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + angle, transform.eulerAngles.z);
            }
        }
        //while soldier on the left of screen, rotate 225 degrees, but counter clockwise
        else if (transform.position.x < -1)
        {

            if (count == 3)
            {
                targetRotation = new Vector3(0, -180, 0);
            }
            else
            {
                targetRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - angle, transform.eulerAngles.z);
            }
        }
        else
        {
            ////while soldier on the center of screen. rotate 360 degrees.
            targetRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + angle, transform.eulerAngles.z);
        }
        Debug.Log("Soldier target rotation " + targetRotation);
    }

}
