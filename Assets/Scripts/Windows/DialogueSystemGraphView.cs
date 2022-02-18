using System;
using UnityEditor;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

public class DialogueSystemGraphView : GraphView
{
    public DialogueSystemGraphView() 
    {
        AddManipulators();

        AddGridBackground();

        AddStyles();

    }

    private void AddGridBackground() 
    {
        GridBackground gridBackground = new GridBackground();

        gridBackground.StretchToParentSize();

        Insert(0, gridBackground);
    }

    private void AddStyles() 
    {
        StyleSheet graphViewStyleSheet = (StyleSheet) EditorGUIUtility.Load("DialogueSystem/DialogueSystemGraphViewStyles.uss");
        StyleSheet nodeStyleSheet = (StyleSheet) EditorGUIUtility.Load("DialogueSystem/DialogueSystemNodeStyles.uss");

        styleSheets.Add(graphViewStyleSheet);
        styleSheets.Add(nodeStyleSheet);

    }

    private void AddManipulators() 
    {

        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

        this.AddManipulator(CreateNodeContextualMenu("Add Node (Single Choice)", DialogueSystemDialogueType.SingleChoice)); 
        this.AddManipulator(CreateNodeContextualMenu("Add Node (Multiple Choice)", DialogueSystemDialogueType.MultipleChoice)); 

        this.AddManipulator(new ContentDragger());

        this.AddManipulator(new SelectionDragger());

        this.AddManipulator(new RectangleSelector());
    }
    private DialogueSystemNode CreateNode(DialogueSystemDialogueType dialogueType, Vector2 position) 
    {
        Type nodeType = Type.GetType($"DialogueSystem{dialogueType}Node");

        DialogueSystemNode node = (DialogueSystemNode) Activator.CreateInstance(nodeType);
        
        node.Initialize(position);
        node.Draw();

        return node;
    }

    private IManipulator CreateNodeContextualMenu(string actionTitle, DialogueSystemDialogueType nodeType) {
        ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator(
            menuEvent => menuEvent.menu.AppendAction(actionTitle, actionEvent => AddElement(CreateNode(nodeType, actionEvent.eventInfo.mousePosition)))
        );

        return contextualMenuManipulator;    
    }
}
