using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

public class DialogueSystemNode : Node
{
    public string DialogueName {get; set;}

    public string Text {get; set;}
    public List<string> Choices {get; set;}
    
    public DialogueSystemDialogueType DialogueType {get; set;}

    public virtual void Initialize(Vector2 position) 
    {
        DialogueName = "DialogueName";
        Text = "Dialogue text.";

        Choices = new List<string>();

        SetPosition(new Rect(position, Vector2.zero));
    }

    public virtual void Draw() 
    {   
        /* Title Container */
        TextField dialogueNameTextField = new TextField()
        {
            value = DialogueName
        };
        titleContainer.Insert(0, dialogueNameTextField);

        Port inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));
        inputPort.portName = "Dialogue Input";

        inputContainer.Add(inputPort);

        VisualElement customDataContainer = new VisualElement();

        Foldout textFoldout = new Foldout() 
        {
            text = "Dialogue Text"
        };

        TextField textTextField = new TextField() 
        {
            value = Text
        };

        textFoldout.Add(textTextField);

        customDataContainer.Add(textFoldout);

        extensionContainer.Add(customDataContainer);

        //Port outPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
    }
}
