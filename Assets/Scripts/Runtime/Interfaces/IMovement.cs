using UnityEngine;

public interface IMovement
{
    public void GravityProccess(float gravityScalar);
    public void Move(Vector3 direction, float moveSpeed);
    public void Jump(float jumpForce, float gravityScalar);
}
