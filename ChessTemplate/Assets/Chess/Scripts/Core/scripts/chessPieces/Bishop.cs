using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : MonoBehaviour
{
    //Logic for diagonal -> (row, row-2)
    int row;
    int col;
    int row2;
    int col2;


    int pR;
    int pC;
    void Start()
    {
        pR = GetComponent<ChessPlayerPlacementHandler>().row;
        pC = GetComponent<ChessPlayerPlacementHandler>().column;
    }

    //Convert angle to Vector2
    Vector2 AngleToVector2(float angleDegrees)
    {
        float radians = angleDegrees * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showBishopHightlight()
    {
        GetComponent<BoxCollider2D>().enabled = false; //temporary disable

        //Shoot raycast diagonally
        shootBishopRayCast1();
        shootBishopRayCast2();

        if (row != pR)
            instantiateHighlight();

        //reset
        GetComponent<BoxCollider2D>().enabled = true;
    }

    void shootBishopRayCast1()
    {
        //Right Diagonal
        Vector2 direc = AngleToVector2(45) ;
        Debug.DrawRay(transform.position, direc * 10f, Color.red);
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direc, 7f);

        if (hit)
        {
            Debug.Log(hit.collider.name);

            //set rowLimit
            row = hit.collider.gameObject.GetComponent<ChessPlayerPlacementHandler>().row -1;
            col = hit.collider.gameObject.GetComponent<ChessPlayerPlacementHandler>().column -1;
        }
        else
        {
            if (pR > 1)
            {
                row = 5;
                col = row + 2;
            }
            else
            {
                row = 5;
                col = row+2;
            }
        }
    }

    void shootBishopRayCast2()
    {
        //Left Diagonal
        Vector2 direc = AngleToVector2(-45);
        Debug.DrawRay(transform.position, direc * 10f, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direc, 7f);

        if (hit)
        {
            Debug.Log(hit.collider.name);

            //set rowLimit
            row2 = hit.collider.gameObject.GetComponent<ChessPlayerPlacementHandler>().row - 1;
            col2 = hit.collider.gameObject.GetComponent<ChessPlayerPlacementHandler>().column - 1;
        }
        else
        {
            if (pR > 1)
            {
                row2 = 5;
                col2 = row2 - 2;
            }
            else
            {
                row2 = 5;
                col2 = row2 - 2;
            }
        }
    }

    void instantiateHighlight()
    {
        int limit = 0; //not including pawn's row position
        while (row != limit) //till front row is not close to pawn's row position
        {
            if (row != pR) 
            ChessBoardPlacementHandler.Instance.Highlight(row, col);
            row--;
            col--;
        }
        /*
        while(row2 != limit)
        {
            if (row2 != pR)
            ChessBoardPlacementHandler.Instance.Highlight(row2, col2);
            row2++;
            col2++;
        }
        */
    }
}
