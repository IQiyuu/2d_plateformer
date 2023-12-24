using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyManager : MonoBehaviour
{
    private static readonly KeyCode[] defaultKeys = { KeyCode.A, KeyCode.D, KeyCode.Z, KeyCode.S };
    private static readonly string[] keyNames = { "Left", "Right", "Up", "Down" };
    private static readonly int keyNumber = defaultKeys.Length;
    private static readonly string toucheKeys = "keys";

    private static KeyCode[] keys;

    void Start() {
        keys = new KeyCode[keyNumber];

        for (int i = 0; i < keyNumber; i++) {
            keys[i] = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(toucheKeys + keyNames[i], defaultKeys[i].ToString()));
        }
    }

    public static void ChangerKey(int index, KeyCode newKey) {
        keys[index] = newKey;

        PlayerPrefs.SetString(toucheKeys + keyNames[index], newKey.ToString());
        PlayerPrefs.Save();
    }

    public KeyCode[] getKeys() {
        return keys;
    }

    public KeyCode getKey(string code) {
        int index = System.Array.IndexOf(keyNames, code);
        print(keys);
        if (index == -1)
            return KeyCode.None;
        return keys[index];
    }
}