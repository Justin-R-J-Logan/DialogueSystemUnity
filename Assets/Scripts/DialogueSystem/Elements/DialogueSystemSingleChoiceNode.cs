using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

public class DialogueSystemSingleChoiceNode : DialogueSystemNode
{
    public override void Initialize(Vector2 position)
    {
        base.Initialize(position);

        DialogueType = DialogueSystemDialogueType.SingleChoice;

        Choices.Add("Next Dialogue");
    }

    public override void Draw()
    {
        base.Draw();

        foreach(string choice in Choices) {
            Port choicePort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
            choicePort.portName = choice;
            outputContainer.Add(choicePort);
        }

        RefreshExpandedState();
    }
}
