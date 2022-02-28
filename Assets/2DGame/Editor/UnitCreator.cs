using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUILayout;
using static UnityEditor.Progress;

public enum UnitType
{
    Airplane,
    Turret,
    Tank,
    None
}

public enum UnitTag
{
    Player,
    Enemy
}

public sealed class UnitCreator : EditorWindow
{
    [MenuItem("GameObject/2D Object/Unit...")]
    public static void Init()
    {
        GetWindow<UnitCreator>("Create Unit");
    }

    #region Constants
    private const float START_END_SPACE = 1;
    private const float FIELD_SPACE = 4;

    private const int MAX_COUNT = 10;

    private const string Body = nameof(Body);
    private const string Weapon = nameof(Weapon);
    private const string Engine = nameof(Engine);

    private const string SAVE_PATH = "Assets/2DGame/Views/Resources/Prefabs/Units/";
    #endregion

    private UnitType _type = UnitType.None;

    private Sprite _sprite;

    private string _name = "New Unit";
    private UnitTag _tag = UnitTag.Enemy;

    private int _weaponCount = 1;
    private int _engineCount = 1;

    private bool _isShowSettings = false;
    private bool _isShowAdvancedSettings = false;

    public void OnGUI()
    {
        BeginVerticalBox();
        _type = (UnitType)EnumPopup("Type", _type);
        EndVerticalBox();

        if (_type == UnitType.None)
        {
            ResetOptions();
            return;
        }

        var type = GetEnumName(_type);
        #region Settings
        _isShowSettings = BeginFoldoutHeaderGroup(_isShowSettings, $"{type} Settings");
        if (_isShowSettings)
        {
            BeginVerticalBox();
            _name = TextField("Name", _name);
            _tag = (UnitTag)EnumPopup("Tag", _tag);
            _sprite = (Sprite)ObjectField("Sprite", _sprite, typeof(Sprite), false);
            EndVerticalBox();
        }
        EndFoldoutHeaderGroup();
        #endregion

        #region Advanced Settings
        _isShowAdvancedSettings = BeginFoldoutHeaderGroup(_isShowAdvancedSettings, $"{type} Advanced Settings");
        if (_isShowAdvancedSettings)
        {
            BeginVerticalBox();
            _weaponCount = IntSlider("Weapon Count", _weaponCount, 1, MAX_COUNT);
            switch (_type)
            {
                case UnitType.Airplane:
                case UnitType.Tank:
                    _engineCount = IntSlider("Engine Count", _engineCount, 1, MAX_COUNT);
                    break;
            }
            EndVerticalBox();
        }
        EndFoldoutHeaderGroup();
        #endregion

        if (_sprite != null &&
            _name != "" &&
            GUILayout.Button("Create"))
        {
            CreateUnit();
        }
    }

    private void ResetOptions()
    {
        _name = "New Unit";
        _sprite = null;
        _tag = UnitTag.Enemy;
        _weaponCount = 1;
        _engineCount = 1;
        _isShowSettings = false;
        _isShowAdvancedSettings = false;
    }

    private void CreateUnit()
    {
        var go = new GameObject(_name);

        var goTransform = go.transform;

        var tag = GetEnumName(_tag);
        go.tag = tag;
        AddBody(goTransform);
        AddWeapon(goTransform);
        switch (_type)
        {
            case UnitType.Airplane:
            case UnitType.Tank:
                AddEngine(goTransform);
                break;
        }

        var path = $"{SAVE_PATH}/{tag}/{_name}.prefab";
        path = AssetDatabase.GenerateUniqueAssetPath(path);
        PrefabUtility.SaveAsPrefabAsset(go, path);
        DestroyImmediate(go);
    }

    private void AddBody(Transform parentTransform)
    {
        var goBody = new GameObject(Body);
        goBody.transform.parent = parentTransform;
        goBody.AddComponent<SpriteRenderer>();

        var spriteRenderer = goBody.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _sprite;
        spriteRenderer.sortingOrder = 10;
    }
    private void AddWeapon(Transform parentTransform)
    {
        var goWeapon = new GameObject(Weapon);
        goWeapon.transform.parent = parentTransform;
    }
    private void AddEngine(Transform parentTransform)
    {
        var goEngine = new GameObject(Engine);
        goEngine.transform.parent = parentTransform;
    }

    private void FieldSpace() =>
        Space(FIELD_SPACE);
    private void BeginVerticalBox()
    {
        BeginVertical("box");
        Space(START_END_SPACE);
    }
    private void EndVerticalBox()
    {
        Space(START_END_SPACE);
        EndVertical();
    }

    private string GetEnumName<T>(T typeName)
        => System.Enum.GetName(typeof(T), typeName);
}
