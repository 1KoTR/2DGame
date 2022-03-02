using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUILayout;

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

public sealed class UnitCreator : CustomEditorWindow
{
    [MenuItem("GameObject/2D Object/Unit")]
    public static void Init()
    {
        GetWindow<UnitCreator>("Create Unit");
    }

    #region Constants
    private const float START_END_SPACE = 1;
    private const float FIELD_SPACE = 4;

    private const string Body = nameof(Body);
    private const string Weapon = nameof(Weapon);
    private const string Engine = nameof(Engine);

    private const string SAVE_PATH = "Assets/2DGame/Views/Resources/Prefabs/Units/";
    #endregion

    private UnitType _type = UnitType.None;

    private string _name = "New Unit";
    private UnitTag _tag = UnitTag.Enemy;
    private Sprite _sprite = null;

    private bool _isShowSettings = false;
    private bool _isShowAdvancedSettings = false;

    private AirplaneConfig _airplaneConfig;
    private TurretConfig _turretConfig;

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

        ScriptableObject config = null;
        #region Advanced Settings
        _isShowAdvancedSettings = BeginFoldoutHeaderGroup(_isShowAdvancedSettings, $"{type} Advanced Settings");
        if (_isShowAdvancedSettings)
        {
            BeginVerticalBox();
            switch (_type)
            {
                #region Airplane
                case UnitType.Airplane:
                    _airplaneConfig = (AirplaneConfig)ObjectField("Config", _airplaneConfig, typeof(AirplaneConfig), false);
                    if (_airplaneConfig == null)
                        break;
                    // ...
                    config = _airplaneConfig;
                    break;
                #endregion

                #region Turret
                case UnitType.Turret:
                    _turretConfig = (TurretConfig)ObjectField("Config", _turretConfig, typeof(TurretConfig), false);
                    if (_turretConfig == null)
                        break;
                    FieldSpace();
                    // ...
                    config = _airplaneConfig;
                    break;
                #endregion

                #region Tank
                case UnitType.Tank:
                    // ...
                    break;
                #endregion
            }
            EndVerticalBox();
        }
        EndFoldoutHeaderGroup();
        #endregion

        #region CreateButton
        if (_sprite != null &&
            _name != "" &&
            config != null &&
            GUILayout.Button("Create"))
        {
            CreateUnit();
        }
        #endregion
    }

    private protected override void ResetOptions()
    {
        _name = "New Unit";
        _sprite = null;
        _tag = UnitTag.Enemy;
        _isShowSettings = true;
        _isShowAdvancedSettings = false;
        _airplaneConfig = null;
        _turretConfig = null;
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

        switch (_tag)
        {
            case UnitTag.Player:
                switch (_type)
                {
                    case UnitType.Airplane:
                        go.AddComponent<AirplaneView>();
                        go.AddComponent<PlayerAirplaneController>();
                        go.GetComponent<PlayerAirplaneController>().config = _airplaneConfig;
                        break;
                    case UnitType.Turret:
                        // ...
                        break;
                    case UnitType.Tank:
                        // ...
                        break;
                }
                break;
            case UnitTag.Enemy:
                switch (_type)
                {
                    case UnitType.Airplane:
                        // ...
                        break;
                    case UnitType.Turret:
                        // ...
                        break;
                    case UnitType.Tank:
                        // ...
                        break;
                }
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
}
