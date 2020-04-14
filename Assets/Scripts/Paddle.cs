using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //configuration parameters
    [SerializeField] float minx = 1f;
    [SerializeField] float maxx = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    GameStatus thegameStatus;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        thegameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minx, maxx);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (thegameStatus.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
