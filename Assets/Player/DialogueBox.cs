using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using Ink.Parsed;
using System;
using UnityEngine.UI;
using UnityEditorInternal;
using Story = Ink.Runtime.Story;
using Text = UnityEngine.UI.Text;

public class DialogueBox : MonoBehaviour
{
    /*public TextAsset inkFile;
    public TextMeshProUGUI text;
    public float textSpeed;

    //static Story story;
    private int index;*/
    [SerializeField]
    private TextAsset inkJSONAsset = null;
    public Story story;

    [SerializeField]
    private Canvas canvas = null;
    [SerializeField]
    private Text textPrefab = null;
    void Start()
    {
        story = new Story(inkJSONAsset.text);
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void StartDialogue()
    {
        while(story.canContinue)
        {
            string text = story.Continue();
            text = text.Trim();
            CreateContentView(text);
        }

    }
    void CreateContentView(string text)
    {
        Text storyText = Instantiate(textPrefab) as Text;
        storyText.text = text;
        storyText.transform.SetParent(canvas.transform, false);
    }
}
