// (c) Copyright HutongGames, LLC 2010-2011. All rights reserved.

using UnityEngine;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.GUILayout)]
	[Tooltip("A Vertical Slider linked to a Float Variable.")]
	public class GUILayoutVerticalSlider : GUILayoutAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmFloat floatVariable;
		[RequiredField]
		public FsmFloat topValue;
		[RequiredField]
		public FsmFloat bottomValue;
		public FsmEvent changedEvent;
		
		public override void Reset()
		{
			floatVariable = null;
			topValue = 100;
			bottomValue = 0;
			changedEvent = null;
		}
		
		public override void OnGUI()
		{
			bool guiChanged = GUI.changed;
			GUI.changed = false;
			
			if(floatVariable != null)
			{
				floatVariable.Value = GUILayout.VerticalSlider(floatVariable.Value, topValue.Value, bottomValue.Value, LayoutOptions);
			}
			
			if (GUI.changed)
			{
				Fsm.Event(changedEvent);
				GUIUtility.ExitGUI();
			}
			
			GUI.changed = guiChanged;
		}
	}
}