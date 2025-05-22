using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    // Start is called before the first frame update

    int row = 4;

    int pR;
    int pC;
    void Start()
    {
        pR = GetComponent<ChessPlayerPlacementHandler>().row;
        pC = GetComponent<ChessPlayerPlacementHandler>().column;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showPawnHightlight()
    {
        GetComponent<BoxCollider2D>().enabled = false; //temporary disable
        shootPawnRayCast();

        if(row!=pR)
        instantiateHighlight();

        //reset
        GetComponent<BoxCollider2D>().enabled = true;   
    }

    void shootPawnRayCast()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 10f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 2f);

        if(hit)
        {
            Debug.Log(hit.collider.name);
            
            //set rowLimit
            row = hit.collider.gameObject.GetComponent<ChessPlayerPlacementHandler>().row;
        }
        else
        {
            if (pR > 1)
                row = pR+2;
            else
                row = pR+3;
        }
    }

    void instantiateHighlight()
    {
        int limit = pR + 1; //not including pawn's row position
        while(row!=limit) //till front row is not close to pawn's row position
        {
            ChessBoardPlacementHandler.Instance.Highlight(row - 1, pC);
            row--;
        }
    }
}
