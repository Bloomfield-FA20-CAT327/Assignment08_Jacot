using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //GameObjects
    //Canvas Items
    public GameObject mainMenuScreen;
    public GameObject NewGameScreen;
    public GameObject LoadGameScreen;
    //Button Items
    public GameObject prefabButton;
    //Input
    public InputField textKing;
    public InputField textQueen;
    public InputField textBishop;
    public InputField textRook;
    public InputField textPawn;
    public InputField textHorse;


    void Awake()
    {
        MainScreen();
    }
    public void MainScreen()
    {
        mainMenuScreen.SetActive(true);
        LoadGameScreen.SetActive(false);
        NewGameScreen.SetActive(false);
    }

    public void LoadGameMenu()
    {
        mainMenuScreen.SetActive(false);
        LoadGameScreen.SetActive(true);
        NewGameScreen.SetActive(false);
        GenerateButtons();

    }

    public void NewGameMenu()
    {
        mainMenuScreen.SetActive(false);
        LoadGameScreen.SetActive(false);
        NewGameScreen.SetActive(true);
        MyGameData.current = new MyGameData();
        textKing.text = MyGameData.current.King.name;
        textQueen.text = MyGameData.current.Queen.name;
        textBishop.text = MyGameData.current.Bishop.name;
        textRook.text = MyGameData.current.Rook.name;
        textPawn.text = MyGameData.current.Pawn.name;
        textHorse.text = MyGameData.current.Pawn.name;
    }

    public void SaveandStart()
    {
        MyGameData.current.King.name = textKing.text;
        MyGameData.current.Queen.name = textQueen.text;
        MyGameData.current.Bishop.name = textBishop.text;
        MyGameData.current.Rook.name = textRook.text;
        MyGameData.current.Pawn.name = textPawn.text;
        MyGameData.current.Horse.name = textHorse.text;
        SLScript.Save();
        SceneManager.LoadScene(1);
    }
    
    public void GenerateButtons()
    {
        SLScript.Load();
        foreach(GameObject usedButtons in GameObject.FindGameObjectsWithTag("LoadGameButton"))
        {
            Destroy(usedButtons);
        }

        foreach(MyGameData savedGame in SLScript.savedGames)
        {
            GameObject buttonPrefabObject = Instantiate(prefabButton, LoadGameScreen.transform);

            if(buttonPrefabObject)
            {
                buttonPrefabObject.GetComponentInChildren<Text>().text = savedGame.King.name + "-" + savedGame.Queen.name + "-" + savedGame.Bishop.name + "\n" + 
                savedGame.Rook.name + "-" + savedGame.Pawn.name + "-" + savedGame.Horse.name;

                buttonPrefabObject.GetComponentInChildren<Button>().onClick.AddListener(delegate { LoadedGameClicked(savedGame); });
            }
        }
    }

    private void LoadedGameClicked(MyGameData game)
    {
        MyGameData.current = game;

        SceneManager.LoadScene(1);

    }

    public void Quit()
    {
        Application.Quit();  
    }
}
