using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharSelection : MonoBehaviour
{
    public Button previousButton;
    public Button nextButton;
    private int currentCharacter;

    private void Awake()
    {
        SelectChar(0);
    }

    private void SelectChar(int _index)
    {
        previousButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount-1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }

    public void ChangeChar(int _change)
    {
        currentCharacter += _change;
        SelectChar(currentCharacter);
    }

    public void ConfirmSelection()
    {
        PlayerPrefs.SetInt("SelectedChar", currentCharacter);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
