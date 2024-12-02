using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class Board : Singleton<Board>
{
    [SerializeField] private GridLayoutGroup GridLayoutGroupBoard;
    [SerializeField] private Transform BoardTransform;
    [SerializeField] private Transform PrefabCell;
    [SerializeField] private GameObject Text_coler_X;
    [SerializeField] private GameObject Text_coler_O;
    public bool isShowTextColer_X = false;
    public bool isShowCell = false;

    public int BoardSize;
    public int indexChange;

    


    public void CreateGame()
    {
        GridLayoutGroupBoard.constraintCount = BoardSize;
        ScaleSizeBoard();
        CreateBoard();

    }


    private void Update()
    {
        SetActiveText_Coler();
    }

    private void CreateBoard()
    {
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                Transform cell = Instantiate(PrefabCell, BoardTransform);
                int x = i;
                int y = j;
                cell.GetComponent<Cell>().Initialize(x, y);

                HideCell();
            }
        }
    }

    private void HideCell()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            isShowCell = false ;
        }
    }

    public void ShowCell()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true); 
            isShowCell = true ;
        }
    }


    public void DestroyCell()
    {
        Text_coler_X.SetActive(false);
        Text_coler_O.SetActive(false);
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

    }




    private void ScaleSizeBoard()
    {
        if(BoardSize ==3)
        {
            GridLayoutGroupBoard.cellSize = new Vector2 (300,300);
        }
        else if(BoardSize == 4)
        {
            GridLayoutGroupBoard.cellSize = new Vector2(200, 200);

        }
        else if (BoardSize == 5)
        {
            GridLayoutGroupBoard.cellSize = new Vector2(180, 180);

        }
        else if (BoardSize > 5&& BoardSize <= 9)
        {
            GridLayoutGroupBoard.cellSize = new Vector2(100, 100);

        }
        else
        {
            GridLayoutGroupBoard.cellSize = new Vector2(80, 80);

        }
    }

    private void SetActiveText_Coler()
    {
        if (isShowCell == false )
        {
            Debug.Log("no Show Text");

            return;
        }
        if (indexChange%2==0 && isShowTextColer_X == false)
        {
            Text_coler_X.SetActive(true);
            Text_coler_O.SetActive(false);
            isShowTextColer_X = true;
            Debug.Log("Show Text_coler_X");
        }else if(indexChange % 2 != 0 && isShowTextColer_X == true)
        {
            Text_coler_X.SetActive(false);
            Text_coler_O.SetActive(true);
            isShowTextColer_X = false;
            Debug.Log("Show Text_coler_O");

        }
    }



}
