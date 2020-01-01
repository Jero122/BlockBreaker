using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaddleMovement : MonoBehaviour
{
    //configuration parameters
    [SerializeField] public float screenWidthInUniuts;
    [SerializeField] public float minX = 1f;
    [SerializeField] public float maxX = 15f;


    void Update()
    {
        float mousePosInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUniuts;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX,maxX);
        transform.position = paddlePos;
    }
}
