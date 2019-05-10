using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Scripts;

public class GetTxt : MonoBehaviour {

    public static GetTxt Instance;
    private string path = "";
    private string indexPath = "Assets/Scripts/FileText/";

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string getPath()
    {
        return path;
    }

    public void setLevel(int level)
    {
        path = indexPath + "Level" + level + ".txt";
    }

    public string[] getWord()
    {
        List<string> words = new List<string>();
        //code here
        var str = ReadString()[0];
        for (int i = 0; i < str.Length; i++)
        {
            words.Add(str[i].ToString());
        }

        return words.ToArray();
    }

    public Answer[] getAnswers()
    {
        List<Answer> answers = new List<Answer>();
        List<string> answerWords = new List<string>();
        //code here
        answerWords = ReadString();
        for (int i = 0; i < answerWords.Count; i++)
        {
            answers.Add(new Answer(answerWords[i]));
        }
        return answers.ToArray();
    }
    // đọc file txt lên...
    public List<string> ReadString()
    {
        //string path = "Assets/Scripts/Level1.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        List<string> lines= new List<string>();
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            lines.Add(line);
        }
        reader.Close();
        return lines;
    }
}
