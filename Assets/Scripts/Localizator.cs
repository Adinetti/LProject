using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using LProject.Dictionaries;

namespace LProject { 
	public class Localizator : MonoBehaviour {
		[SerializeField] private Localization _localization;
		private Dictionary<string, List<Translation>> _textData;

        private void Awake() {
            _textData = new Dictionary<string, List<Translation>>();
            for (int i = 0; i < _localization.dictionaries.Length; i++) {
                var dict = _localization.dictionaries[i];
                AddDictionary(dict);
            }
        }

        private void AddDictionary(Dictionary dict) {
            for (int t = 0; t < dict.texts.Length; t++) {
                var text = dict.texts[t];
                var original = text.originalText;
                if (_textData.ContainsKey(original) == false) {
                    _textData.Add(original, new List<Translation>());
                }
                for (int i = 0; i < text.translations.Length; i++) {
                    _textData[original].Add(text.translations[i]);
                }
            }
        }

        public string GetTranslation(string text, Language language) {
            if (_textData.ContainsKey(text)) {
                var translations = _textData[text];
                for (int i = 0; i < translations.Count; i++) {
                    var translation = translations[i];
                    if (translation.language == language) {
                        return translation.text;
                    }
                }
            }
            return text;
        }
    }
}


