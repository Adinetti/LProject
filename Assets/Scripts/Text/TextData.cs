using UnityEditor;
using UnityEngine;

namespace LProject.Text {
    //[System.Serializable]
    [CreateAssetMenu(fileName = "text", menuName = "Localization/Create text")]
    public class TextData : ScriptableObject {
        public string originalText;
        public Translation[] translations;

        public static TextData CreateFromJson(string json, string name) {
            var asset = CreateInstance<TextData>();
            JsonUtility.FromJsonOverwrite(json, asset);
            var pathToDir = $"Assets/Localizations/Texts";
            if (System.IO.Directory.Exists(pathToDir) == false) {
                System.IO.Directory.CreateDirectory(pathToDir);
            }
            AssetDatabase.CreateAsset(asset, $"{pathToDir}/{name}.asset");
            AssetDatabase.SaveAssets();
            return asset;
        }
    }
}


