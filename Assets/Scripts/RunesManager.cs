using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RunesManager : MonoBehaviour
{
    public static bool first = true;
    [SerializeField] GameObject logos;
    [SerializeField] GameObject transition;
    private static RunesManager instance = null;
    public Texture[] runes = new Texture[6];
    private UIDocument document;
    public static readonly Dictionary<TrapType, TrapDTO> dict = new(6);

    void Awake()
    {
        document = GetComponent<UIDocument>();
        logos = GameObject.Find("Logos");
        transition = GameObject.Find("Transition");

        if (first)
        {
            logos.SetActive(true);
            transition.SetActive(false);
        }
        else
        {
            logos.SetActive(false);
            transition.SetActive(true);
        }

        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
        InitializeDict();
        UpdateUI();
    }

    void OnEnable()
    {
        ChangeScene.sceneChanged += OnChangeSceneEvent;
        PlayerMovement.PlayerMovement.playerDied += OnPlayerDied;
    }

    void OnDisable()
    {
        ChangeScene.sceneChanged -= OnChangeSceneEvent;
        PlayerMovement.PlayerMovement.playerDied -= OnPlayerDied;
    }

    void OnChangeSceneEvent()
    {
        UpdateTrapsEnabled();
        UpdateUI();
    }

    void OnPlayerDied()
    {
        Button button = document.rootVisualElement.Q<Button>("Button");
        button.style.display = DisplayStyle.Flex;
        button.clicked += () =>
        {
            button.style.display = DisplayStyle.None;
            string[] allScenes = ChangeScene.allScenes;
            string scene = allScenes[UnityEngine.Random.Range(0, allScenes.Length)];
            SceneManager.LoadScene(scene);

            InitializeDict();
            UpdateUI();

        };
    }

    void InitializeDict()
    {
        if (dict.Count > 0)
            dict.Clear();

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
    }

    void UpdateTrapsEnabled()
    {
        foreach (var (_, dto) in dict)
            dto.enabled = UnityEngine.Random.value >= 0.5;
    }

    void UpdateUI()
    {
        VisualElement container = document.rootVisualElement.Q("Container");
        container.Clear();

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

