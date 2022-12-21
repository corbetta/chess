using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenMoves;
    private float moveTimer;
    private TeamColor playersTurn;

    private Piece[] pieces;
    private List<Piece> whitePieces = new List<Piece>();
    private List<Piece> blackPieces = new List<Piece>();

    void Start()
    {
        playersTurn = TeamColor.White;

        //put all pieces into an array
        pieces = GameObject.FindObjectsOfType<Piece>();
        
        //fill whitePieces and blackPieces with the corresponding pieces 
        for (int i = 0; i < pieces.Length; i++) {
            if (pieces[i].Team == TeamColor.White) {
                whitePieces.Add(pieces[i]);
            }
            else {
                blackPieces.Add(pieces[i]);
            }
        }
    }
    void Update() {
        NewMoveLogic();
    }

    /// <summary>
    /// Every X seconds, take a turn for a different player by trying to brute force move pieces until one moves
    /// </summary>
    private void NewMoveLogic() {
        if (moveTimer < timeBetweenMoves) {
            moveTimer += Time.deltaTime;
        }
        else { //start a new move
           
            moveTimer = 0; //reset timer
            
            bool moveMade = false;
            while (!moveMade) {
                Piece tempPiece;
                int randomElement = Random.Range(0, whitePieces.Count); //assuming that whitePiece and blackPieces have the same count
                if (playersTurn == TeamColor.White) {
                    tempPiece = whitePieces[randomElement];
                }
                else {
                    tempPiece = blackPieces[randomElement];
                }
                for (int i = 0; i < 100; i++) { //try brute force moving this piece 100 times before we give up and move on to another piece

                    int posX = Random.Range(0, 8);
                    int posY = Random.Range(0, 8);
                    if (tempPiece.GetComponent<Movement>().CanIMoveHere(posX, posY)) { //if I can move this piece to the randomly selected location
                        
                        //move the piece
                        tempPiece.MovePiece(posX, posY);

                        //switch playersTurn to the other player
                        if (playersTurn == TeamColor.White) {
                            playersTurn = TeamColor.Black;
                        }
                        else {
                            playersTurn = TeamColor.White;
                        }

                        //and we are done with this move!
                        return;
                    }
                }
            }
        }
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
