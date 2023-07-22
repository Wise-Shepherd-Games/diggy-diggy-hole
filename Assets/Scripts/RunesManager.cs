using System;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

namespace RunesManager
{
    public class RunesManager : MonoBehaviour
    {
        public Texture[] runes = new Texture[6];
        private Dictionary<Trap, Texture> dict = new(6);

        void Awake()
        {
            foreach (Trap trap in Enum.GetValues(typeof(Trap)))
            {
                Texture rune;

                do
                {
                    int randomIndex = UnityEngine.Random.Range(0, runes.Length);
                    rune = runes[randomIndex];
                } while (dict.ContainsValue(rune));

                dict.Add(trap, rune);
            }

            UIDocument document = GetComponent<UIDocument>();
            VisualElement container = document.rootVisualElement.Q("Container");

            foreach (var (_, texture) in dict)
            {
                Image img = new();

                img.image = texture;
                img.AddToClassList("rune");
                img.style.width = texture.width * 0.5f;
                img.style.height = texture.height * 0.5f;

                container.Add(img);
            }
        }
    }

    enum Trap
    {
        Barrel,
        Ceiling,
        Fish,
        Floor,
        Impale,
        Spike,
    }

}