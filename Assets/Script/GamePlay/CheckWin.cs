using UnityEngine;

public class CheckWin : Singleton<CheckWin> 
{
    public int winLength;
    public string[,] boardState;
    public bool isWin = false;

    void Start()
    {

        //CheckWin.Instance.boardState = new string[Board.Instance.BoardSize, Board.Instance.BoardSize];
        //CheckWin.Instance.winLength = Board.Instance.BoardSize < 5 ? 3 : 5;
    }


    public void checkWin()
    {
        if (CheckRows() || CheckColumns() || CheckDiagonals())
        {
            Board.Instance.indexChange = Board.Instance.indexChange - 1;
            Debug.Log("Player " + (Board.Instance.indexChange % 2 == 0 ? "X" : "O") + " wins!");
            UImanager.Instance.Popup[0].SetActive(true);    
            isWin = true;
            if(Board.Instance.indexChange % 2 == 0)
            {
                Board.Instance.UpdatePlayerStats(LoginGame.Instance.UsernameText_X.text, LoginGame.Instance.UsernameText_O.text, true);
            }
            else
            {
                Board.Instance.UpdatePlayerStats(LoginGame.Instance.UsernameText_O.text, LoginGame.Instance.UsernameText_X.text,true);

            }
        }
        else if (CheckTie())
        {
            Debug.Log("Hòa");
            UImanager.Instance.Popup[2].SetActive(true);
        }
    }

    private bool CheckRows()
    {
        for (int i = 0; i < Board.Instance.BoardSize; i++)
        {
            for (int j = 0; j <= Board.Instance.BoardSize - winLength; j++)
            {
                bool rowWin = true;
                for (int k = 0; k < winLength; k++)
                {
                    if (boardState[i, j + k] != boardState[i, j] || string.IsNullOrEmpty(boardState[i, j]))
                    {
                        rowWin = false;
                        break;
                    }
                }
                if (rowWin) return true;
            }
        }
        return false;
    }

    private bool CheckColumns()
    {
        for (int j = 0; j < Board.Instance.BoardSize; j++)
        {
            for (int i = 0; i <= Board.Instance.BoardSize - winLength; i++)
            {
                bool colWin = true;
                for (int k = 0; k < winLength; k++)
                {
                    if (boardState[i + k, j] != boardState[i, j] || string.IsNullOrEmpty(boardState[i, j]))
                    {
                        colWin = false;
                        break;
                    }
                }
                if (colWin) return true;
            }
        }
        return false;
    }

    private bool CheckDiagonals()
    {
        for (int i = 0; i <= Board.Instance.BoardSize - winLength; i++)
        {
            for (int j = 0; j <= Board.Instance.BoardSize - winLength; j++)
            {
                bool diag1Win = true;
                for (int k = 0; k < winLength; k++)
                {
                    if (boardState[i + k, j + k] != boardState[i, j] || string.IsNullOrEmpty(boardState[i, j]))
                    {
                        diag1Win = false;
                        break;
                    }
                }
                if (diag1Win) return true;
            }
        }

        for (int i = 0; i <= Board.Instance.BoardSize - winLength; i++)
        {
            for (int j = winLength - 1; j < Board.Instance.BoardSize; j++)
            {
                bool diag2Win = true;
                for (int k = 0; k < winLength; k++)
                {
                    if (boardState[i + k, j - k] != boardState[i, j] || string.IsNullOrEmpty(boardState[i, j]))
                    {
                        diag2Win = false;
                        break;
                    }
                }
                if (diag2Win) return true;
            }
        }

        return false;
    }



    private bool CheckTie()
    {
        for (int i = 0; i < Board.Instance.BoardSize; i++)
        {
            for (int j = 0; j < Board.Instance.BoardSize; j++)
            {
                if (string.IsNullOrEmpty(boardState[i, j]))  
                {
                    return false;
                }
            }
        }
        return true;
    }

}
