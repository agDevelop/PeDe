using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public FaceExpressions faceManager;

    public TBox textBox;

    public TextData newTD;

    [Header("Background")]
    public BackgroundTypes current_bg = BackgroundTypes.DormDay;
    public Backgrounds backgrounds;
    public SpriteRenderer background;
    [Range(0,1)]
    public int blur = 1;
    Material m;

    [Header("Characters")]
    public List<GameObject> characters = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        m = background.material;
    }

    void Update()
    {
        if (blur != m.GetFloat("_blur"))
        {
            float b = m.GetFloat("_blur");
            b = Mathf.Lerp(b, blur, .2f);
            m.SetFloat("_blur", b);
        }
    }

    public void SetFace(Expressions exp, out int f, out int b)
    {
        if (faceManager.faceExps.Count < (int)exp)
        {
            f = 0;
            b = 0;
        }
        else
        {

            f = faceManager.faceExps[(int)exp].fType;
            b = faceManager.faceExps[(int)exp].blush;
        }
    }
}
