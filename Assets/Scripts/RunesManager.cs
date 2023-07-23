using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class RunesManager : MonoBehaviour
{
    static RunesManager instance = null;
    public Texture[] runes = new Texture[6];
    public static readonly Dictionary<TrapType, TrapDTO> dict = new(6);

    void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        foreach (TrapType trap in Enum.GetValues(typeof(TrapType)))
        {
            Texture rune;

            do
            {
                int randomIndex = UnityEngine.Random.Range(0, runes.Length);
                rune = runes[randomIndex];
            } while (dict.Any(entry => entry.Value.texture == rune));

            dict.Add(trap, new(rune, UnityEngine.Random.value >= 0.5));
        }

        UIDocument document = GetComponent<UIDocument>();
        VisualElement container = document.rootVisualElement.Q("Container");

        foreach (var (_, dto) in dict)
        {
            if (!dto.enabled) continue;

            Image img = new();

            img.image = dto.texture;
            img.AddToClassList("rune");
            img.style.width = dto.texture.width * 0.5f;
            img.style.height = dto.texture.height * 0.5f;

            container.Add(img);
        }
    }
}

public class TrapDTO
{
    public Texture texture;
    public bool enabled;

    public TrapDTO(Texture texture, bool enabled)
    {
        this.texture = texture;
        this.enabled = enabled;
    }

}

public enum TrapType
{
    Barrel,
    Ceiling,
    Fish,
    Floor,
    Impale,
    Spike,
}

