using System.Collections;

public interface IMovil
{
    public abstract void Move();
    public abstract void DisableMovement(float time);

    public abstract void DisableMovement();

    public abstract void AbleMovement();
}
