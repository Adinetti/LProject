using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using System.IO;
using System.Text;
using LProject;
using LProject.Text;

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
            for (int i = 0; i < _localization.texts.Length; i++) {
                var text = _localization.texts[i];
                var json = JsonUtility.ToJson(text);
                data.AppendLine(json);
            }
            File.WriteAllText(pathToJson, data.ToString());
            Debug.Log("Localization to save");
        }

        private void LoadFromFile() {
            var pathToJson = $"{Application.dataPath}/{_localization.name}.json";
            var message = $"File in: \"{pathToJson}\" don`t exists.";
            if (File.Exists(pathToJson)) {
                var jsons = File.ReadAllLines(pathToJson);
                var texts = new List<TextData>();
                for (int i = 0; i < jsons.Length; i++) {
                    var text =  TextData.CreateFromJson(jsons[i], $"text_{i}");
                    texts.Add(text);
                }
                _localization.texts = texts.ToArray();
                message = "Done.";
            }
            Debug.Log(message);
        }
    }
}


