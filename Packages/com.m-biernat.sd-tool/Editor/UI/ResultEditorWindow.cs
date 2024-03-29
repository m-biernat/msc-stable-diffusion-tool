﻿using UnityEditor;
using UnityEngine;

namespace SDTool.Editor.UI
{
    public class ResultEditorWindow : EditorWindow
    {
        static ProfileData _profile;
        static Texture2D[] _results;

        static bool[] _selection;
        static bool _singleImage;

        static Vector2 _maxSize;
        Vector2 _scroll;

        public static void Open(ProfileData profile, Texture2D[] results)
        {
            _profile = profile;
            _results = results;

            _selection = new bool[results.Length];

            _singleImage = results.Length == 1;

            var window = 
                GetWindow<ResultEditorWindow>(
                    true, $"{profile.name} Results", false);

            _maxSize = new Vector2()
            {
                x = Mathf.Clamp(results[0].width, 64, 512),
                y = Mathf.Clamp(results[0].height, 64, 512)
            };

            window.maxSize = new Vector2()
            {
                x = Mathf.Clamp(_maxSize.x, 288, 512) + 64,
                y = Mathf.Clamp(_maxSize.y, 256, 512) + 64
            };
            window.minSize = window.maxSize;
        }

        void OnEnable()
        {
            if (_results == null)
                Close();
        }

        void OnGUI()
        {
            _scroll = EditorGUILayout.BeginScrollView(_scroll);

            if (_singleImage)
                ShowImage(_results[0]);
            else
            {
                for (int i = 0; i < _results.Length; i++)
                    ShowImage(_results[i], ref _selection[i]);
            }

            EditorGUILayout.EndScrollView();
            
            Buttons();
        }

        void ShowImage(Texture2D image)
        {
            EditorGUILayout.Space(12);
            ExtendedGUI.BeginAlignCenter();

            GUILayout.Label(image,
                            GUILayout.MaxWidth(_maxSize.x),
                            GUILayout.MaxHeight(_maxSize.y));

            ExtendedGUI.EndAlignCenter();
        }

        void ShowImage(Texture2D image, ref bool selection)
        {
            EditorGUILayout.Space(12);
            ExtendedGUI.BeginAlignCenter();

            selection = EditorGUILayout.Toggle(selection, GUILayout.MaxWidth(12));

            GUILayout.Label(image, 
                            GUILayout.MaxWidth(_maxSize.x), 
                            GUILayout.MaxHeight(_maxSize.y));
            
            ExtendedGUI.EndAlignCenter();
        }

        void Buttons()
        {
            EditorGUILayout.Space();
            ExtendedGUI.BeginAlignCenter();

            if (_singleImage)
            {
                if (ExtendedGUI.Button("Save", 30, 100))
                    SaveAll();
            }
            else
            {
                if (ExtendedGUI.Button("Save All", 30, 100))
                    SaveAll();

                EditorGUILayout.Space();

                if (ExtendedGUI.Button("Save Selected", 30, 100))
                    SaveSelected();
                    
            }
            
            EditorGUILayout.Space();

            if (ExtendedGUI.Button("Discard", 30, 100))
                Discard();

            ExtendedGUI.EndAlignCenter();
            EditorGUILayout.Space(12);
        }

        void SaveAll()
        {
            SDToolManager.SaveImages(_profile, _results);
            Discard();
        }

        void SaveSelected()
        {
            SDToolManager.SaveImages(_profile, _results, _selection);
            Discard();
        }

        void Discard()
        {
            _profile = null;
            _results = null;
            _selection = null;
            Close();
        }
    }
}