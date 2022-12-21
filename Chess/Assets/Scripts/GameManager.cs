using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenMoves;
    private float moveTimer;
    private TeamColor playersTurn;
    [SerializeField] private bool spaceBarToMove;

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
        
        //reload scene if you press R
        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /// <summary>
    /// Every X seconds, take a turn for a different player by trying to brute force move pieces until one moves
    /// </summary>
    private void NewMoveLogic() {
        if (spaceBarToMove) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                StartNewMove(null);
            }
        }
        else {
            if (moveTimer < timeBetweenMoves) {
                moveTimer += Time.deltaTime;
            }
            else { //start a new move
                moveTimer = 0; //reset timer
                StartNewMove(null);
            }
        }
    }

    /// <summary>
    /// Start attempting to move a piece. Set pieceSelected to null if you want a random piece moved.
    /// </summary>
    /// <param name="pieceSelected"></param>
    private void StartNewMove(Piece pieceSelected) {
        bool moveMade = false;
        while (!moveMade) {
            Piece pieceToMove;
            if (pieceSelected != null) {
                pieceToMove = pieceSelected;
            }
            else {
                int randomElement = Random.Range(0, whitePieces.Count); //assuming that whitePiece and blackPieces have the same count
                if (playersTurn == TeamColor.White) {
                    pieceToMove = whitePieces[randomElement];
                }
                else {
                    pieceToMove = blackPieces[randomElement];
                }
            }
            for (int i = 0; i < 100; i++) { //try brute force moving this piece 100 times before we give up and move on to another piece

                int posX = Random.Range(0, 8);
                int posY = Random.Range(0, 8);
                if (pieceToMove.GetComponent<Movement>().CanIMoveHere(posX, posY)) { //if I can move this piece to the randomly selected location

                    //move the piece
                    pieceToMove.MovePiece(posX, posY);

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

    /// <summary>
    /// Return the piece at this position (or null if there is no piece here).
    /// </summary>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <returns></returns>
    public Piece PieceAtThisPosition(int posX, int posY) {
        for (int i = 0; i < pieces.Length; i++) {
            if (pieces[i].PosX == posX && pieces[i].PosY == posY) { //if this piece is at the position we are checking for
                return pieces[i].GetComponent<Piece>();
            }
        }
        return null;
    }

}
