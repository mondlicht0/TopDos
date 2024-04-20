using UnityEngine;

public interface IMovement
{
    public void Move(Vector3 direction, float moveSpeed);

    public virtual void Init()
    {
        
    }
}
