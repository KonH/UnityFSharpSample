using UnityEngine;
using UnityEngine.UI;
using GameLogics;

public class TestWrapper : MonoBehaviour {
	public Text       ScoreText;
	public InputField ScoreAddField;
	public Button     AddButton;
	public int        InitialScore;

	Logics.GameState _state;

	Logics.GameState State {
		get {
			return _state;
		}
		set {
			_state = value;
			UpdateView();
		}
	}

	private void Awake() {
		Debug.Assert(ScoreText);
		Debug.Assert(ScoreAddField);
		Debug.Assert(AddButton);
		AddButton.onClick.AddListener(TryToAddScore);
	}

	void Start() {
		State = new Logics.GameState(InitialScore);
		UpdateView();
	}

	void TryToAddScore() {
		if ( int.TryParse(ScoreAddField.text, out var value) ) {
			var result = Logics.addScore(State, value);
			if ( result != null ) {
				State = result.Value;
			} else {
				Debug.LogError($"Can't add {value} score!");
			}
		} else {
			Debug.LogError($"Can't parse int from '{ScoreAddField.text}'");
		}
	}

	void UpdateView() {
		ScoreText.text = State.score.ToString();
	}
}
