using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
//using Ink.Parsed;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] Animator DialogueAnimator;
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    public int mood;
    private TextMeshProUGUI[] choicesText;
    private Story currentStory;
    public static DialogueManager instance { get; private set; }
    public bool dialogueIsPlaying { get; private set; }
    public string tags;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager");
        }
        instance = this;
    }
    private void Start()
    {
        tags = "";
        dialogueIsPlaying = false;
        dialogueBox.SetActive(false);
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        mood = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

    }
    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && currentStory.currentChoices.Count == 0)
        {
            ContinueStory();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitDialogueMode();
        }
        if (currentStory.currentTags.Count > 0)
        {
            tags = currentStory.currentTags[0];
        }
        
        // mood = (int)currentStory.variablesState["Mood"];
    }
    public void EnterDialogueMode(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text); 
        dialogueIsPlaying = true;
        dialogueBox.SetActive(true);        
        DialogueAnimator.SetTrigger("Enter");
        ContinueStory();
    }
    public void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialogueText.text = "";
        DialogueAnimator.SetTrigger("Exit");
        StartCoroutine(DeactivateDialogBox());
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
            //HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }
    //private void HandleTags(List<string> currentTags)
    //{
    //    foreach (string tag in currentTags)
    //    {
    //        string[] splitTag = tag.Split(':');
    //        if (splitTag.Length != 2)
    //        {
    //            Debug.LogError($"Tag could not be appropriately parsed: {tag}");
    //        }
    //        string tagKey = splitTag[0].Trim();
    //        string tagValue = splitTag[1].Trim();
    //        switch (tagKey)
    //        {
    //            case PORTRAIT_TAG:
    //                Debug.Log($"Portrait: {tagValue}");
    //                break;

    //        }
    //    }
    //}
    IEnumerator DeactivateDialogBox()
    {
        yield return new WaitForSeconds(1);
        dialogueBox.SetActive(false);
    }

    private void DisplayChoices()
    {
        List<Choice> currentchoices = currentStory.currentChoices;
        if (currentchoices.Count > choices.Length)
        {
            Debug.LogError($"More choices were given than the UI can support. Number of choices given {currentchoices.Count}");
        }
        int index = 0;

        foreach (Choice choice in currentchoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        StartCoroutine(SelectFirstChoice());
    }
    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }

    //IEnumerator WriteSentence()
    //{
    //    foreach (char Character in dialogueText.text)
    //    {
    //        DialogueText.text += Character;
    //        yield return new WaitForSeconds(DialogueSpeed);
    //    }
    //    Index++;
    //}

    //private static DialogueManager instance;
    //public TextMeshProUGUI DialogueText;
    //public string[] Sentences;
    //private int Index = 0;
    //public float DialogueSpeed;
    //public Animator DialogueAnimator;
    //private bool StartDialogue = true;



    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        if (StartDialogue)
    //        {
    //            DialogueAnimator.SetTrigger("Enter");
    //            StartDialogue = false;
    //        }
    //        else
    //        {
    //            NextSentence();
    //        }
    //    }
    //}

    //void NextSentence()
    //{
    //    if (Index <= Sentences.Length - 1)
    //    {
    //        DialogueText.text = "";
    //        StartCoroutine(WriteSentence());
    //    }
    //    else
    //    {
    //        DialogueText.text = "";
    //        DialogueAnimator.SetTrigger("Exit");
    //        StartDialogue = true;
    //        Index = 0;
    //    }
    //}

    //IEnumerator WriteSentence()
    //{
    //    foreach (char Character in Sentences[Index].ToCharArray())
    //    {
    //        DialogueText.text += Character;
    //        yield return new WaitForSeconds(DialogueSpeed);
    //    }
    //    Index++;
    //}
}
