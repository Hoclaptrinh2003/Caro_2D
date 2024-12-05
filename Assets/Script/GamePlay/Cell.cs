using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Sprite x_img;
    public Sprite o_img;
    public Sprite whiteCell_img;
    private int xIndex; 
    private int yIndex;
    public bool isChange = false;

    public Image cellImage;

    void Start()
    {
        cellImage = GetComponent<Image>();
    }

    public void Initialize(int x, int y)
    {
        xIndex = x;
        yIndex = y;
    }

    public void Change_Img()
    {
        if (!isChange && CheckWin.Instance.isWin == false)
        {

            string currentPlayer = Board.Instance.indexChange % 2 == 0 ? "X" : "O";

            if (currentPlayer == "X")
            {
                cellImage.sprite = x_img;
            }
            else
            {
                cellImage.sprite = o_img;
            }
            AudioManager.Instance.BtnCellClick();

            CheckWin.Instance.boardState[xIndex, yIndex] = currentPlayer;

            isChange = true;

            Board.Instance.indexChange++;

            CheckWin.Instance.checkWin();
        }
    }
}
