using System;
using UnityEditor;
using UnityEngine;

namespace SDTool.Editor.UI
{
    class SDToolEditorWindow : EditorWindow
    {
        static ToolbarItem _toolbarSelection = ToolbarItem.Single;
        
        enum ToolbarItem { Single, Batch, Settings }

        readonly string[] _toolbarLabels = {
            nameof(ToolbarItem.Single),
            nameof(ToolbarItem.Batch),
            nameof(ToolbarItem.Settings)
        };

        UnityEditor.Editor _settingsEditor;
        static ProfileEditor _profileEditor;
        static BatchEditor _batchEditor;

        static ProfileData _currentProfile;
        static BatchData _currentBatch;

        void OnEnable()
        {
            _settingsEditor = UnityEditor.Editor.CreateEditor(Settings.instance);

            if (_currentProfile)
                _profileEditor = CreateAssetEditor<ProfileEditor, ProfileData>(_currentProfile);

            if (_currentBatch)
                _batchEditor = CreateAssetEditor<BatchEditor, BatchData>(_currentBatch);
        }

        static TEditor CreateAssetEditor<TEditor, TObject>(TObject asset)
            where TEditor : UnityEditor.Editor
            where TObject : SDToolAsset
            => (TEditor)UnityEditor.Editor.CreateEditor(asset);

        void OnGUI()
        {
            EditorGUILayout.Space();
            _toolbarSelection =
                (ToolbarItem)ExtendedGUI.Toolbar(
                    (int)_toolbarSelection, _toolbarLabels, 32);
            EditorGUILayout.Space();

            switch (_toolbarSelection)
            {
                case ToolbarItem.Single:
                    ShowAsset(ref _profileEditor, ref _currentProfile, "Profile", DrawProfile);
                    break;
                case ToolbarItem.Batch:
                    ShowAsset(ref _batchEditor, ref _currentBatch, "Batch", DrawBatch);
                    break;
                case ToolbarItem.Settings:
                    _settingsEditor.OnInspectorGUI();
                    break;
                default:
                    break;
            }
        }

        void ShowAsset<TEditor, TObject>(ref TEditor editor,
                                         ref TObject current,
                                         string name,
                                         Action drawContent)
            where TEditor : UnityEditor.Editor
            where TObject : SDToolAsset
        {
            EditorGUILayout.BeginHorizontal();

            ManageAsset(ref editor, ref current, ExtendedGUI.ObjectField("", current));

            if (GUILayout.Button("New", GUILayout.MaxWidth(42)))
                ManageAsset(ref editor, ref current, SDToolManager.CreateAsset<TObject>(name));

            if (GUILayout.Button("Clone", GUILayout.MaxWidth(48)))
                ManageAsset(ref editor, ref current, SDToolManager.CloneAsset(current));

            EditorGUILayout.EndHorizontal();

            ExtendedGUI.Separator();

            if (current)
                drawContent.Invoke();
            else
                NoAssetSelected(name);
        }

        static void ManageAsset<TObject, TEditor>(ref TEditor editor,
                                                  ref TObject current,
                                                  TObject newAsset)
            where TEditor : UnityEditor.Editor
            where TObject : SDToolAsset
        {
            if (current != newAsset)
            {
                current = newAsset;
                editor = CreateAssetEditor<TEditor, TObject>(newAsset);
            }
        }

        void NoAssetSelected(string name)
        {
            ExtendedGUI.BeginAlignCenter();

            GUILayout.Label($"No SDTool {name} selected!");

            ExtendedGUI.EndAlignCenter();
        }

        void DrawProfile()
        {
            _profileEditor.DrawInWindow();

            GUILayout.FlexibleSpace();

            ExtendedGUI.BeginAlignCenter();
            if (ExtendedGUI.Button("Generate", 50, 125))
                SDToolManager.Process(_currentProfile, ResultEditorWindow.Open);

            EditorGUILayout.Space(16);

            EditorGUILayout.BeginVertical();

            if (ExtendedGUI.Button("Preprocess", 24, 125))
                SDToolManager.Preprocess(_currentProfile, PreprocessEditorWindow.Open);

            if (ExtendedGUI.Button("Cancel", 24, 125))
                SDToolManager.Interrupt();

            EditorGUILayout.EndVertical();

            ExtendedGUI.EndAlignCenter();

            EditorGUILayout.Space();
        }

        void DrawBatch()
        {
            _batchEditor.DrawInWindow();

            GUILayout.FlexibleSpace();

            ExtendedGUI.BeginAlignCenter();
            if (ExtendedGUI.Button("Generate", 50, 125))
                SDToolManager.Process(_currentBatch);

            EditorGUILayout.Space(16);

            if (ExtendedGUI.Button("Cancel", 50, 125))
                SDToolManager.Interrupt();

            ExtendedGUI.EndAlignCenter();

            EditorGUILayout.Space();
        }

        [MenuItem("Tools/SD Tool")]
        static void MenuOpenWindow() => OpenWindow();

        static void OpenWindow()
            => GetWindow<SDToolEditorWindow>("SD Tool");

        public static void Open(ProfileData asset)
        {
            OpenWindow();
            ManageAsset(ref _profileEditor, ref _currentProfile, asset);
            _toolbarSelection = ToolbarItem.Single;
        }

        public static void Open(BatchData asset)
        {
            OpenWindow();
            ManageAsset(ref _batchEditor, ref _currentBatch, asset);
            _toolbarSelection = ToolbarItem.Batch;
        }
    }
}