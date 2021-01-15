using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float ScreenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    GameState gameState;
    Ball ball;

    void Start()
    {
        gameState = FindObjectOfType<GameState>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        print(mousePosInUnits);
        Vector2 paddlePos = new Vector2(this.transform.position.x, this.transform.position.y);
        // paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        paddlePos.x = Mathf.Clamp(getXPos(), minX, maxX);

        this.transform.position = paddlePos;
    }

    private float getXPos()
    {
        if (gameState.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        }
    }
}
