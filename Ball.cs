using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float moveSpeed = 12.0f;

    public Vector2 ballDirection = Vector2.left;

    private float playerPaddleHeight, playerPaddleWidth, computerPaddleHeight, computerPaddleWidth, playerPaddleMaxX, computerPaddleMaxX, computerPaddleMaxY, computerPaddleMinY, computerPaddleMinX, playerPaddleMaxY, playerPaddleMinX, playerPaddleMinY, ballWidth, ballHeight;

    private GameObject playerPaddle, computerPaddle;

    public void Start() {
        playerPaddle = GameObject.Find("paddleplayer");
        computerPaddle = GameObject.Find("computerPaddle");

        playerPaddleHeight = playerPaddle.transform.GetComponent<SpriteRenderer> ().bounds.size.y;
        playerPaddleWidth = playerPaddle.transform.GetComponent<SpriteRenderer> ().bounds.size.x;
        computerPaddleHeight = computerPaddle.transform.GetComponent<SpriteRenderer> ().bounds.size.y;
        computerPaddleWidth = computerPaddle.transform.GetComponent<SpriteRenderer> ().bounds.size.x;
        ballHeight = transform.GetComponent<SpriteRenderer> ().bounds.size.y;
        ballWidth = transform.GetComponent<SpriteRenderer> ().bounds.size.x;

        playerPaddleMaxX = playerPaddle.transform.localPosition.x + playerPaddleWidth / 2;
        playerPaddleMinX = playerPaddle.transform.localPosition.x - playerPaddleWidth / 2;

        computerPaddleMaxX = computerPaddle.transform.localPosition.x - computerPaddleWidth / 2;
        computerPaddleMinX = computerPaddle.transform.localPosition.x + computerPaddleWidth / 2;

    }

    public void Update()
    {
        Move();
    }
    public void Reset()
    {
    }
    bool CheckCollision()
    {
        playerPaddleMaxY = playerPaddle.transform.localPosition.y + playerPaddleHeight / 2;
        playerPaddleMinY = playerPaddle.transform.localPosition.y - playerPaddleHeight / 2;

        computerPaddleMaxY = computerPaddle.transform.localPosition.y + computerPaddleHeight / 2;
        computerPaddleMinY = computerPaddle.transform.localPosition.y - computerPaddleHeight / 2;

        if(transform.localPosition.x - ballWidth / 2 < playerPaddleMaxX && transform.localPosition.x + ballWidth / 2 > playerPaddleMinX)
        {
            if(transform.localPosition.y - ballHeight / 2 < playerPaddleMaxY && transform.localPosition.y + ballHeight / 2 > playerPaddleMinY)
            {
                ballDirection = Vector2.right;
                transform.localPosition = new Vector3 (playerPaddleMaxX + ballWidth / 2, transform.localPosition.y, transform.localPosition.z);
                return true;
            }
        }

        return false;
    }

    void Move()
    {
        CheckCollision();
        transform.localPosition += (Vector3)ballDirection * moveSpeed * Time.deltaTime;
    }

}
