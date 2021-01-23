using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TBox : MonoBehaviour
{
    public TextData currentTD;

    GameObject character;

    CharInfo info;

    [Header("Object")]
    public Text _name;

    public Text _npcText;

    public Text a1, a2, a3;

    public Text next, scene, minigame;

    void Update()
    {
        TryChangeTD();
    }

    void TryChangeTD()
    {
        bool b = GameManager.instance.newTD != null;

        if (b)
        {
            if (currentTD != GameManager.instance.newTD)
            {
                ChangeData();
            }
        }
    }

    void ChangeData()
    {
        currentTD = GameManager.instance.newTD;

        if (currentTD.caracterId >= 0 && currentTD.caracterId < GameManager.instance.characters.Count)
        {
            GameObject obj = GameManager.instance.characters[currentTD.caracterId];

            if (character != obj)
            {
                Destroy(character);

                character = Instantiate(obj);

                character.transform.position = Vector3.zero;

                info = character.GetComponent<CharInfo>();
            }
        }

        _name.text = $"{info.first_name} {info.surname}";

        GameManager.instance.SetFace(currentTD.expression, out info.face_exp, out info.blush);
        info.clothes = (int)currentTD.clothes;
        info.UpdateLook();

        if (character != null) character.SetActive(currentTD.char_visible);
        GameManager.instance.blur = currentTD.char_visible ? 1 : 0;

        GameManager.instance.backgrounds.SetBack((int)currentTD.background);

        _npcText.text = currentTD._text;

        SetAnswer();
        next.transform.parent.gameObject.SetActive(false);
        scene.transform.parent.gameObject.SetActive(false);
        minigame.transform.parent.gameObject.SetActive(false);

        switch (currentTD.way)
        {
            case Ways.Next:
                SetNext();
                break;

            case Ways.Answer:
                SetAnswers();
                break;

            case Ways.Minigame:
                SetMinigame();
                break;

            case Ways.Scene:
                SetScene();
                break;
        }
    }

    void SetNext()
    {
        next.transform.parent.gameObject.SetActive(true);
        next.text = currentTD.n_message;
    }

    void SetAnswers()
    {
        for (int i = 1; i < 4; i++)
        {
            if (currentTD.CheckAnswer(i))
            {
                SetAnswer(i);
            }
        }
    }

    public void SetAnswer(int i = 0)
    {
        switch (i)
        {
            case 1:
                a1.transform.parent.gameObject.SetActive(true);
                a1.text = currentTD.GetAnswer(i);
                break;

            case 2:
                a2.transform.parent.gameObject.SetActive(true);
                a2.text = currentTD.GetAnswer(i);
                break;

            case 3:
                a3.transform.parent.gameObject.SetActive(true);
                a3.text = currentTD.GetAnswer(i);
                break;

            default:
                a1.transform.parent.gameObject.SetActive(false);
                a2.transform.parent.gameObject.SetActive(false);
                a3.transform.parent.gameObject.SetActive(false);
                break;
        }
    }

    void SetMinigame()
    {
        minigame.transform.parent.gameObject.SetActive(true);
        minigame.text = currentTD.m_message;
    }

    void SetScene()
    {
        scene.transform.parent.gameObject.SetActive(true);
        scene.text = currentTD.s_message;
    }

    public void Answer(int i)
    {
        GameManager.instance.newTD = currentTD.GetAnswerData(i);
    }

    public void Next()
    {
        GameManager.instance.newTD = currentTD.nextData;
    }

    public void Scene()
    {
        int i = currentTD.sceneID;
        if (i < 0)
            Application.Quit();
        else
            SceneManager.LoadScene(i);
    }

    public void Minigame()
    {

    }
}