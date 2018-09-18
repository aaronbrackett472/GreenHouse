using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour{

    public int type;
    public MatchGameLogic mgl;
    public int row;
    public int col;

    // Constructor

    public Card construct(int myType, int myRow, int myCol)
    {
        type = myType;
        row = myRow;
        col = myCol;
        mgl = FindObjectOfType<MatchGameLogic>();
        return (this);
    }

    public void OnMouseDown()
    {
        mgl.pickCard(this);
    }

    public void reveal()
    {
        if (type == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        if (type == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (type == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if (type == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (type == 4)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }

    }

    public void hide()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
