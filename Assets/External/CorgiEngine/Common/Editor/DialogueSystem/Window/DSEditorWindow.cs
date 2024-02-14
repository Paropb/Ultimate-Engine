using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
namespace MoreMountains.CorgiEngine
{
    public class DSEditorWindow : EditorWindow
    {
        [MenuItem("Window/MMExtra/Dialogue Graph")]
        public static void ShowExample()
        {
            DSEditorWindow wnd = GetWindow<DSEditorWindow>("Dialogue Graph");
        }
        private void OnEnable()
        {
            AddGraphView();
            AddStyles();
        }
        #region Element Addition
        private void AddGraphView()
        {
            DSGraphView graphView = new DSGraphView();
            graphView.StretchToParentSize();
            rootVisualElement.Add(graphView);
        }
        private void AddStyles()
        {
            rootVisualElement.AddStyleSheets("DialogueSystem/DSVariables");
        }
        #endregion
    }
}
