using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class clickDetect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //[SerializeField] GameObject mousePosition;
    void Awake()
    {
        // Initialization, if needed
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("highting!!!");

        checkPieceName();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("clear highlighting");

        ChessBoardPlacementHandler.Instance.ClearHighlights();
    }




    void checkPieceName()
    {
        if (gameObject.name == "Pawn")
        {
            GetComponent<Pawn>().showPawnHightlight();
        }
        if (gameObject.name == "Knight")
        {
            GetComponent<Knight>().showKnightHightlight();
        }
        if(gameObject.name == "Rook")
        {
            GetComponent<Rook>().showRookHightlight();
        }
        if(gameObject.name == "Bishop")
        {
            GetComponent<Bishop>().showBishopHightlight();  
        }
        if(gameObject.name == "Queen")
        {
            GetComponent<Queen>().showQueenHightlight();
        }
    }
}
