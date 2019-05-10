using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WordStyle
{
    public string word;
    public Sprite BoxImage;
    public Color32 Color;
}
public class WordStyleHolder : MonoBehaviour {

    public static WordStyleHolder Instance;

    public WordStyle[] WordStyles;

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
}
