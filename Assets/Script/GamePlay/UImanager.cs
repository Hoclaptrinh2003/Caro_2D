using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : Singleton<UImanager>   
{

    [SerializeField] private List<GameObject> btnMain;
    public List<GameObject> Popup;
    public List<GameObject> GamePlay;
    [SerializeField] private GameObject Login;



    public void PlayGameCaro33()
    {
        foreach (GameObject obj in btnMain)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
        Login.SetActive(true);

        Board.Instance.BoardSize = 3;
        CheckWin.Instance.boardState = new string[Board.Instance.BoardSize, Board.Instance.BoardSize];
        CheckWin.Instance.winLength = Board.Instance.BoardSize < 5 ? 3 : 5;
        Board.Instance.CreateGame();
    }

    public void PlayGameCaro55()
    {

        foreach (GameObject obj in btnMain)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
        Login.SetActive(true);

        Board.Instance.BoardSize = 5;
        CheckWin.Instance.boardState = new string[Board.Instance.BoardSize, Board.Instance.BoardSize];
        CheckWin.Instance.winLength = Board.Instance.BoardSize < 5 ? 3 : 5;
        Board.Instance.CreateGame();
    }

    public void PlayGameCaro99()
    {
        foreach (GameObject obj in btnMain)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
        Login.SetActive(true);

        Board.Instance.BoardSize = 9;
        CheckWin.Instance.boardState = new string[Board.Instance.BoardSize, Board.Instance.BoardSize];
        CheckWin.Instance.winLength = Board.Instance.BoardSize < 5 ? 3 : 5;
        Board.Instance.CreateGame();
    }

    public void PlayGameCaro1212()
    {
        foreach (GameObject obj in btnMain)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
        Login.SetActive(true);

        Board.Instance.BoardSize = 12;
        CheckWin.Instance.boardState = new string[Board.Instance.BoardSize, Board.Instance.BoardSize];
        CheckWin.Instance.winLength = Board.Instance.BoardSize < 5 ? 3 : 5;
        Board.Instance.CreateGame();
    }



    public void Home()
    {
        Board.Instance.DestroyCell();

        foreach (GameObject obj in btnMain)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
        foreach (GameObject obj in GamePlay)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
        Board.Instance.indexChange = 0;
        CheckWin.Instance.isWin = false;
        Board.Instance.isShowCell = false;  
        Board.Instance.BoardSize = 0;
    }




}
