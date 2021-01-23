using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ways
{
    Next,
    Answer,
    Minigame,
    Scene
}

[CreateAssetMenu(fileName = "tdata", menuName = "Text Data", order = 0)]
public class TextData : ScriptableObject
{
    [Header("Character")]
    public int caracterId = 0;
    public Expressions expression = Expressions.Calm;
    public FemaleClothing clothes = FemaleClothing.None;
    public bool char_visible = true;

    [Header("Background")]
    public BackgroundTypes background = BackgroundTypes.DormDay;

    [Header("Dialogue")]
    [TextArea(6, 24)]
    public string _text;

    public Ways way = Ways.Next;

    [Header("Next")]
    public string n_message = "...";
    public TextData nextData;

    [Header("Answers")]
    public string a1_message = "1";
    public TextData a1_data;
    public string a2_message = "2";
    public TextData a2_data;
    public string a3_message = "3";
    public TextData a3_data;

    [Header("Minigame")]
    public string m_message = "Начать";

    [Header("Scene")]
    public string s_message = "Продолжить";
    public int sceneID;

    public bool CheckAnswer(int i)
    {
        switch (i)
        {
            case 1:
                return a1_data != null;

            case 2:
                return a2_data != null;

            case 3:
                return a3_data != null;

            default:
                return false;
        }
    }

    public string GetAnswer(int i)
    {
        switch (i)
        {
            case 1:
                return a1_message;

            case 2:
                return a2_message;

            case 3:
                return a3_message;

            default:
                return "missed line";
        }
    }

    public TextData GetAnswerData(int i)
    {
        switch (i)
        {
            case 1:
                return a1_data;

            case 2:
                return a2_data;

            case 3:
                return a3_data;

            default:
                return null;
        }
    }

}
