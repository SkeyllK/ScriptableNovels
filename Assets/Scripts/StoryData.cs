using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Story", menuName = "Story/CreatePlot")]
public class StoryData : ScriptableObject {
    public List<StoryScene> StoryScript = new List<StoryScene>();
}

[System.Serializable]
public class StoryScene {
    enum TextRole{
        Title,
        Quote,
        Discription,
        Conversation
    }
    //Story background
    enum Field {
        None,
        SunSet,
        Mountain
    }

    enum Model {
        None,
        Dog,
        Dolphin
    }

    enum ModelPos {
        Left,
        Center,
        Right
    }
    public string SceneText;

    [SerializeField] TextRole _textRole;
    public int textRole { get { return (int)_textRole; } }

    [SerializeField] Model _model;
    //If the story use just one image on each character, don't need int variable.
    public int ModelNumber; //use to change flag too, so need public variable.
    public string model { get { return _model.ToString() + ModelNumber.ToString(); } }

    //Display this name on speaker text.
    public string Speaker;

    [SerializeField] ModelPos _modelPos;
    public int modelPos { get { return (int)_modelPos; } }

    [SerializeField] Field _field;
    [SerializeField] int fieldNumber;
    public string field { get { return _field.ToString() + fieldNumber.ToString(); } }
}
