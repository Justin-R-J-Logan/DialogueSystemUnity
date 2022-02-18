using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class DialogueSystemEditorWindow : EditorWindow
{
    [MenuItem("Window/Dialogue Sysyem/Dialogue Graph")]
    public static void ShowExample()
    {
        DialogueSystemEditorWindow wnd = GetWindow<DialogueSystemEditorWindow>("Dialogue Graph");

        
    }

    private void OnEnable() {
        AddGraphView();

        AddStyles();
    }

    private void AddGraphView() {
        DialogueSystemGraphView graphView = new DialogueSystemGraphView();

        graphView.StretchToParentSize();

        rootVisualElement.Add(graphView);
    }

    private void AddStyles() {
        StyleSheet styleSheet = (StyleSheet) EditorGUIUtility.Load("DialogueSystem/DialogueSystemVariables.uss");

        rootVisualElement.styleSheets.Add(styleSheet);
    }
}