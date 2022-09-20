using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayerGoal;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (!isPlayerGoal)
            {
                Debug.Log("Player has scored");
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerScored();
            }
            else
            {
                Debug.Log("Enemy Scored");
                GameObject.Find("GameManager").GetComponent<GameManager>().EnemyScored();
            }
        }

    }
}
