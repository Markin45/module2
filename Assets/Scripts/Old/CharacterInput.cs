using UnityEngine;

[RequireComponent(typeof(Character))]
public sealed class CharacterInput : MonoBehaviour
{
    private Character _character;

    private void Start()
    {
        _character = GetComponent<Character>();
    }

    private void Update()
    {
        float horz = Input.GetAxis("Horizontal");
        if (horz < -0.1f)
        {
            _character.MoveLeft();
        }
        else if (horz > 0.1f)
        {
            _character.MoveRight();
        }

        if (Input.GetButton("Jump"))
            _character.Jump();
    }
}
