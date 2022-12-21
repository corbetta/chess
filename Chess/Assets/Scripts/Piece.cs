using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeamColor { White, Black }

public class Piece : MonoBehaviour
{
    [SerializeField] private bool alive;
    [SerializeField] private int posX;
    [SerializeField] private int posY;
    [SerializeField] private TeamColor team;

    public bool Alive { get { return alive; } }
    public int PosX { get { return posX; } }
    public int PosY { get { return posY; } }
    public TeamColor Team { get { return team; } }

    public void SetPosition(int posX, int posY) {
        this.posX = posX;
        this.posY = posY;
    }

}
