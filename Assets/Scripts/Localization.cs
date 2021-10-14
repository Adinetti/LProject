using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using LProject.Text;
using UnityEditor;

namespace LProject {
	[CreateAssetMenu(fileName = "localizations", menuName = "Localization/Create localization")]
	public class Localization : ScriptableObject {
		public TextData[] texts;

        public static void CreateMyAsset() {
            var asset = CreateInstance<Localization>();
            AssetDatabase.CreateAsset(asset, "Assets/Localization.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}


