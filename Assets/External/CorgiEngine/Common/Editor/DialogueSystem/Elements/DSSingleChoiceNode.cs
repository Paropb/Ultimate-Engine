using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    public class DSSingleChoiceNode : DSNode
    {
        public override void Initialize(Vector2 position)
        {
            base.Initialize(position);

            DialogueType = DSDialogueType.SingleChoice;
            Choices.Add("Next Dialogue");
        }
        protected override void DrawContent()
        {
            base.DrawContent();

            /* OUTPUT CONTAINER */
            foreach (string choice in Choices)
            {
                Port choicePort = GUIElementUtility.CreatePort(this, choice, Orientation.Horizontal, Direction.Output, Port.Capacity.Single);

                outputContainer.Add(choicePort);
            }
        }
    }
}
