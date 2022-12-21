using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeamColor { White, Black }

public class Piece : MonoBehaviour
{
    [SerializeField] private int posX;
    [SerializeField] private int posY;
    [SerializeField] private TeamColor team;
    private bool alive;
    private bool hasMoved;

    public int PosX { get { return posX; } }
    public int PosY { get { return posY; } }
    public TeamColor Team { get { return team; } }
    public bool Alive { get { return alive; } }
    public bool HasMoved { get { return hasMoved; } }

    void Start() {
        //set posX and posY based on the location in the scene. in the future this should go the other way around - posX and posY should decide where each piece starts on the scene
        posX = (int)Mathf.Round(transform.position.x);
        posY = (int)Mathf.Round(transform.position.z);
    }

    /// <summary>
    /// Move this piece to this new position
    /// </summary>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    public void MovePiece(int posX, int posY) {
        this.posX = posX;
        this.posY = posY;
        transform.position = new Vector3(posX, transform.position.y, posY);
        hasMoved = true;
    }

    /// <summary>
    /// This piece has been captured. It will be removed from the board and made innactive.
    /// </summary>
    public void Captured() {
        alive = false;
        MovePiece(-99, -99); //moving the piece off the board for safety
        gameObject.SetActive(false);
    }

}
