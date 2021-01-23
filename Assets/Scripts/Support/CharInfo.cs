using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CharInfo : MonoBehaviour
{
    [Header("Randomizer")]
    public bool randomize_look;
    public bool randomize_body;

    [Header("Object")]
    public bool update_look;
    public SpriteRenderer _flower;
    public SpriteRenderer _fhair;
    public SpriteRenderer _glasses;
    public SpriteRenderer _blush;
    public SpriteRenderer _face;
    public SpriteRenderer _clothes;
    public SpriteRenderer _chalker;
    public SpriteRenderer _body;
    public SpriteRenderer _bhair;


    [Header("Info")]
    public string first_name;
    public string surname;

    [Header("Look")]
    [Range(0, 2)]
    public int skin = 1;

    public Color skin_color = Color.white;

    [Range(0, 10)]
    public int face_exp;

    [Range(0, 2)]
    public int blush;

    [Range(0, 4)]
    public int front_hair;

    [Range(0, 4)]
    public int back_hair;

    public Color hair_color = Color.white;

    [Range(0, 9)]
    public int clothes;

    [Range(0, 3)]
    public int glasses;

    public bool chalker;

    public Color chalker_color = Color.white;

    public bool flower;

    private void Update()
    {
        if (update_look) UpdateLook();

        if (randomize_look)
        {
            randomize_look = false;
            RandomizeLook(randomize_body);
        }

        if(Input.GetKeyDown(KeyCode.R)) RandomizeLook(randomize_body);
    }

    public void UpdateLook()
    {
        int back_hair_override = back_hair;

        if (back_hair < 2 || front_hair == 0) back_hair_override = front_hair;

        _body.sprite = CharLookBuilder.instance._body[skin];
        _face.sprite = CharLookBuilder.instance._face[face_exp];
        _fhair.sprite = CharLookBuilder.instance._fhair[front_hair];
        _bhair.sprite = CharLookBuilder.instance._bhair[back_hair_override];
        _glasses.sprite = CharLookBuilder.instance._glasses[glasses];
        _blush.sprite = CharLookBuilder.instance._blush[blush];
        _clothes.sprite = CharLookBuilder.instance._clothes[clothes];

        _chalker.sprite = chalker ? CharLookBuilder.instance._chalker : CharLookBuilder.instance._blank;
        _flower.sprite = flower ? CharLookBuilder.instance._flower : CharLookBuilder.instance._blank;

        if (skin == 0)
        {
            _body.color = skin_color;
        }
        else
        {
            _body.color = Color.white;
        }

        _fhair.color = hair_color;
        _bhair.color = hair_color;

        _chalker.color = chalker_color;
    }
    public void RandomizeLook(bool b_rand)
    {
        if (b_rand)
        {
            skin = 0;
            skin_color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 1f, 1f);
        }
        else
        {
            skin = Random.Range(1, 3);
        }

        hair_color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 1f, 1f);
        chalker_color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 1f, 1f);

        face_exp = Random.Range(0, 11);
        blush = Random.Range(0, 3);
        glasses = Random.Range(0, 4);
        front_hair = Random.Range(1, 5);
        back_hair = Random.Range(1, 5);
        clothes = Random.Range(0, 10);

        bool gl = Random.Range(0, 100) < 15;
        if (!gl) glasses = 0;

        chalker = Random.Range(0, 100) < 5;
        flower = Random.Range(0, 100) < 5;

        UpdateLook();
    }

}
