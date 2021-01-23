using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FemaleClothing
{
    None, School_1, School_2, PhysEd, Coat, Hoodie, Blouse, SwimSuit, Towel, Pajamas
}
public class CharLookBuilder : MonoBehaviour
{
    public static CharLookBuilder instance;

    public Sprite _blank;

    public List<Sprite> _face;
    public List<Sprite> _blush;
    public List<Sprite> _glasses;

    public List<Sprite> _body;
    public List<Sprite> _fhair;
    public List<Sprite> _bhair;

    public List<Sprite> _clothes;
    
    public Sprite _chalker;
    public Sprite _flower;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
