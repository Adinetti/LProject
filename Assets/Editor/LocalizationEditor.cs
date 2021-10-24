using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using System.IO;
using System.Text;
using LProject;
using LProject.Dictionaries; 

namespace LProjectEditor {
    [CustomEditor(typeof(Localization))]
    public class LocalizationEditor : Editor {
        private Localization _localization;

        private void OnEnable() {
            _localization = (Localization)target;
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            if (GUILayout.Button("Save to file")) {
                SaveToFile();
            }
        }

        private void SaveToFile() {
            var path = AssetDatabase.GetAssetPath(_localization).Split('.')[0];
            var pathToJson = $"./{path}.json";
            var data = new StringBuilder();
            for (int i = 0; i < _localization.dictionaries.Length; i++) {
                var dict = _localization.dictionaries[i];
                var json = JsonUtility.ToJson(dict);
                data.AppendLine(json);
            }
            File.WriteAllText(pathToJson, data.ToString());
            Debug.Log("Localization to save");
        }
    }
}


