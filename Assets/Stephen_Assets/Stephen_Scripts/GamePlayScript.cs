using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScript : MonoBehaviour
{

    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            GameObject newPiece = Instantiate(playerPrefab, Vector3.right * i * 4, Quaternion.identity) as GameObject;


            switch (i)
            {
                case 1: newPiece.name = MyGameData.current.King.name;
                        break;
                case 2: newPiece.name = MyGameData.current.Queen.name;
                        break;
                case 3: newPiece.name = MyGameData.current.Bishop.name;
                        break;
                case 4: newPiece.name = MyGameData.current.Rook.name;
                        break;
                case 5: newPiece.name = MyGameData.current.Pawn.name;
                        break;
                case 6: newPiece.name = MyGameData.current.Horse.name;
                        break;

             }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
