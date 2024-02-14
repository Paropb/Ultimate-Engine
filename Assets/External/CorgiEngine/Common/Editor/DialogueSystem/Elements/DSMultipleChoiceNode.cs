using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace MoreMountains.CorgiEngine
{
    public class DSMultipleChoiceNode : DSNode
    {
        public override void Initialize(Vector2 position)
        {
            base.Initialize(position);

            DialogueType = DSDialogueType.MultipleChoice;
            Choices.Add("New Choice");
        }
        protected override void DrawContent()
        {
            base.DrawContent();

            /* MAIN CONTAINER */
            Button addChoiceButton = GUIElementUtility.CreateButton("Add Choice", ()=>
            {
                Port choicePort = CreateChoicePort("New Choice");

                outputContainer.Add(choicePort);
            });

            addChoiceButton.AddClasses("ds-node__button");

            mainContainer.Insert(1, addChoiceButton);

            /* OUTPUT CONTAINER */
            foreach (string choice in Choices)
            {
                Port choicePort = CreateChoicePort(choice);

                outputContainer.Add(choicePort);
            }
        }
        #region Element Creation
        private Port CreateChoicePort(string choice)
        {
            Port choicePort = GUIElementUtility.CreatePort(this, "", Orientation.Horizontal, Direction.Output, Port.Capacity.Single);

            Button deleteChoiceButton = GUIElementUtility.CreateButton("x");

            deleteChoiceButton.AddClasses("ds-node__button");

            TextField choiceTextField = GUIElementUtility.CreateTextField(choice);

            choiceTextField.style.flexDirection = FlexDirection.Column;
            choiceTextField.AddClasses(
                "ds-node__textfield",
                "ds-node__choice-text-field",
                "ds-node__textfield__hidden"
                );

            choicePort.Add(choiceTextField);
            choicePort.Add(deleteChoiceButton);


            return choicePort;
        }
        #endregion
    }
}
