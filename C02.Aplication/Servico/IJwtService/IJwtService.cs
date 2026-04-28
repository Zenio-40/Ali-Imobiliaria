namespace C02.Aplication.Servico
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string role);
    }
}

