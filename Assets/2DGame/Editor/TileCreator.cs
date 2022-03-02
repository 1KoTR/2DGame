using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static UnityEditor.EditorGUILayout;
using System;

public enum TileType
{
    Background,
    Ground,
    Decoration,
    None
}

public class TileCreator : CustomEditorWindow
{
    [MenuItem("GameObject/2D Object/Tile")]
    public static void Init()
    {
        GetWindow<TileCreator>("Create Tile");
    }

    #region Constants
    private const string SAVE_PATH = "Assets/2DGame/Views/Resources/Prefabs/Tiles/";
    #endregion

    private TileType _type = TileType.None;

    private string _name = "New Tile";
    private Sprite _sprite = null;

    private bool _isShowSettings = true;

    private void OnGUI()
    {
        BeginVerticalBox();
        _type = (TileType)EnumPopup("Type", _type);
        EndVerticalBox();

        if (_type == TileType.None)
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
            _sprite = (Sprite)ObjectField("Sprite", _sprite, typeof(Sprite), false);
            EndVerticalBox();
        }
        EndFoldoutHeaderGroup();
        #endregion

        #region CreateButton
        if (_sprite != null &&
            _name != "" &&
            GUILayout.Button("Create"))
        {
            CreateTile();
        }
        #endregion
    }

    private void CreateTile()
    {
        var go = new GameObject(_name);

        go.AddComponent<SpriteRenderer>();

        var sr = go.GetComponent<SpriteRenderer>();
        sr.sprite = _sprite;
        sr.sortingOrder = (int)_type;

        var path = $"{SAVE_PATH}/{_type}/{_name}.prefab";
        path = AssetDatabase.GenerateUniqueAssetPath(path);
        PrefabUtility.SaveAsPrefabAsset(go, path);
        DestroyImmediate(go);
    }

    private protected override void ResetOptions()
    {
        _type = TileType.None;
        _name = "New Tile";
        _isShowSettings = true;
    }
}
