using SDTool.Profile;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Networking.UnityWebRequest;
using UnityEngine.Profiling;

namespace SDTool.Editor.UI
{
    class SDToolEditorWindow : EditorWindow
    {
        static ToolbarItem _toolbarSelection = ToolbarItem.General;
        enum ToolbarItem { General, Settings }

        readonly string[] _toolbarLabels = {
            nameof(ToolbarItem.General),
            nameof(ToolbarItem.Settings)
        };

        static SDToolProfileEditor _profileEditor;
        UnityEditor.Editor _settingsEditor;

        static SDToolProfile _currentProfile;

        void OnEnable()
        {
            _settingsEditor = UnityEditor.Editor.CreateEditor(Settings.instance);

            if (_currentProfile)
                _profileEditor = CreateProfileEditor();
        }

        void OnGUI()
        {
            EditorGUILayout.Space();
            _toolbarSelection =
                (ToolbarItem)ExtendedGUI.Toolbar(
                    (int)_toolbarSelection, _toolbarLabels, 32);
            EditorGUILayout.Space();

            switch (_toolbarSelection)
            {
                case ToolbarItem.General:
                    General();
                    break;
                case ToolbarItem.Settings:
                    _settingsEditor.OnInspectorGUI();
                    break;
                default:
                    break;
            }
        }

        void General()
        {
            EditorGUILayout.BeginHorizontal();

            ManageProfile(ExtendedGUI.ObjectField("", _currentProfile));

            if (GUILayout.Button("New", GUILayout.MaxWidth(42)))
                ManageProfile(SDToolManager.CreateProfile());

            if (GUILayout.Button("Clone", GUILayout.MaxWidth(48)))
                ManageProfile(SDToolManager.CloneProfile(_currentProfile));

            EditorGUILayout.EndHorizontal();

            ExtendedGUI.Separator();

            if (_currentProfile)
                DrawProfile();
            else
                NoProfileSelected();
        }

        static void ManageProfile(SDToolProfile profile)
        {
            if (_currentProfile != profile)
            {
                _currentProfile = profile;
                _profileEditor = CreateProfileEditor();
            }
        }

        static void DrawProfile()
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

            if (ExtendedGUI.Button("Interrupt", 24, 125))
                Debug.Log("Interrupt");

            EditorGUILayout.EndVertical();

            ExtendedGUI.EndAlignCenter();

            EditorGUILayout.Space();
        }

        void NoProfileSelected()
        {
            ExtendedGUI.BeginAlignCenter();

            GUILayout.Label("No SDTool Profile selected!");

            ExtendedGUI.EndAlignCenter();
        }

        static SDToolProfileEditor CreateProfileEditor()
            => (SDToolProfileEditor)UnityEditor.Editor.CreateEditor(_currentProfile);

        public static void Open(SDToolProfile profile)
        {
            OpenWindow();
            ManageProfile(profile);
        }

        [MenuItem("Tools/SD Tool")]
        static void MenuOpenWindow() => OpenWindow();

        static void OpenWindow() 
            => GetWindow<SDToolEditorWindow>("SD Tool");
    }
}