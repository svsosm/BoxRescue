using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{

    public static DrawLine instance;

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject finishArea;
    [SerializeField]
    Material boxMaterial;

    private LineRenderer line;
    public bool isMousePressed;
    public bool isMovePlayer;
    public List<Vector3> pointsList;
    private Vector3 mousePos;




    //    -----------------------------------    
    void Awake()
    {
        instance = this;
        // Create line renderer component and set its property
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = 0;
        isMousePressed = false;
        pointsList = new List<Vector3>();

    }
    //    -----------------------------------    
    void Update()
    {
        if(!isMovePlayer && TapToPlay.instance.isPlay)
        {
            // If mouse button down, remove old line and set its color to green
            if (Input.GetMouseButtonDown(0))
            {
                player.transform.GetChild(0).gameObject.SetActive(false);
                isMousePressed = true;
                line.positionCount = 0;
                pointsList.RemoveRange(0, pointsList.Count);
                
            }
            if (Input.GetMouseButtonUp(0))
            {
                TransparencyBoxes(1f);
                isMousePressed = false;
                isMovePlayer = true;
            }
            // Drawing line when mouse is moving(presses)
            if (isMousePressed)
            {
                TransparencyBoxes(0.2f);
                finishArea.transform.GetChild(1).gameObject.SetActive(true);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if(Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Line collide " + hit.collider.name);
                    if(hit.collider.tag == "Reward")
                    {
                        hit.transform.GetChild(0).gameObject.SetActive(false);
                        hit.transform.GetChild(1).gameObject.SetActive(true);

                    }

                    if(hit.collider.tag == "CloseArea")
                    {
                        isMousePressed = false;
                        /*TO DO
                         * if player draw line wrong area, try again.
                         */
                    }

                    DrawLinePath(hit.point);


                }
            }
        }

    }

    //draw line path method.
    void DrawLinePath(Vector3 point)
    {
        mousePos = point;
        mousePos.y = 0.25f;
        pointsList.Add(mousePos);
        line.positionCount = pointsList.Count;
        mousePos.y = 0.1f;
        line.SetPosition(pointsList.Count - 1, mousePos);
    }

    //change box material transparancy, when draw line.
    void TransparencyBoxes(float alphaValue)
    {
        Color tempColor = boxMaterial.color;
        tempColor.a = alphaValue;
        boxMaterial.color = tempColor;
    }



  
}
