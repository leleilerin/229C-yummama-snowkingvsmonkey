using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField] private float walkspeed = 2;
    [SerializeField] private bool isPlayer1;
    [SerializeField] private Vector2 borderLeft, borderLeftWall, borderRightWall, borderRight;
    private Transform playermovement;

    // Start is called before the first frame update
    void Awake()
    {
        playermovement = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (WhichPlayerWalk(isPlayer1, true))
        {
            playermovement.position = new Vector2(Mathf.Clamp(playermovement.position.x - walkspeed, BorderLeft(isPlayer1).x, BorderRight(isPlayer1).x), playermovement.position.y);
        }
        else if (WhichPlayerWalk(isPlayer1, false))
        {
            playermovement.position = new Vector2(Mathf.Clamp(playermovement.position.x + walkspeed, BorderLeft(isPlayer1).x, BorderRight(isPlayer1).x), playermovement.position.y);
        }
    }

    bool WhichPlayerWalk(bool one, bool isLeft)
    {
        if (one)
        {
            if (isLeft)
            {
                return Input.GetKey(KeyCode.A);
            }
            else
            {
                return Input.GetKey(KeyCode.D);
            }
        }
        else
        {
            if (isLeft)
            {
                return Input.GetKey(KeyCode.LeftArrow);
            }
            else
            {
                return Input.GetKey(KeyCode.RightArrow);
            }
        }
    }

    Vector2 BorderLeft(bool one)
    {
        if (one)
        {
            return borderLeft;
        }
        else
        {
            return borderRightWall;
        }
    }

    Vector2 BorderRight(bool one)
    {
        if (one)
        {
            return borderLeftWall;
        }
        else
        {
            return borderRight;
        }
    }
    
}
