using UnityEditor;
using static UnityEditor.EditorGUILayout;

public abstract class CustomEditorWindow : EditorWindow
{
    #region Constants
    private const float START_END_SPACE = 1;
    private const float FIELD_SPACE = 4;
    #endregion

    private protected abstract void ResetOptions();

    private protected void FieldSpace() 
        => Space(FIELD_SPACE);

    private protected void BeginVerticalBox()
    {
        BeginVertical("box");
        Space(START_END_SPACE);
    }
    private protected void EndVerticalBox()
    {
        Space(START_END_SPACE);
        EndVertical();
    }

    private protected string GetEnumName<T>(T enumName)
        => System.Enum.GetName(typeof(T), enumName);
}