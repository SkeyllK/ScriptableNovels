using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    StoryData storyData;
    StoryScene storyScene;
    //If you want to reduce text object, you can use one and switch its roles by script.
    [SerializeField] Text title, quote, conversation, speaker; 
    //Hide this at Title and Quote.
    [SerializeField] GameObject storySelectPanel, conversationImage;
    //Change a character image position.
    [SerializeField] RectTransform characterRect;
    //Change a character and field image.
    [SerializeField] Image field, character;
    //Use this at not changing behaviour.
    bool keepRole, keepModel, keepPos, keepField;
    //tmpLine is the load number in a story data array.
    int storyNumber, tmpLine;
    AsyncOperation async;
    
    //Change "storyNumber" as to load story data by button event.
    //I use this script by traslateing other Scene(StoryList) and with ScriptableObject holding other game data (sound volume, user name and so on...) .
    //If you want to traslate from other scene, you change this method to "Start". Then, remove args and load story number directly.
    public void SelectStory(int num) {
        storySelectPanel.SetActive(false);
        storyNumber = num;
        storyData= Resources.Load("StoryPlot/" + "Story" + storyNumber.ToString()) as StoryData;
        LoadNextPart();
    }
    //Attach button event or invoke by Mouse input(Update in other script).
    public void LoadNextPart() {

        if (tmpLine < storyData.StoryScript.Count) {
            storyScene = storyData.StoryScript[tmpLine];
            ChangeText();

            ChangeFieldImage();

            ChangeModelImage();

            if (tmpLine < storyData.StoryScript.Count - 1) {
                CheckNextState();
            }
            tmpLine++;
        } else {
            BackToMenu();
        }
    }

    void CheckNextState() {
        if (storyScene.textRole == storyData.StoryScript[tmpLine + 1].textRole) {
            keepRole = true;
        }

        if (storyScene.model == storyData.StoryScript[tmpLine + 1].model) {
            keepModel = true;
        }

        if (storyScene.modelPos == storyData.StoryScript[tmpLine + 1].modelPos) {
            keepPos = true;
        }

        if (storyScene.field == storyData.StoryScript[tmpLine + 1].field) {
            keepField = true;
        } 
    }

    void ChangeText() {
        //should change more smart one
        if (!keepRole) {
            if (title.text != "") {
                title.text = "";
            }
            if (quote.text != ""){
                quote.text = "";
            }
            if (conversation.text != "") {
                conversation.text = "";
            }
            if(speaker.text != "") {
                speaker.text = "";
            }
        }

        if (storyScene.textRole >= 2 && storyScene.textRole <= 3) {
            conversationImage.SetActive(true);
        } else {
            conversationImage.SetActive(false);
        }

        switch (storyScene.textRole) {
            case 0:
                title.text = storyScene.SceneText;
                break;
            case 1:
                quote.text = storyScene.SceneText.Replace("\\r\\n", System.Environment.NewLine);
                break;
            case 2:
                conversation.text = storyScene.SceneText;
                break;
            case 3:
                speaker.text = storyScene.Speaker;
                conversation.text = storyScene.SceneText;
                break;
        }
        keepRole = false;
    }

    void ChangeModelImage() {
        if (!keepModel) {
            if (storyScene.model == "None0"){
                character.enabled = false;
            } else {
                if(character.enabled == false) {
                    character.enabled = true;
                }
                character.sprite = Resources.Load<Sprite>("StoryImage/" + storyScene.model);
            }
        }
        ChangeModelPosition();
        keepModel = false;
    }

    void ChangeModelPosition() {
        //If you want to change display position, you can change it here.
        if (!keepPos) {
            switch (storyScene.modelPos) {
                case 0:
                    characterRect.anchoredPosition = new Vector2(-500.0f, 60.0f);
                    break;
                case 1:
                    characterRect.anchoredPosition = new Vector2(0.0f, 60.0f);
                    break;
                case 2:
                    characterRect.anchoredPosition = new Vector2(500.0f, 60.0f);
                    break;
            }
        }
        keepPos = false;
    }

    void ChangeFieldImage() {

        if (!keepField) {
            if (storyScene.field == "None0") {
                field.sprite = Resources.Load<Sprite>("StoryImage/None0");
            } else {
                field.sprite = Resources.Load<Sprite>("StoryImage/" + storyScene.field);
            }
        }
        keepField = false;
    }

    //Use this as button event, too.
    public void BackToMenu() {
        //Initialize story data.
        //If separate "StoryScene" from "StoryListScene", don't need this process.
        tmpLine = 0;
        Resources.UnloadUnusedAssets();


        storySelectPanel.SetActive(true);
    }
}
