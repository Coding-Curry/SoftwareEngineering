using UnityEngine;
using UnityEngine.UI;

public class MatrixAddition : MonoBehaviour
{
    public InputField rowsInput;
    public InputField columnsInput;

    public GameObject resultTextPrefab;
    public Transform resultTextContainer;

    private int[,] matrix1;
    private int[,] matrix2;
    private int[,] sumMatrix;

    private void Start()
    {
        // 初始化输入框监听
        rowsInput.onEndEdit.AddListener(OnRowsEndEdit);
        columnsInput.onEndEdit.AddListener(OnColumnsEndEdit);
    }

    private void OnRowsEndEdit(string value)
    {
        int rows = int.Parse(value);
        int columns = int.Parse(columnsInput.text);

        matrix1 = new int[rows, columns];
        matrix2 = new int[rows, columns];
        sumMatrix = new int[rows, columns];

        // 创建输入Matrix1的UI
        CreateMatrixInputUI("Matrix 1", matrix1);

        // 创建输入Matrix2的UI
        CreateMatrixInputUI("Matrix 2", matrix2);

        // 创建计算结果的UI
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject resultText = Instantiate(resultTextPrefab, resultTextContainer);
                resultText.GetComponent<Text>().text = "";
            }
        }
    }

    private void OnColumnsEndEdit(string value)
    {
        int rows = int.Parse(rowsInput.text);
        int columns = int.Parse(value);

        matrix1 = new int[rows, columns];
        matrix2 = new int[rows, columns];
        sumMatrix = new int[rows, columns];

        // 创建输入Matrix1的UI
        CreateMatrixInputUI("Matrix 1", matrix1);

        // 创建输入Matrix2的UI
        CreateMatrixInputUI("Matrix 2", matrix2);

        // 创建计算结果的UI
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject resultText = Instantiate(resultTextPrefab, resultTextContainer);
                resultText.GetComponent<Text>().text = "";
            }
        }
    }

    private void CreateMatrixInputUI(string matrixName, int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject inputFieldObj = new GameObject("InputField");
                inputFieldObj.transform.SetParent(transform);

                InputField inputField = inputFieldObj.AddComponent<InputField>();
                inputField.textComponent = inputField.GetComponentInChildren<Text>();

                RectTransform rectTransform = inputFieldObj.GetComponent<RectTransform>();
                rectTransform.sizeDelta = new Vector2(50f, 30f);
                rectTransform.anchoredPosition3D = new Vector3(j * 60f, -i * 40f, 0f);

                Text labelText = new GameObject("Label").AddComponent<Text>();
                labelText.transform.SetParent(inputFieldObj.transform);
                labelText.alignment = TextAnchor.MiddleCenter;
                labelText.rectTransform.sizeDelta = new Vector2(50f, 30f);
                labelText.rectTransform.anchoredPosition3D = Vector3.zero;
                labelText.text = matrixName + "[" + (i+1) + "," + (j+1) + "]";

                //InputField.Entry entry = new InputField.Entry { contentType = InputField.ContentType.IntegerNumber };
                inputField.inputType = InputField.InputType.Standard;
                inputField.characterLimit = 3;
                inputField.textComponent.text = "";
                inputField.textComponent.alignment = TextAnchor.MiddleCenter;
                inputField.targetGraphic = inputField.textComponent;
                inputField.onEndEdit.AddListener(delegate { OnValueEndEdit(inputField, matrix, i, j); });
            }
        }
    }

    private void OnValueEndEdit(InputField inputField, int[,] matrix, int row, int column)
    {
        int value;
        if (int.TryParse(inputField.text, out value))
        {
            matrix[row, column] = value;
        }
        else
        {
            inputField.text = "";
            matrix[row, column] = 0;
        }

        // 计算矩阵和
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                sumMatrix[i, j] = matrix1[i, j] + matrix2[i, j];

                // 更新计算结果的UI
                Transform cell = resultTextContainer.GetChild(i * columns + j);
                cell.GetComponent<Text>().text = sumMatrix[i, j].ToString();
            }
        }
    }
}