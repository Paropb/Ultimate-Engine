using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

namespace MoreMountains.CorgiEngine
{
    public class DSSearchWindow : ScriptableObject, ISearchWindowProvider
    {
        private DSGraphView _graphView;
        private Texture2D _indentationIcon;
        public void Initialize(DSGraphView dSGraphView)
        {
            _graphView = dSGraphView;

            _indentationIcon = new Texture2D(1, 1);
            _indentationIcon.SetPixel(0, 0, Color.clear);
            _indentationIcon.Apply();
        }
        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            List<SearchTreeEntry> searchTreeEntries = new List<SearchTreeEntry>()
            {
                new SearchTreeGroupEntry(new GUIContent("Create Element")),
                new SearchTreeGroupEntry(new GUIContent("Create Element"), 1),
                new SearchTreeEntry(new GUIContent("Single Choice", _indentationIcon))
                {
                    level = 2,
                    userData = DSDialogueType.SingleChoice
                },
                new SearchTreeEntry(new GUIContent("Multiple Choice", _indentationIcon))
                {
                    level = 2,
                    userData = DSDialogueType.MultipleChoice
                },
                new SearchTreeGroupEntry(new GUIContent("Dialogue Group"), 1),
                new SearchTreeEntry(new GUIContent("Single Group", _indentationIcon))
                {
                    level = 2,
                    userData = new Group()
                }
            };

            return searchTreeEntries;
        }

        public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
        {
            Vector2 localMousePos = _graphView.GetLocalMousePosition(context.screenMousePosition);

            switch (SearchTreeEntry.userData)
            {
                case DSDialogueType.SingleChoice:
                    {
                        DSSingleChoiceNode singleChoiceNode = (DSSingleChoiceNode) _graphView.CreateNode(DSDialogueType.SingleChoice, localMousePos);
                        _graphView.AddElement(singleChoiceNode);
                        return true;
                    }
                    break;
                case DSDialogueType.MultipleChoice:
                    {
                        DSMultipleChoiceNode multipleChoiceNode = (DSMultipleChoiceNode)_graphView.CreateNode(DSDialogueType.MultipleChoice, localMousePos);
                        _graphView.AddElement(multipleChoiceNode);
                        return true;
                    }
                    break;
                case Group _:
                    {
                        Group group = (Group) _graphView.CreateGroup("Dialogue Group", localMousePos);
                        _graphView.AddElement(group);
                        return true;
                    }
                    break;
            }
            return false;
        }
    }
}
