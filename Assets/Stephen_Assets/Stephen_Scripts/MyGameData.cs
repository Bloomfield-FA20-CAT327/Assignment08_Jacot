using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MyGameData
{
    public static MyGameData current;
    public CharacterData King;
    public CharacterData Queen;
    public CharacterData Bishop;
    public CharacterData Rook;
    public CharacterData Pawn;
    public CharacterData Horse;

    public MyGameData()
    {
        King = new CharacterData();
        Queen = new CharacterData();
        Bishop = new CharacterData();
        Rook = new CharacterData();
        Pawn = new CharacterData();
        Horse = new CharacterData();
    }
}
