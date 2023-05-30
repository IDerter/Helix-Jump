using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LevelPalette
{
    public Color AxisColor;
    public Color BallColor;
    public Color DefaultSegmentColor;
    public Color TrapSegmentColor;
    public Color FinishSegmentColor;
    public Color BackgroundColor;
    public Color CameraBackgroundColor;
}
public class LevelColors : MonoBehaviour
{
    [SerializeField] private Material axisMaterial;
    [SerializeField] private Material ballMaterial;
    [SerializeField] private Material defaultSegmentMaterial;
    [SerializeField] private Material trapSegmentMaterial;
    [SerializeField] private Material finishSegmentMaterial;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private new Camera camera;

    [SerializeField] private LevelPalette[] palettes;

    private void Start()
    {
        int index = Random.Range(0, palettes.Length);

        axisMaterial.color = palettes[index].AxisColor;
        ballMaterial.color = palettes[index].BallColor;
        defaultSegmentMaterial.color = palettes[index].DefaultSegmentColor;
        trapSegmentMaterial.color = palettes[index].TrapSegmentColor;
        finishSegmentMaterial.color = palettes[index].FinishSegmentColor;
        backgroundImage.color = palettes[index].BackgroundColor;
        camera.backgroundColor = palettes[index].CameraBackgroundColor;
    }

}
