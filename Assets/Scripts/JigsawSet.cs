using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;
using System.Linq;

public class JigsawSet : MonoBehaviour
{
    [SerializeField] private Sprite mainImage;
    [SerializeField] private int pieceAmount;
    [SerializeField] private GameObject piecePrefab;
    [SerializeField] private Piece[,] piece;
    [SerializeField] private Sprite[] cutImage;
    [SerializeField] private List<Sprite> spriteList = new();
    [SerializeField] private List<GameObject> pieceList = new();



    private void Start()
    {
        CreateBoard(pieceAmount);

    }
    private Sprite CutImage(int x, int y)
    {
        for (int i = 0; i < mainImage.texture.width; i++)
        {
            for (int j = 0; j < mainImage.texture.height; j++)
            {
                Rect rect = new Rect(i * (mainImage.texture.width / pieceAmount),
                                        j * (mainImage.texture.height / pieceAmount),
                                        mainImage.texture.width / pieceAmount,
                                        mainImage.texture.height / pieceAmount);
                spriteList.Add(GetCutImagePiece(mainImage, rect));
                if (i == x && j == y)
                {
                    int index = i * mainImage.texture.height + j;
                    return spriteList[index];
                }
            }
        }
        return null;
    }

    private Sprite GetCutImagePiece(Sprite original, Rect rect)
    {
        Texture2D tex = new Texture2D((int)rect.width, (int)rect.height);
        Color[] pixels = original.texture.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height);
        tex.SetPixels(pixels);
        tex.Apply();
        Sprite cutSprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
        return cutSprite;
    }
    private void CreateBoard(int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                //piece[i, j] = new Piece();
                GameObject newPiece = Instantiate(piecePrefab);
                newPiece.GetComponent<Piece>().SetPiece(CutImage(i, j));
                pieceList.Add(newPiece);
            }
        }
    }


}
