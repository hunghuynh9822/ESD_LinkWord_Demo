using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject stageClearPanel,gamePanel;
    public Text levelText;
    public List<GameObject> SelectedWordBoxes;
    public List<LineEmptyBoxAnswer> lineEmptyBoxAnswers;
    public Answer[] answers;
    public string answerPlayer;

    public Animator anim;

    public static int currentLevel = 0;

    public static GameManager Instance;

    private void Awake()
    {
        SelectedWordBoxes = new List<GameObject>();
        lineEmptyBoxAnswers = new List<LineEmptyBoxAnswer>();
        //Singleton
        Instance = this;
        //Answer of player
        answerPlayer = "";
        //Start level
        currentLevel = 1;
    }

    // Use this for initialization
    void Start () {
        //Disable stageClearPanel
        stageClearPanel.SetActive(false);
        //Set level to get text
        GetTxt.Instance.setLevel(currentLevel);
        //Get answer from txt
        answers = GetTxt.Instance.getAnswers();
        //Set level
        GameObject levelObject = GameObject.Find("Level");
        Text levelText = levelObject.GetComponent<Text>();
        levelText.text = "" + currentLevel;
    }
	
	// Update is called once per frame
	void Update () {
        //answerPlayer = "";
        //if (SelectedWordBoxes != null)
        //{
        //    foreach (GameObject gb in SelectedWordBoxes)
        //    {
        //        answerPlayer += gb.GetComponentInChildren<Text>().text;
        //    }
        //}
        if (checkFinishLevel())
        {
            //currentLevel++;
            //resetMap();
            //Show up panel stage clear
            levelText.text = currentLevel.ToString();
            stageClearPanel.SetActive(true);
            anim.SetTrigger("StageClear");
        }
    }

    public bool checkFinishLevel()
    {
        foreach(LineEmptyBoxAnswer line in lineEmptyBoxAnswers)
        {
            if (!line.getChecked())
            {
                return false;
            }
        }
        
        return true;
    }

    public void continueLevel()
    {
        currentLevel++;
        resetMap();
        stageClearPanel.SetActive(false);
    }

    public void catchAnswerPlayer()
    {
        answerPlayer = "";
        if (SelectedWordBoxes != null)
        {
            foreach (GameObject gb in SelectedWordBoxes)
            {
                answerPlayer += gb.GetComponentInChildren<Text>().text;
            }
        }
    }

    public void resetMap()
    {
        GameObject[] wordBoxes = GameObject.FindGameObjectsWithTag("wordBox");
        GameObject[] emptyBoxes = GameObject.FindGameObjectsWithTag("emptyBox");

        foreach(GameObject gameObject in wordBoxes)
        {
            Destroy(gameObject);
        }
        foreach (GameObject gameObject in emptyBoxes)
        {
            Destroy(gameObject);
        }

        SelectedWordBoxes = new List<GameObject>();
        lineEmptyBoxAnswers = new List<LineEmptyBoxAnswer>();

        GetTxt.Instance.setLevel(currentLevel);
        //Get answer from txt
        answers = GetTxt.Instance.getAnswers();
        //Set level
        GameObject levelObject = GameObject.Find("Level");
        Text levelText = levelObject.GetComponent<Text>();
        levelText.text = ""+currentLevel;
    }

    public bool checkAnswer()
    {
        catchAnswerPlayer();
        for (int i = 0; i < answers.Length; i++)
        {
            if (answerPlayer.Equals(answers[i].getAnswer()))
            {
                if (!lineEmptyBoxAnswers[i].getChecked())
                {
                    List<Box> boxes = lineEmptyBoxAnswers[i].getGameObjects();
                    for (int j = 0; j< boxes.Count;j++ )
                    {
                        boxes[j].ApplyStyle(answers[i].getChars()[j]);
                        //boxes[j].clickSelectedAnimation();
                    }
                    lineEmptyBoxAnswers[i].setChecked(true);
                    answerPlayer = "";
                    Debug.Log("Correct");
                    return true;
                }
                Debug.Log("Checked");
                return false;
            }
            foreach (GameObject go in SelectedWordBoxes)
            {
                Box box = go.GetComponent<Box>();
                box.wrongShakingAnimation();
            }
            Debug.Log("Failed");
        }
        return false;
    }
}
