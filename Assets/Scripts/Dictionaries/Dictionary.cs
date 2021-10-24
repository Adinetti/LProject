using UnityEngine;
using UnityEditor;

namespace LProject.Dictionaries {
	[CreateAssetMenu(fileName = "dictionary", menuName = "Localization/Create dictionary")]
	public class Dictionary : ScriptableObject {
        private static readonly string _location = "Assets/Localizations/Dictionaries";

		public TextData[] texts;

        public static Dictionary CreateFromJson(string json, string name) {
            var asset = CreateInstance<Dictionary>();
            JsonUtility.FromJsonOverwrite(json, asset);
            if (System.IO.Directory.Exists($"_location/{name}") == false) {
                System.IO.Directory.CreateDirectory($"_location/{name}");
            }
            AssetDatabase.CreateAsset(asset, $"{_location}/{name}/{name}.asset");
            AssetDatabase.SaveAssets();
            return asset;
        }
    }
}


