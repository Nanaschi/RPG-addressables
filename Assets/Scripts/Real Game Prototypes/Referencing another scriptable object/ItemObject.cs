
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/Item", order = 1)]
public class ItemObject : ScriptableObject
{
    [CustomEditor(typeof(ItemObject))]
    public class ItemObjectInspector : Editor
    {
        SerializedProperty m_type;
        SerializedProperty m_data;

        private void OnEnable()
        {
            m_type = serializedObject.FindProperty("type");
            m_data = serializedObject.FindProperty("data");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(m_type);
            if (EditorGUI.EndChangeCheck())
            {
                m_data.managedReferenceValue = 
                        ItemObject.CreateBlankData((ItemType)m_type.intValue);
            }

            // avoid drawing type a second time
            // avoid drawing annoying Script field
            DrawPropertiesExcluding(serializedObject, new string[] { "type", "m_Script" });
            serializedObject.ApplyModifiedProperties();
        }
    }

    [System.Serializable]
    public enum ItemType
    {
        Physical,
        Magical
    }

    // Determines how to create an Item from each ItemType
    public static Item CreateBlankData(ItemType type)
    {
        switch (type)
        {
            default:
            case ItemType.Physical:
                return new PhysicalItem();

            case ItemType.Magical:
                return new MagicalItem();
        }
    }

    [System.Serializable]
    public class Item
    {
        [SerializeField] public string typeDescription;
    }

    [System.Serializable]
    public class MagicalItem : Item
    {
        [SerializeField] string elementName;

        public MagicalItem() { typeDescription = "Magical"; elementName = "fire"; }
    }

    [System.Serializable]
    public class PhysicalItem : Item
    {
        [SerializeField] float materialHardness;
        public PhysicalItem() { typeDescription = "Physical"; materialHardness = 1f; }

    }

    public ItemType type;
    [SerializeReference] public Item data;
}