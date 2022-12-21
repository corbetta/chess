using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Piece[] pieces;

    void Start()
    {
        pieces = GameObject.FindObjectsOfType<Piece>();    
    }
    void Update()
    {
        
    }

    public Piece PieceAtThisPosition(int posX, int posY) {
        for (int i = 0; i < pieces.Length; i++) {
            if (pieces[i].PosX == posX && pieces[i].PosY == posY) { //if this piece is at the position we are checking for
                return pieces[i].GetComponent<Piece>();
            }
        }
        return null;
    }

}
