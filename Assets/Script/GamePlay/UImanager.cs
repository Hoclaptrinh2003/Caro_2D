using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : Singleton<UImanager>   
{

    [SerializeField] private List<GameObject> btnMain;
    public List<GameObject> Popup;
    public List<GameObject> GamePlay;
    [SerializeField] private GameObject Login;
    [SerializeField] private GameObject Lock;
    [SerializeField] private GameObject Lock1;

    private Color UnlockCaro = new Color (255,255,255,255);
    private bool isLock1212 = false;
    private bool isLock1515 = false;

    private void Start()
    {
        LoadLockState();

        if (isLock1212 == true)
        {
            Button caro1212Button = btnMain[1].GetComponent<Button>();
            Image buttonImage = caro1212Button.GetComponent<Image>();
            buttonImage.color = UnlockCaro;
            Lock.SetActive(false);
          
        }

        if (isLock1515== true)
        {
            Button caro1515Button = btnMain[7].GetComponent<Button>();
            Image buttonImage = caro1515Button.GetComponent<Image>();
            buttonImage.color = UnlockCaro;
            Lock1.SetActive(false);

        }




    }
    private void SaveLockState()
    {
        PlayerPrefs.SetInt("IsCaro1212LockedKey", isLock1212 ? 1 : 0);
        PlayerPrefs.SetInt("IsCaro1515LockedKey", isLock1515 ? 1 : 0);
        PlayerPrefs.Save(); 
    }

    private void LoadLockState()
    {
        if (PlayerPrefs.HasKey("IsCaro1212LockedKey"))
        {
            isLock1212 = PlayerPrefs.GetInt("IsCaro1212LockedKey") == 1; 
        }
        if (PlayerPrefs.HasKey("IsCaro1515LockedKey"))
        {
            isLock1515 = PlayerPrefs.GetInt("IsCaro1515LockedKey") == 1;
        }
    }

    public void PlayGameCaro33()
    {
        AudioManager.Instance.BtnClick();

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
        AudioManager.Instance.BtnClick();

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


    public void PlayGameCaro77()
    {
        AudioManager.Instance.BtnClick();

        foreach (GameObject obj in btnMain)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
        Login.SetActive(true);

        Board.Instance.BoardSize = 7;
        CheckWin.Instance.boardState = new string[Board.Instance.BoardSize, Board.Instance.BoardSize];
        CheckWin.Instance.winLength = Board.Instance.BoardSize < 5 ? 3 : 5;
        Board.Instance.CreateGame();
    }



    public void PlayGameCaro99()
    {
        AudioManager.Instance.BtnClick();

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
        AudioManager.Instance.BtnClick();

        if (ResourceManager.Instance.Coin < 100 && isLock1212 == false)
        {
            Popup[3].SetActive(true);  
            return;
        }
        if(isLock1212 == false)
        {
            Button caro1212Button = btnMain[1].GetComponent<Button>();
            Image buttonImage = caro1212Button.GetComponent<Image>();
            buttonImage.color = UnlockCaro;
            ResourceManager.Instance.DeductCoins(100);
            Lock.SetActive(false);
            isLock1212 = true;
            SaveLockState();
        }


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

    public void PlayGameCaro1515()
    {
        AudioManager.Instance.BtnClick();

        if (ResourceManager.Instance.Coin < 200 && isLock1515 == false)
        {
            Popup[3].SetActive(true);
            return;
        }
        if (isLock1515 == false)
        {
            Button caro1515Button = btnMain[7].GetComponent<Button>();
            Image buttonImage = caro1515Button.GetComponent<Image>();
            buttonImage.color = UnlockCaro;
            ResourceManager.Instance.DeductCoins(200);
            Lock1.SetActive(false);
            isLock1515 = true;
            SaveLockState();
        }



        foreach (GameObject obj in btnMain)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
        Login.SetActive(true);

        Board.Instance.BoardSize = 15;
        CheckWin.Instance.boardState = new string[Board.Instance.BoardSize, Board.Instance.BoardSize];
        CheckWin.Instance.winLength = Board.Instance.BoardSize < 5 ? 3 : 5;
        Board.Instance.CreateGame();
    }

    public void Home()
    {
        Board.Instance.DestroyCell();
        AudioManager.Instance.BtnClick();
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


    public void showRankingPopup()
    {
        AudioManager.Instance.BtnClick();

        Popup[4].SetActive(true);

    }

}
