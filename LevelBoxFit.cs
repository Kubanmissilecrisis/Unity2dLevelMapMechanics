
using UnityEngine;
using UnityEngine.UI;

public class LevelBoxFit : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup gridLayoutGroup = null;
    [SerializeField] private RectTransform gridRectTransform = null;
    [SerializeField] private RectTransform levelBoxRectTransform = null;

    private int numRows = 3;
    private int numCols = 8;

    private float previousWidth = 0f;
    private float previousHeight = 0f;

    void Start()
    {
        if (gridLayoutGroup == null)
        {
            gridLayoutGroup = GetComponent<GridLayoutGroup>();
        }

        if (gridRectTransform == null)
        {
            gridRectTransform = GetComponent<RectTransform>();
        }

        previousWidth = gridRectTransform.rect.width;
        previousHeight = gridRectTransform.rect.height;

        UpdateLayout();
    }

    void Update()
    {
        if (gridRectTransform.rect.width != previousWidth || gridRectTransform.rect.height != previousHeight)
        {
            previousWidth = gridRectTransform.rect.width;
            previousHeight = gridRectTransform.rect.height;

            UpdateLayout();
        }
    }

    void UpdateLayout()
    {
        // Calculate the cell size based on the width of the grid and the number of columns
        float cellWidth = (gridRectTransform.rect.width - gridLayoutGroup.spacing.x * (numCols - 1)) / numCols;

        // Calculate the cell size based on the height of the grid and the number of rows
        float cellHeight = (gridRectTransform.rect.height - gridLayoutGroup.spacing.y * (numRows - 1)) / numRows;

        // Set the cell size to the smaller of the two calculated values
        gridLayoutGroup.cellSize = new Vector2(Mathf.Min(cellWidth, cellHeight), Mathf.Min(cellWidth, cellHeight));

        // Calculate the new spacing based on the cell size and number of columns
        float newSpacing = (gridRectTransform.rect.width - gridLayoutGroup.cellSize.x * numCols) / (numCols - 1);

        // Only update the spacing if it is different from the current spacing
        if (Mathf.Abs(gridLayoutGroup.spacing.x - newSpacing) > 0.01f)
        {
            gridLayoutGroup.spacing = new Vector2(newSpacing, gridLayoutGroup.spacing.y);
        }
    }
}
/*using UnityEngine;
using UnityEngine.UI;

public class LevelBoxFit : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private RectTransform parentRectTransform;
    [SerializeField] private float xSpacing;
    [SerializeField] private float ySpacing;
    [SerializeField] private int boxesPerRow;
    [SerializeField] private float referenceAspect;

    private void Start()
    {
        if (Mathf.Abs(parentRectTransform.rect.width / parentRectTransform.rect.height - referenceAspect) > 0.01f)
        {
            ResizeBoxes();
        }
    }

    private void Update()
    {
        if (Mathf.Abs(parentRectTransform.rect.width / parentRectTransform.rect.height - referenceAspect) > 0.01f)
        {
            ResizeBoxes();
        }
    }

    private void ResizeBoxes()
    {
        float parentWidth = parentRectTransform.rect.width;
        float parentHeight = parentRectTransform.rect.height;

        float aspectRatio = parentWidth / parentHeight;
        float referenceHeight = parentWidth / referenceAspect;

        float boxWidth = (parentWidth - (boxesPerRow - 1) * xSpacing) / boxesPerRow;
        float boxHeight = (parentHeight - (referenceHeight - boxWidth * 3 - 2 * ySpacing) - 2 * ySpacing) / 3;

        gridLayoutGroup.cellSize = new Vector2(boxWidth, boxHeight);
    }
} */