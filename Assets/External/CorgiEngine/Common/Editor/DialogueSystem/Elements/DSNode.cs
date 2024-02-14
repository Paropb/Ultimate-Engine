using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class DSNode: Node
    {
	    public string DialogueName { get; set; }
        public List<string> Choices { get; set; }
        public string Text { get; set; }
        public DSDialogueType DialogueType { get; set; }

        public virtual void Initialize(Vector2 position)
        {
            DialogueName = "DialogueName";
            Choices = new List<string>();
            Text = "Dialogue Text.";

            SetPosition(new Rect(position, Vector2.zero));

            mainContainer.AddToClassList("ds-node__main-container");
            extensionContainer.AddToClassList("ds-node__extension-container");
        }
        public void Draw()
        {
            DrawContent();
            RefreshExpandedState();
        }
        protected virtual void DrawContent()
        {
            /* TITLE CONTAINER */
            TextField dialogueNameTextField = GUIElementUtility.CreateTextField(DialogueName);

            dialogueNameTextField.AddClasses(
                "ds-node__text-field",
                "ds-node__filename_text-field__hidden",
                "ds-node__filename_text-field",
                "ds-node__text-field__hidden");

            titleContainer.Insert(0, dialogueNameTextField);

            /* INPUT CONTAINER */
            Port inputPort = GUIElementUtility.CreatePort(this, "Dialogue Connection", Orientation.Horizontal, Direction.Input, Port.Capacity.Multi);
            inputContainer.Add(inputPort);

            /* EXTENSION CONTAINER */
            VisualElement customDataContainer = new VisualElement();

            customDataContainer.AddClasses("ds-node__custom-data-contatiner");

            Foldout textFoldout = GUIElementUtility.CreateFoldout("Dialogue Text");

            TextField textTextField = GUIElementUtility.CreateTextField(Text);

            textTextField.multiline = true;

            textTextField.AddClasses(
                "ds-node__text-field",
                "ds-node__quote-text-field"
                );

            textFoldout.Add(textTextField);
            customDataContainer.Add(textFoldout);
            extensionContainer.Add(customDataContainer);

            RefreshExpandedState();
        }
    }
}
