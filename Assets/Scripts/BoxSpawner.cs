using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject boxPreference;

    public static int currentLevel = 0;

    public Transform panel;

    //public static int WordBoxCount = 0;

    // Use this for initialization
    void Start () {
        //createWordBox();
        //createEmptyBox();
        //currentLevel = GameManager.currentLevel;
    }

    private void Update()
    {
        if(currentLevel != GameManager.currentLevel)
        {
            currentLevel = GameManager.currentLevel;
            createWordBox();
            createEmptyBox();
        }
    }

    void createWordBox()
    {
        string[] words = GetTxt.Instance.getWord();
        
        //WordBoxCount = words.Length;
        MapPosition mapPosition = MapPosition.getMapWordBoxPosition(words.Length);
        if (mapPosition != null)
        {
            for (int i = 0; i < words.Length; i++)
            {
                CreateBox(words[i], mapPosition.positions[i]);
            }
        }
    }

    void createEmptyBox()
    {
        Answer[] answers = GetTxt.Instance.getAnswers();
        for (int i = 0; i < answers.Length; i++)
        {
            string[] chars = answers[i].getChars();
            MapPosition mapPositionEmptyBox = MapPosition.getMapEmptyBoxPosition(chars.Length, i);
            if (mapPositionEmptyBox != null)
            {
                List<Box> emptyBoxes = new List<Box>();
                for (int j = 0; j < chars.Length; j++)
                {
                    emptyBoxes.Add(CreateBox("", mapPositionEmptyBox.positions[j]));
                }
                GameManager.Instance.lineEmptyBoxAnswers.Add(new LineEmptyBoxAnswer(i, emptyBoxes));
            }
        }
    }
    Box CreateBox(string word, Vector2 position)
    {
        GameObject gameObject = Instantiate(boxPreference, position, Quaternion.identity) as GameObject;

        if (word.Equals(""))
        {
            gameObject.tag = "emptyBox";
        }
        else
        {
            gameObject.tag = "wordBox";
        }
        Box box = gameObject.GetComponent<Box>();
        box.ApplyStyle(word);
        gameObject.transform.SetParent(panel.transform, false);
        return gameObject.GetComponent<Box>();
    }
}
