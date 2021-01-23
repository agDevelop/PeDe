using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Expressions
{
    Calm,
    Excited,
    Surprised,
    Happy,
    HappySmile,
    Angry,
    Sly,
    Tired,
    Pouting,
    Sad,
    Disapointed,
    Shy,
    AngryShy,
    SurpShy,
    SlyShy
}

[System.Serializable]
public struct FaceExp
{
    public int fType;

    public int blush;
}

[ExecuteAlways]
public class FaceExpressions : MonoBehaviour
{
    public CharInfo info;

    public List<FaceExp> faceExps = new List<FaceExp>();

    public Expressions e;

    [Header("Settings")]
    [Range(0, 10)]
    public int face_exp;

    [Range(0, 2)]
    public int blush;

    public bool saveFace;

    public int expId = -1;

   

    void Update()
    {
        info.face_exp = face_exp;
        info.blush = blush;

        if (saveFace)
        {
            saveFace = false;
            SaveExpression();
        }
    }

    void SaveExpression()
    {
        FaceExp f = new FaceExp()
        {
            blush = blush,
            fType = face_exp
        };

        if (expId >= 0 && expId < faceExps.Count)
        {
            faceExps[expId] = f;
            expId = -1;
        }
        else
        {
            faceExps.Add(f);
        }
    }
}
