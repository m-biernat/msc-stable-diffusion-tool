using SDTool.Profile;
using UnityEditor;
using UnityEngine;

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

        static SDToolProfile _currnetProfile;

        void OnEnable()
        {
            _settingsEditor = UnityEditor.Editor.CreateEditor(Settings.instance);

            if (_currnetProfile)
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

            ManageProfile(ExtendedGUI.ObjectField("", _currnetProfile));

            if (GUILayout.Button("New", GUILayout.MaxWidth(42)))
                Debug.Log("");
            //ManageProfile(SDToolManager.CreateProfile());

            if (GUILayout.Button("Clone", GUILayout.MaxWidth(48)))
                Debug.Log("");
                //ManageProfile(SDToolManager.CloneProfile(_currnetProfile));

            EditorGUILayout.EndHorizontal();

            ExtendedGUI.Separator();

            if (_currnetProfile)
                _profileEditor.DrawInWindow();
            else
            {
                ExtendedGUI.BeginAlignCenter();

                GUILayout.Label("No SDTool Profile selected!");

                ExtendedGUI.EndAlignCenter();
            }
        }

        static void ManageProfile(SDToolProfile profile)
        {
            if (_currnetProfile != profile)
            {
                _currnetProfile = profile;
                _profileEditor = CreateProfileEditor();
            }
        }

        static SDToolProfileEditor CreateProfileEditor()
            => (SDToolProfileEditor)UnityEditor.Editor.CreateEditor(_currnetProfile);

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