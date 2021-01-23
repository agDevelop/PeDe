using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BackgroundTypes
{
    Plug,
    DormDay,
    DormNight,
    Classroom,
    Hall,
    Scene
}
public class Backgrounds : MonoBehaviour
{
    SpriteRenderer sr;
    Material m;

    public List<Sprite> normal = new List<Sprite>();
    public List<Sprite> blurred = new List<Sprite>();

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        m = sr.material;
    }

    public void SetBack(int i)
    {
        if (i >= 0 && i < normal.Count && i < blurred.Count)
        {
            sr.sprite = normal[i];
            m.SetTexture("_BlurTex", blurred[i].texture);
        }
        else
        {

        }
    }

}
