using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    public int index;
    [Header("UI组件")]
    public Text textLabel;

    [Header("文本文件")]
    public TextAsset textFile;
    public int indexx;
    public float textSpeed;

    public bool textFinished;
    // public bool cancelTyping;

    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFromFile(textFile);
    }

    private void OnEnable()
    {
        //textLabel.text = textList[index];
        //index++;
        textFinished = true;
        StartCoroutine(SetTextUI());
    }


    void Update()
    {
        index = SceneManager.GetActiveScene().buildIndex;

        if (Input.anyKeyDown && indexx == textList.Count)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(index + 1);

            indexx = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && textFinished)
        {
            //textLabel.text = textList[index];
            //index++;
            StartCoroutine(SetTextUI());
        }
        //if (Input.anyKeyDown)
        //{
        //    if (textFinished && !cancelTyping)
        //    {
        //        StartCoroutine(SetTextUI());
        //    }
        //    else if (!textFinished && !cancelTyping)
        //    {
        //        //cancelTyping = !cancelTyping;
        //        cancelTyping = true;
        //    }
        //}

    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        indexx = 0;

        var lineDate = file.text.Split('\n');
        //file.text.Split('\n');
        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";

        for (int i = 0; i < textList[indexx].Length; i++)
        {
            textLabel.text += textList[indexx][i];

            yield return new WaitForSeconds(textSpeed);
        }
        //int letter = 0;
        //while (!cancelTyping && letter < textList[index].Length - 1)
        //{
        //    textLabel.text += textList[indexx][letter];
        //    letter++;
        //    yield return new WaitForSeconds(textSpeed);
        //}
        //textLabel.text = textList[index];
        //cancelTyping = false;

        textFinished = true;
        indexx++;
    }

}
