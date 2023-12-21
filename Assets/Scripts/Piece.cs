
using UnityEngine;

public class Piece : MonoBehaviour 
{

    [SerializeField] private SpriteRenderer spriteRenderer;
    public bool isLocked;
    public int pieceIndex;


    public void SetPiece(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
        Debug.Log("a");
        
    }
}
