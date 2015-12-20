namespace PizzaNetWebAPI.Email
{
    public abstract class EmailCreator
    {
        abstract public string GetBody();
        abstract public string GetSubject();
    }
}