using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

namespace LProject { 
	public class CreateLocalizationWindow : EditorWindow {
		[MenuItem("Localization/Load from file")]
		public static void Open() => CreateWindow<EditorWindow>("Load localization");

        private void OnGUI() {
            
        }
    }
}


