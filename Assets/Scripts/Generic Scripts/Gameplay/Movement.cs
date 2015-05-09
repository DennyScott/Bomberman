using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    #region Public Variables
    public float Speed = 1.0f;

    #endregion

    #region Private Variables
    private float _speed = 0;
	private Animator animator;

    #endregion

    #region Standard Methods

	void Start() {
		animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {
        MoveUpAndDown();
        MoveLeftAndRight();

		OnKeyDown();
		OnKeyUp();
    }

    #endregion

	void OnKeyDown() {
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
			animator.SetBool("OnDown", true);
		}
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
			animator.SetBool("OnUp", true);
		}
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
			animator.SetBool("OnLeft", true);
		}
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
			animator.SetBool("OnRight", true);
		}
	}

	void OnKeyUp() {
		if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) {
			animator.SetBool("OnDown", false);
		}
		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) {
			animator.SetBool("OnUp", false);
		}
		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) {
			animator.SetBool("OnLeft", false);
		}
		if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) {
			animator.SetBool("OnRight", false);
		}
	}

    #region Update Movement Methods
    /// <summary>
    /// This method allows the user to move up and down
    /// </summary>
    void MoveUpAndDown() {
        var temp = transform.position;
        temp.y = MoveDirection("Vertical", transform.position.y);
        transform.position = temp;
    }

    /// <summary>
    /// This method allows the user to move left and right
    /// </summary>
    void MoveLeftAndRight() {
        var temp = transform.position;
        temp.x = MoveDirection("Horizontal", transform.position.x);
        transform.position = temp;
    }

    /// <summary>
    /// Moves in a direction with the given axis name, and the value of the axis
    /// </summary>
    /// <param name="axisName">This is either Horizontal or Vertical</param>
    /// <param name="axisFloat">This is either x or y depending on if you are moving vertical or horizontal</param>
    /// <returns>The new position of the object</returns>
    float MoveDirection(string axisName, float axisFloat) {
        var move = Input.GetAxis(axisName);
        if (move == 0) {
            return axisFloat;
        }
        return axisFloat + Speed * Time.deltaTime * move;
    }

    #endregion

}
