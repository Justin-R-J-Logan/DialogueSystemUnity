using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

public class DialogueSystemMultipleChoiceNode : DialogueSystemNode
{
    public override void Initialize(Vector2 position)
    {
        base.Initialize(position);

        DialogueType = DialogueSystemDialogueType.MultipleChoice;

        Choices.Add("New CHoice");
    }
    public override void Draw()
    {
        base.Draw();

        Button addChoiceButton = new Button() {
            text = "Add Choice"
        };

        mainContainer.Insert(1, addChoiceButton);

        foreach(string choice in Choices) {
            Port choicePort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));

            choicePort.portName = "";

            Button deleteChoiceButton = new Button() 
            {
                text = "X"
            };

            TextField choiceTexField = new TextField()
            {
                value = "Choice"
            };

            choicePort.Add(choiceTexField);
            choicePort.Add(deleteChoiceButton);

            outputContainer.Add(choicePort);
        }

        RefreshExpandedState();
    }
}
